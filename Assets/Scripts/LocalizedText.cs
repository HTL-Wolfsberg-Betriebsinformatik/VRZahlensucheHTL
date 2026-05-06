// ============================================================================
//  LocalizedText — anexa este script a qualquer texto da UI (Text ou TMP)
//  e o texto vai mudar automaticamente quando o idioma for alterado.
//
//  COMO USAR:
//  1. Copia este ficheiro para Assets/Scripts/
//  2. Seleciona um texto da cena (ex: o título "Welcome UI")
//  3. Add Component → Localized Text
//  4. No campo "Localization Key" escreve a chave da tradução
//     (ex: intro_title, box1_description, level_done_title)
//
//  CHAVES DISPONÍVEIS (definidas em LocalizationSystem.cs):
//  - intro_title, intro_description, intro_secret_label
//  - box1_title, box1_description
//  - counter_title, counter_description
//  - search_title, search_description
//  - branches_title
//  - level_done_title
//  - btn_reset
//  - lang_german, lang_english, lang_portuguese
// ============================================================================

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    [Tooltip("Chave da tradução definida em LocalizationSystem")]
    public string localizationKey;

    private Text     _legacyText;
    private TMP_Text _tmpText;

    void Awake()
    {
        _legacyText = GetComponent<Text>();
        _tmpText    = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        LocalizationSystem.OnLanguageChanged.AddListener(Refresh);
        Refresh();
    }

    void OnDisable()
    {
        LocalizationSystem.OnLanguageChanged.RemoveListener(Refresh);
    }

    public void Refresh()
    {
        if (string.IsNullOrEmpty(localizationKey)) return;

        string text = LocalizationSystem.Get(localizationKey);

        if (_tmpText    != null) _tmpText.text    = text;
        if (_legacyText != null) _legacyText.text = text;
    }
}
