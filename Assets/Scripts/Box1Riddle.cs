using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Box1Riddle : MonoBehaviour
{
    public List<Collider> mustBeInObjects;
    public List<Collider> forbiddenObjects;

    private readonly HashSet<Collider> _isInBox = new();
    private readonly List<Vector3> _mustObjStartPos = new();
    private readonly List<Vector3> _forbiddenObjStartPos = new();
    private readonly List<Quaternion> _mustObjStartRot = new();
    private readonly List<Quaternion> _forbiddenObjStartRot = new();

    public AudioSource winSound;
    public ParticleSystem winParticles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Collider mustBeInObject in mustBeInObjects)
        {
            Transform t = mustBeInObject.transform;
            _mustObjStartPos.Add(t.position);
            _mustObjStartRot.Add(t.rotation);
        }

        foreach (Collider forbiddenObject in forbiddenObjects)
        {
            Transform t = forbiddenObject.transform;
            _forbiddenObjStartPos.Add(t.position);
            _forbiddenObjStartRot.Add(t.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mustBeInObjects.Contains(other) || forbiddenObjects.Contains(other))
        {
            _isInBox.Add(other);
            CheckRiddle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (mustBeInObjects.Contains(other) || forbiddenObjects.Contains(other))
        {
            _isInBox.Remove(other);
            CheckRiddle();
        }
    }

    private void CheckRiddle()
    {
        bool allMustObjects = mustBeInObjects.All(_isInBox.Contains);
        bool anyForbiddenObjects = forbiddenObjects.Any(_isInBox.Contains);

        if (allMustObjects && !anyForbiddenObjects)
        {
            Debug.Log("Box1: SIEG");
            if (winParticles != null) winParticles.Play();
            if (winSound != null) winSound.Play();
            EventManager.instance.box1Solved.Invoke(true);
        }
        else
        {
            Debug.Log("Box1: Noch nicht gewonnen");
            if (winParticles != null) winParticles.Stop();
            EventManager.instance.box1Solved.Invoke(false);
        }
    }

    public void RestObjects()
    {
        if (
            mustBeInObjects.Count != _mustObjStartPos.Count || mustBeInObjects.Count != _mustObjStartRot.Count ||
            forbiddenObjects.Count != _forbiddenObjStartPos.Count ||
            forbiddenObjects.Count != _forbiddenObjStartRot.Count
        )
        {
            Debug.LogError("Count mismatch");
            return;
        }

        for (int i = 0; i < mustBeInObjects.Count; i++)
        {
            mustBeInObjects[i].transform.position = _mustObjStartPos[i];
            mustBeInObjects[i].transform.rotation = _mustObjStartRot[i];
        }

        for (int i = 0; i < forbiddenObjects.Count; i++)
        {
            forbiddenObjects[i].transform.position = _forbiddenObjStartPos[i];
            forbiddenObjects[i].transform.rotation = _forbiddenObjStartRot[i];
        }

        _isInBox.Clear();
    }
}