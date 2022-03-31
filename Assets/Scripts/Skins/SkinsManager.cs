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

    private int SnakeSkin
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
            var obj = Instantiate(buttonSkin, container);
            obj.name = dict.skins[i].key;
            buttons.Add(obj.GetComponent<SnakeSkin>());
            buttons[i].id = i;

            if (i + 1 > PurchaseSkins.Count)
                PurchaseSkins.Add(false);

            PurchaseSkins[0] = true;
        } 
    }

    private void Start()
    {
        SetSkin(SnakeSkin);
    }

    public void SetSkin(int id)
    {
        Head.GetComponent<SpriteRenderer>().sprite = dict.skins[id].head;

        for (int i = 0; i <= SnakeMovement.instance.SnakeLength; i++)
            Snake.transform.GetChild(i + 2).GetComponent<SpriteRenderer>().sprite = dict.skins[id].tail;
    }
}