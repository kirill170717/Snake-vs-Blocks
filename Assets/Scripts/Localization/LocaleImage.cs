using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
//Предоставляет возможность во время выполнения манипулировать родственным текстовым компонентом, чтобы он соответствовал текущей Locale.
public class LocaleImage : MonoBehaviour
{
    public LocalizationManager manager;
    public string textID; //Идентификатор ресурса, который мы хотим захватить.

    private Image imageComponent;

    private void Awake()
    {
        //Ссылки на кэш:
        imageComponent = GetComponent<Image>();
        manager.LanguageChanged += UpdateLocale;
    }

    private void Start()
    {
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
            Sprite response = manager.GetImage(textID);
            if (response != null)
                imageComponent.sprite = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}