using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnakeSkin : MonoBehaviour
{
    public SkinsDict dict;

    public Button button;
    public GameObject panel;
    public TMP_Text text;

    public int id;

    private int Skin
    {
        get { return Data.instance.player.skin; }
        set { Data.instance.player.skin = value; }
    }
    private List<bool> PurchaseSkins
    {
        get { return Data.instance.player.purchaseSkins; }
        set { Data.instance.player.purchaseSkins = value; }
    }

    private void Awake()
    {
        button.image.sprite = dict.skins[id].head;
        button.onClick.AddListener(() => SoundsManager.instance.EffectsSound(0));
        panel.GetComponent<Button>().onClick.AddListener(() => SoundsManager.instance.EffectsSound(1));
        text.text = dict.skins[id].price.ToString();
    }

    private void Update()
    {
        if (PurchaseSkins[id])
            panel.SetActive(false);
    }

    public void UnlockSkin()
    {
        Score.instance.BuySkin(id);
    }

    public void SetSkin()
    {
        if (PurchaseSkins[id] == true)
        {
            Skin = id;
            SkinsManager.instance.SetSkin(id);
        }
    }
}