using UnityEngine;

public class LevelDone : MonoBehaviour
{
    public ParticleSystem ps;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps.Stop();
        EventManager.instance.levelDone.AddListener(ps.Play);
    }
}
