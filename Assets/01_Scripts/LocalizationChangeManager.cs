using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;

public class LocalizationChangeManager : MonoBehaviour
{
    private bool _active = false;

    [Space]
    
    public TMP_Dropdown languageDropdown;

    private void Start()
    {
        // Get the saved locale key from PlayerPrefs
        int localeID = PlayerPrefs.GetInt("LocaleKey", 0);

        // Initialize the language based on the saved value
        ChangeLocale(localeID);

        // Set the dropdown to the saved locale ID
        if (languageDropdown != null)
        {
            languageDropdown.value = localeID;  // Set the dropdown to match the saved locale
            languageDropdown.onValueChanged.AddListener(OnLanguageDropdownValueChanged); // Add listener
        }
    }

    // Handle the value change from the dropdown
    private void OnLanguageDropdownValueChanged(int localeID)
    {
        ChangeLocale(localeID);
    }

    // Change locale based on the dropdown selection
    public void ChangeLocale(int localeID)
    {
        if (_active)
        {
            return;
        }
        StartCoroutine(SetLocale(localeID));
    }

    // Set the selected language in the localization system
    private IEnumerator SetLocale(int localeID)
    {
        _active = true;

        // Wait until the localization system is initialized
        yield return LocalizationSettings.InitializationOperation;

        // Set the selected locale
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];

        // Save the selected language in PlayerPrefs for persistence
        PlayerPrefs.SetInt("LocaleKey", localeID);
        _active = false;
    }

    // Optional If we want to handle specific languages manually
    public void ChangeLanguageToSpanish()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];  
    }

    public void ChangeLanguageToEnglish()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];  
    }
}
