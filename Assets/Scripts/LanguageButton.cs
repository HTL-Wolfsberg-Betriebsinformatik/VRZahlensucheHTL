using UnityEngine;

/// <summary>
/// Anexa este script aos botões da UI manual.
/// Cada botão deve ter um destes componentes com a língua correspondente.
/// Liga o botão à função SetLanguage() no evento OnClick.
/// </summary>
public class LanguageButton : MonoBehaviour
{
    public LocalizationSystem.Language language;

    /// <summary>Liga esta função ao OnClick do botão.</summary>
    public void SetLanguage()
    {
        LocalizationSystem.SetLanguage(language);
        Debug.Log($"[LanguageButton] Idioma alterado para: {language}");
    }
}
