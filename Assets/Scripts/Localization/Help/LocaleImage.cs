using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]
//������������� ����������� �� ����� ���������� �������������� ����������� ��������� �����������, ����� �� �������������� ������� Locale.
public class LocaleImage : MonoBehaviour
{
    [SerializeField]
    private string imageID; //������������� �������, ������� �� ����� ���������.

    private Image imageComponent;

    private void Awake()
    {
        //������ �� ���:
        imageComponent = GetComponent<Image>();
    }

    private void Start()
    {
        LocalizationManager.instance.LanguageChanged += UpdateLocale;
        //���������, ��� ��� ��������� ����� ������� ������������ ���������� ����:
        UpdateLocale();
    }
    /*
    �������� �������� ��������� ��������� ������ �� LocalizationManager.
    � ������ ������ ��������� ������� text ��������� ���������� Text.
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