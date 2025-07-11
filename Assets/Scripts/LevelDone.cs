using UnityEngine;

public class LevelDone : MonoBehaviour
{
    public AudioSource winSound;
    public GameObject Obstacle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventManager.instance.levelDone.AddListener(UnlockEnd);
    }

    void UnlockEnd()
    {
        Obstacle.SetActive(false);
        winSound.Play();
    }
}
