// ============================================================================
//  VR Zahlensuche HTL — Sistema de Localização
//  Versão completa com mensagem final
// ============================================================================

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class LocalizationSystem
{
    public enum Language { German, English, Portuguese }

    public static Language CurrentLanguage { get; private set; } = Language.German;
    public static readonly UnityEvent OnLanguageChanged = new UnityEvent();
    private const string PrefsKey = "SelectedLanguage";

    private static readonly Dictionary<string, string[]> _translations = new Dictionary<string, string[]>
    {
        // ── Welcome / Introdução ───────────────────────────────────────────────
        { "intro_title",        new[] { "Willkommen!", "Welcome!", "Bem-vindo!" } },
        { "intro_description",  new[] {
            "Löse alle Rätsel, um die geheime Nummer freizuschalten!",
            "Solve all riddles to unlock the secret number!",
            "Resolva todos os enigmas para desbloquear o número secreto!" } },

        // ── Grab Interactable Info (botão escondido) ───────────────────────────
        { "grab_title",         new[] { "Grab Interactable", "Grab Interactable", "Objeto para Agarrar" } },
        { "grab_description",   new[] {
            "Irgendwo hier sollte sich noch ein Knopf befinden, der darauf wartet gedrückt zu werden ...",
            "Somewhere here there should be a button waiting to be pressed ...",
            "Algures aqui deve haver um botão à espera de ser pressionado ..." } },

        // ── Suchbox Info (Caixa de objetos HTL) ────────────────────────────────
        { "suchbox_title",      new[] { "Suchbox", "Search Box", "Caixa de Objetos" } },
        { "suchbox_description",new[] {
            "Ein paar dieser vier Dinge arbeiten eng zusammen, um Daten und Befehle auszutauschen. Zwei Dinge liefern zwar Energie, aber auf eine ganz andere Weise. Welche Objekte gehören ins Team der Technik?\nWirf die passenden Objekte in die Box links von dir!",
            "A few of these four things work closely together to exchange data and commands. Two things provide energy, but in a completely different way. Which objects belong to the technology team?\nThrow the matching objects into the box to your left!",
            "Algumas destas quatro coisas trabalham juntas para trocar dados e comandos. Duas coisas fornecem energia, mas de uma forma completamente diferente. Que objetos pertencem à equipa da tecnologia?\nAtira os objetos certos para a caixa à tua esquerda!" } },

        // ── Poke Interactions Info (HTL Wolfsberg / Logo) ──────────────────────
        { "poke_title",         new[] { "HTL Wolfsberg", "HTL Wolfsberg", "HTL Wolfsberg" } },
        { "poke_description",   new[] {
            "Wie viele blaue Buchstaben sind in unserem Logo?",
            "How many blue letters are in our logo?",
            "Quantas letras azuis há no nosso logótipo?" } },

        // ── Uebung Interactable Info (Übungsgelände) ───────────────────────────
        { "uebung_title",       new[] { "Übungsgelände", "Practice Area", "Área de Treino" } },
        { "uebung_description", new[] {
            "Hier gibt es kein Rätsel für dich",
            "There is no riddle for you here",
            "Aqui não há enigma para ti" } },

        // ── Finish Info (Saída) ────────────────────────────────────────────────
        { "finish_title",       new[] { "Ausgang", "Exit", "Saída" } },
        { "finish_description", new[] {
            "Du hast alle Rätsel gelöst!",
            "You have solved all the riddles!",
            "Resolveste todos os enigmas!" } },

        // ── Mensagem final (com código) ────────────────────────────────────────
        { "final_message",      new[] {
            "Gratulation! Du hast alle Aufgaben gelöst.\nWenn du auch lernen möchtest, wie man solche Anwendungen entwickelt, besuche doch Betriebsinformatik an der HTL Wolfsberg.\nHier ist dein Lösungscode: 1979",
            "Congratulations! You have solved all the tasks.\nIf you would like to learn how to develop such applications, visit Business Informatics at HTL Wolfsberg.\nHere is your solution code: 1979",
            "Parabéns! Resolveste todas as tarefas.\nSe quiseres aprender a desenvolver este tipo de aplicações, visita Informática de Gestão na HTL Wolfsberg.\nAqui está o teu código: 1979" } },

        // ── Botões da UI ───────────────────────────────────────────────────────
        { "btn_reset",          new[] { "Zurücksetzen", "Reset", "Reiniciar" } },
        { "btn_confirm",        new[] { "Bestätigen", "Confirm", "Confirmar" } },
        { "btn_continue",       new[] { "Weiter", "Continue", "Continuar" } },
        { "btn_close",          new[] { "Schließen", "Close", "Fechar" } },

        // ── Nomes dos idiomas ──────────────────────────────────────────────────
        { "lang_german",        new[] { "Deutsch", "German", "Alemão" } },
        { "lang_english",       new[] { "English", "English", "Inglês" } },
        { "lang_portuguese",    new[] { "Portugiesisch", "Portuguese", "Português" } },
    };

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadSavedLanguage()
    {
        CurrentLanguage = (Language)PlayerPrefs.GetInt(PrefsKey, 0);
    }

    public static string Get(string key)
    {
        if (!_translations.TryGetValue(key, out string[] vals)) return $"[{key}]";
        int i = (int)CurrentLanguage;
        return (i >= 0 && i < vals.Length) ? vals[i] : vals[0];
    }

    public static void SetLanguage(Language lang)
    {
        CurrentLanguage = lang;
        PlayerPrefs.SetInt(PrefsKey, (int)lang);
        PlayerPrefs.Save();
        OnLanguageChanged.Invoke();
        Debug.Log($"[Localization] Idioma alterado para: {lang}");
    }
}
