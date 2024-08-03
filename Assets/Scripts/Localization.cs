using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public void ChangeLocalization()
    {                
        switch (YandexGamesSdk.Environment.i18n.lang)
        {
            case "en":
                LeanLocalization.SetCurrentLanguageAll("en");
                break;

            case "ru":
                LeanLocalization.SetCurrentLanguageAll("ru");
                break;

            case "tr":
                LeanLocalization.SetCurrentLanguageAll("tr");
                break;

            default:
                LeanLocalization.SetCurrentLanguageAll("ru");
                break;
            }

            LeanLocalization.UpdateTranslations();     
    }
}
