using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour
{
    public SkinsDict dict;

    [Header("Snake")]
    public GameObject Snake;

    [Header("Button")]
    public GameObject buttonSkin;
    public Transform container;

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
        InstantiateButtons();

        //foreach(bool a in PurchaseSkins)
        //    Debug.Log(a);
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
            clone.GetComponent<Button>().onClick.AddListener(() => SoundsManager.instance.EffectsSound(1));
            clone.transform.Find("Button").GetComponent<Image>().sprite = dict.skins[c].head;
            clone.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => SetSkin(c));
            clone.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => SoundsManager.instance.EffectsSound(0));

            if (c + 1 > PurchaseSkins.Count)
                PurchaseSkins.Add(false);

            number++;
        }
    }

    public void SetSkin(int key)
    {
        //if (PurchaseSkins[key])
        //{
            Skin = key;
            Snake.transform.Find("Head").GetComponent<SpriteRenderer>().sprite = dict.skins[key].head;

            for (int i = 0; i <= SnakeMovement.instance.SnakeLength; i++)
                Snake.transform.GetChild(i + 2).GetComponent<SpriteRenderer>().sprite = dict.skins[key].tail;
        //}
        //else
        //{

        //}
    }
}