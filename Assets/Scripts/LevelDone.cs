using UnityEngine;

public class LevelDone : MonoBehaviour
{
    public AudioSource winSound;
    public GameObject obstacle;
    public GameObject teleportPlatform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManager.instance.levelDone.AddListener(UnlockEnd);
        teleportPlatform.SetActive(false);
        obstacle.SetActive(true);
    }

    void UnlockEnd()
    {
        obstacle.SetActive(false);
        teleportPlatform.SetActive(true);
        winSound.Play();
    }
}