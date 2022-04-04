using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnakeSkin : MonoBehaviour
{
    public SkinsDict dict;

    public Button button;
    public GameObject chekmark;
    public Image image;
    public TMP_Text text;

    public int id;
    public bool skin;

    private void Start()
    {
        button.image.sprite = dict.skins[id].head;
        button.onClick.AddListener(() => SoundsManager.instance.EffectsSound(0));
        text.text = dict.skins[id].price.ToString();
    }

    public void UpdateUI()
    {
        if (skin)
            image.gameObject.SetActive(false);
    }

    public void SetSkin()
    {
        if (skin)
            SkinsManager.instance.SetSkin(id);
        else
        {
            Score.instance.BuySkin(id);
            UpdateUI();
        }
    }
}