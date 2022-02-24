using UnityEngine;
using System;
using System.Linq;
/*
Управляет всеми текстовыми переводами и изображениями. Должен быть доступен для всего, что имеет текст и изображение.
Может дать правильный перевод и необходимое изображение для любого сохраненного идентификатора.
Автоматически загружает последний использованный язык, если таковой имеется.
*/
public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance { get; private set; }

    [SerializeField]
    private SystemLanguage DefaultLanguage = SystemLanguage.English;

    private SystemLanguage currentLanguage;

    public TextEditor textEditor;
    public DictionaryEditor dictionaryEditor;

    //Создайте делегат и события для использования в файлах LocaleText.cs и LocaleImage.cs:
    public delegate void LanguageChangedEventHandler();
    public event LanguageChangedEventHandler LanguageChanged;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("LastLanguage"))
        {
            SystemLanguage newLang = (SystemLanguage)PlayerPrefs.GetInt("LastLanguage");
            try
            {
                SetLocalization(newLang);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                Debug.Log("Trying Default Language: " + DefaultLanguage);
                SetLocalization(DefaultLanguage);
            }
        }
        else
            SetLocalization(DefaultLanguage);

        if (!Instance)
        {
            Instance = this;
            return;
        }
        else
            Destroy(this.gameObject);
    }
    /*
    Устанавливает текущий язык, используемый функцией GetText() и GetImage(), на указанный язык.
    <param name="language">Язык для изменения.</param>
    */
    public void SetLocalization(SystemLanguage language)
    {
        currentLanguage = language;
        OnLanguageChanged();
    }
    /*
    Получить текст по указанному идентификатору.
    <param name="identifier">Идентификатор для поиска в текущей locale.</param>
    <returns>Строка, связанная с идентификатором. Если он не существует, то null.</returns>.
    */
    public string GetText(string identifier)
    {
        string text;
        if (textEditor.txtList.Exists(x => x.key == identifier))
        {
            int keyId = textEditor.txtList.FindIndex(x => x.key == identifier);
            if (textEditor.txtList[keyId].textsList.Exists(x => x.language == currentLanguage))
            {
                int textId = textEditor.txtList[keyId].textsList.FindIndex(x => x.language == currentLanguage);
                text = textEditor.txtList[keyId].textsList[textId].text;
                return text;
            }
            else
                Debug.Log("Localization Error!: The '" + currentLanguage + "' key doesn't exist!");
        }
        else
            Debug.Log("Localization Error!: The '" + identifier + "' key doesn't exist!");
        return null;
    }
    /*
    Получить изображение по указанному идентификатору.
    <param name="identifier">Идентификатор для поиска в текущей locale.</param>
    <returns>Изображение, связанное с идентификатором. Если он не существует, то null.</returns>.
    */
    public Sprite GetImage(string identifier)
    {
        Sprite sprite;
        if (dictionaryEditor.imgList.Exists(x => x.key == identifier))
        {
            int keyId = dictionaryEditor.imgList.FindIndex(x => x.key == identifier);
            if (dictionaryEditor.imgList[keyId].imagesList.Exists(x => x.language == currentLanguage))
            {
                int textId = dictionaryEditor.imgList[keyId].imagesList.FindIndex(x => x.language == currentLanguage);
                sprite = dictionaryEditor.imgList[keyId].imagesList[textId].sprite;
                return sprite;
            }
            else
                Debug.Log("Localization Error!: The '" + currentLanguage + "' key doesn't exist!");
        }
        else
            Debug.Log("Localization Error!: The '" + identifier + "' key doesn't exist!");
        return null;
    }

    protected virtual void OnLanguageChanged()
    {
        LanguageChanged?.Invoke();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("LastLanguage", (int)currentLanguage);
    }
}