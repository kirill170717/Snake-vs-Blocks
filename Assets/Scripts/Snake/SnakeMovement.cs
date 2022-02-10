using TMPro;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float forwardSpeed = 5;
    public float sensitivity = 50;
    public int length = 0;

    public TMP_Text pointsText;

    private Camera mainCamera;
    private Rigidbody2D componentRigidbody;
    private SnakeHead head;
    private SnakeTail componentSnakeTail;

    private Vector2 touchLastPos;
    private float sidewaysSpeed;

    private void Awake()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody2D>();
        componentSnakeTail = GetComponent<SnakeTail>();
        head = GetComponent<SnakeHead>();

        for (int i = 0; i < length; i++)
            componentSnakeTail.AddTail();

        pointsText.SetText(length.ToString());
    }

    private void OnEnable()
    {
        head.BlockCollided += OnBlockCollided;
        head.CircleCollect += OnCircleCollected;
    }

    private void OnDisable()
    {
        head.BlockCollided -= OnBlockCollided;
        head.CircleCollect -= OnCircleCollected;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        else if (Input.GetMouseButtonUp(0))
            sidewaysSpeed = 0;
        else if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2) mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) > 4)
            sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);

        componentRigidbody.velocity = new Vector2(sidewaysSpeed * 5, forwardSpeed);
        sidewaysSpeed = 0;
    }

    private void OnBlockCollided()
    {
        if(length > 0)
        {
            length--;
            componentSnakeTail.RemoveTail();
            pointsText.SetText(length.ToString());
        }
    }

    private void OnCircleCollected(int circleSize)
    {
        for(int i = 0; i < circleSize; i++)
        {
            length++;
            componentSnakeTail.AddTail();
            pointsText.SetText(length.ToString());
        }
    }
}