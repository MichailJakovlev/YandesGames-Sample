using TMPro;
using UnityEngine;

public class TextLocalization : MonoBehaviour
{
    [SerializeField] string _ru;
    [SerializeField] string _en;
    [SerializeField] string _tr;

    private void Start()
    {
        if (YandexManager._instance._currentLanguage == "ru"
            || YandexManager._instance._currentLanguage == "ru-RU"
            || YandexManager._instance._currentLanguage == "ru-KG"
            || YandexManager._instance._currentLanguage == "ru-KZ"
            || YandexManager._instance._currentLanguage == "ru-MD"
            || YandexManager._instance._currentLanguage == "ru-BY"
            || YandexManager._instance._currentLanguage == "ru-UA")
        {
            GetComponent<TextMeshProUGUI>().text = _ru;
        }
        else if (YandexManager._instance._currentLanguage == "tr"
            || YandexManager._instance._currentLanguage == "tr-CY"
            || YandexManager._instance._currentLanguage == "tr-TR")
        {
            GetComponent<TextMeshProUGUI>().text = _tr;
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
    }
}
