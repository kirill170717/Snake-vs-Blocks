using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public GameObject snakeTail;
    public float tailDiameter;

    private List<Transform> Tail = new List<Transform>();
    private List<Vector2> Positions = new List<Vector2>();

    private Vector2 direction;
    private GameObject tail;
    private Color color;

    private void Awake()
    {
        Positions.Add(snakeTail.transform.position);
        color = snakeTail.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        float distance = ((Vector2)snakeTail.transform.position - Positions[0]).magnitude;

        if (distance > tailDiameter)
        {
            direction = ((Vector2)snakeTail.transform.position - Positions[0]).normalized;

            Positions.Insert(0, Positions[0] + direction * tailDiameter);
            Positions.RemoveAt(Positions.Count - 1);

            distance -= tailDiameter;
        }

        for (int i = 0; i < Tail.Count; i++)
            Tail[i].position = Vector2.Lerp(Positions[i + 1], Positions[i], distance / tailDiameter);
    }

    public void AddTail()
    {
        color.a = 1;
        tail = Instantiate(snakeTail, Positions[Positions.Count - 1], Quaternion.identity, transform);
        tail.name = snakeTail.name;
        tail.GetComponent<SpriteRenderer>().color = color;
        Tail.Add(tail.transform);
        Positions.Add(tail.transform.position);
    }

    public void RemoveTail()
    {
        Destroy(Tail[0].gameObject);
        Tail.RemoveAt(0);
        Positions.RemoveAt(1);
    }
}