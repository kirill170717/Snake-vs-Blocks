using System.Collections;
using TMPro;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public static SnakeMovement instance;

    public float forwardSpeed = 4;
    public float sensitivity = 90;
    public float impulse = 4;
    [HideInInspector] public bool block = false;

    public int SnakeLength
    {
        get { return Data.instance.player.snakeLength; }
        set { Data.instance.player.snakeLength = value; }
    }
    public int TotalSnakeLength
    {
        get { return Data.instance.player.totalSnakeLength; }
        set { Data.instance.player.totalSnakeLength = value; }
    }
    public int SnakeSkin
    {
        get { return Data.instance.player.skin; }
        set { Data.instance.player.skin = value; }
    }

    public TMP_Text pointsText;

    private Camera mainCamera;
    private Rigidbody2D componentRigidbody;
    private SnakeHead SnakeHead;
    private SnakeTail componentSnakeTail;
    private Vector2 touchLastPos;
    private Vector2 delta;
    private float sidewaysSpeed;

    private void Awake()
    {
        instance = this;
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody2D>();
        componentSnakeTail = GetComponent<SnakeTail>();
        SnakeHead = GetComponent<SnakeHead>();

        for (int i = 0; i < SnakeLength; i++)
            componentSnakeTail.AddTail();

        pointsText.SetText(SnakeLength.ToString());
    }

    private void OnEnable()
    {
        SnakeHead.BlockCollided += OnBlockCollided;
        SnakeHead.CircleCollect += OnCircleCollected;
    }

    private void OnDisable()
    {
        SnakeHead.BlockCollided -= OnBlockCollided;
        SnakeHead.CircleCollect -= OnCircleCollected;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        else if (Input.GetMouseButtonUp(0))
            sidewaysSpeed = 0;
        else if (Input.GetMouseButton(0))
        {
            delta = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        if (block)
        {
            block = false;
            componentRigidbody.AddForce(new Vector2(0, -impulse), ForceMode2D.Impulse);
        }
        else
        {
            if (Mathf.Abs(sidewaysSpeed) > 4)
                sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);

            componentRigidbody.velocity = new Vector2(sidewaysSpeed * 5, forwardSpeed);
            sidewaysSpeed = 0;
        }
    }

    public void OnBlockCollided()
    {
        if (SnakeLength > 0)
        {
            SnakeLength--;
            componentSnakeTail.RemoveTail();
            pointsText.SetText(SnakeLength.ToString());
        }
        else
        {
            if (Score.instance.typeChallenge == ChallengesTypes.NoType)
                UiManager.instance.GameOver();
            else
                UiManager.instance.FailedChallenge();
        }
    }

    private void OnCircleCollected(int circleSize)
    {
        for (int i = 0; i < circleSize; i++)
        {
            SnakeLength++;
            TotalSnakeLength++;
            componentSnakeTail.AddTail();
            pointsText.SetText(SnakeLength.ToString());
        }

        SkinsManager.instance.SetSkin(SnakeSkin);
    }

    public void ReviveSnake(int length)
    {
        for (int i = 0; i < length; i++)
        {
            SnakeLength++;
            componentSnakeTail.AddTail();
            pointsText.SetText(SnakeLength.ToString());
        }

        SkinsManager.instance.SetSkin(SnakeSkin);
    }
}