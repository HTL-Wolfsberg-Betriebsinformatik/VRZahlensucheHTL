using UnityEngine;

public class ButtonSerachRiddle : MonoBehaviour
{
    public AudioSource winSound;
    public ParticleSystem winParticles;

    public void ButtonPressed()
    {
        if (winSound != null)
            winSound.Play();
        if (winParticles != null)
            winParticles.Play();
        EventManager.instance.buttonSearchSolved.Invoke();
    }
}