using UnityEngine;

public class AppendAppVersion : MonoBehaviour
{
    void Start()
    {
        var textBox = gameObject.GetComponent<UnityEngine.UI.Text>();
        if (textBox == null)
        {
            Debug.LogError($"Text component {gameObject.name} is missing. Can not append version.");
            return;
        }
        textBox.text += "\nv" + Application.version;
    }
}
