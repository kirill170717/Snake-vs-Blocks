using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
//Предоставляет возможность во время выполнения манипулировать родственным текстовым компонентом, чтобы он соответствовал текущей Locale.
public class LocaleText : MonoBehaviour
{
    public string textID; //Идентификатор ресурса, который мы хотим захватить.

    private Text textComponent;

    private void Awake()
    {
        //Ссылки на кэш:
        textComponent = GetComponent<Text>();
    }

    private void Start()
    {
        LocalizationManager.instance.LanguageChanged += UpdateLocale;
        //Убедитесь, что при активации этого объекта отображается правильный язык:
        UpdateLocale();
    }
    /*
    Пытается получить связанный строковый ресурс из LocalizationManager.
    В случае успеха обновляет атрибут text дочернего компонента Text.
    */
    public void UpdateLocale()
    {
        try
        {
            string response = LocalizationManager.instance.GetText(textID);
            if (!string.IsNullOrEmpty(response))
                textComponent.text = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}