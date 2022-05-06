using System.Collections.Generic;
using UnityEngine;

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
    [HideInInspector] public List<SnakeSkin> buttons;

    public int SnakeLength
    {
        get { return Data.instance.player.snakeLength; }
        set { Data.instance.player.snakeLength = value; }
    }
    public int SnakeSkin
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

        for (int i = 0; i < dict.skins.Count; i++)
        {
            if (i + 1 > PurchaseSkins.Count)
                PurchaseSkins.Add(false);

            var obj = Instantiate(buttonSkin, container);

            buttons.Add(obj.GetComponent<SnakeSkin>());
            buttons[i].id = i;
            buttons[i].skin = PurchaseSkins[i];
            buttons[i].UpdateUI();
        }
    }

    private void Start()
    {
        SetSkin(SnakeSkin);
    }

    public void UpdatePurchase(int id)
    {
        PurchaseSkins[id] = true;
        buttons[id].skin = PurchaseSkins[id];
    }

    public void SetSkin(int id)
    {
        buttons[SnakeSkin].chekmark.SetActive(false);
        buttons[id].chekmark.SetActive(true);
        SnakeSkin = id;
        
        Head.GetComponent<SpriteRenderer>().sprite = dict.skins[id].head;

        int count = 0;
        int idTail = 0;

        for (int i = 0; i < SnakeLength; i++)
        {
            Snake.transform.GetChild(count + 4).GetComponent<SpriteRenderer>().sprite = dict.skins[id].sprites[idTail];

            if (idTail == dict.skins[id].sprites.Count - 1)
                idTail = 0;
            else
                idTail++;

            count++;
        }
    }
}