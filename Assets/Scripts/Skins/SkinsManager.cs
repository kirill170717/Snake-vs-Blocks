using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour
{
    public static SkinsManager instance;

    public SkinsDict dict;

    [Header("Snake")]
    public GameObject Snake;
    public GameObject Head;

    [Header("Button")]
    public GameObject buttonSkin;
    public Transform container;

    [HideInInspector] public List<TMP_Text> buttonText;
    [HideInInspector] public List<GameObject> buttonPanel;

    private GameObject clone;

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
        instance = this;

        InstantiateButtons();

        foreach (bool a in PurchaseSkins)
            Debug.Log(a);
    }

    private void Start()
    {
        SetSkin(Skin);
    }

    private void InstantiateButtons()
    {
        int number = 0;
        foreach (SkinsDict.Skin skin in dict.skins)
        {
            int c = number;
            
            clone = Instantiate(buttonSkin, container);
            clone.name = dict.skins[c].key;
            clone.GetComponent<ButtonComponents>().button.image.sprite = dict.skins[c].head;
            clone.GetComponent<ButtonComponents>().button.onClick.AddListener(() => SetSkin(c));
            clone.GetComponent<ButtonComponents>().button.onClick.AddListener(() => SoundsManager.instance.EffectsSound(0));
            clone.GetComponent<ButtonComponents>().panel.GetComponent<Button>().onClick.AddListener(() => UnlockSkin(c));
            clone.GetComponent<ButtonComponents>().panel.GetComponent<Button>().onClick.AddListener(() => SoundsManager.instance.EffectsSound(1));
            clone.GetComponent<ButtonComponents>().text.text = dict.skins[c].price.ToString();

            buttonText.Add(clone.GetComponent<ButtonComponents>().text);
            buttonPanel.Add(clone.GetComponent<ButtonComponents>().panel);

            if (c + 1 > PurchaseSkins.Count)
                PurchaseSkins.Add(false);

            if (clone.GetComponent<ButtonComponents>().text.text == "0")
            {
                clone.GetComponent<ButtonComponents>().panel.SetActive(false);
                PurchaseSkins[c] = true;
            }
            else
                PurchaseSkins[c] = false;

            number++;
        }
    }

    public void UnlockSkin(int c)
    {
        Score.instance.UnlockingSkin(c);
        buttonText[c].text = dict.skins[c].price.ToString();

        if(dict.skins[c].price == 0)
        {
            buttonPanel[c].SetActive(false);
            PurchaseSkins[c] = true;
        }
    }

    public void SetSkin(int key)
    {
        if (PurchaseSkins[key])
        {
            Skin = key;
            Head.GetComponent<SpriteRenderer>().sprite = dict.skins[key].head;

            for (int i = 0; i <= SnakeMovement.instance.SnakeLength; i++)
                Snake.transform.GetChild(i + 2).GetComponent<SpriteRenderer>().sprite = dict.skins[key].tail;
        }
    }
}