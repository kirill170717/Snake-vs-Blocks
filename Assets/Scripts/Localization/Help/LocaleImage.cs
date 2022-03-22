using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
//Предоставляет возможность во время выполнения манипулировать родственным текстовым компонентом, чтобы он соответствовал текущей Locale.
public class LocaleImage : MonoBehaviour
{
    [SerializeField]
    private string imageID; //Идентификатор ресурса, который мы хотим захватить.

    private Image imageComponent;

    private void Awake()
    {
        //Ссылки на кэш:
        imageComponent = GetComponent<Image>();
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
            Sprite response = LocalizationManager.instance.GetImage(imageID);
            if (response != null)
                imageComponent.sprite = response;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}