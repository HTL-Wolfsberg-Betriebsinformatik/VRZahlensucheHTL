using UnityEngine;

public class WelcomeUIManager : MonoBehaviour
{
    public GameObject menuToHide;

    void Start()
    {
        if (menuToHide != null)
            menuToHide.SetActive(true);
    }

    public void HideMenu()
    {
        if (menuToHide != null)
            menuToHide.SetActive(false);
    }
}