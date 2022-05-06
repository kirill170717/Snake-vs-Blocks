using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public GameObject head;
    public GameObject snakeTail;
    public GameObject target;
    public float tailDiameter;

    private List<Transform> Snake = new List<Transform>();
    private List<Vector3> Positions = new List<Vector3>();

    private Vector3 direction;
    private GameObject tail;
    private Color color;

    private void Awake()
    {
        Positions.Add(target.transform.position);
        Snake.Add(snakeTail.transform);
        Positions.Add(snakeTail.transform.position);
        color = snakeTail.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {

        float distance = (snakeTail.transform.position - Positions[0]).magnitude;

        if (distance > tailDiameter)
        {
            direction = (snakeTail.transform.position - Positions[0]).normalized;

            Positions.Insert(0, Positions[0] + direction * tailDiameter);
            Positions.RemoveAt(Positions.Count - 1);

            distance -= tailDiameter;
        }

        target.transform.position = Vector2.Lerp(Positions[1], Positions[0], distance / tailDiameter);
        head.transform.rotation = Quaternion.Euler(0, 0, 90) *
                Quaternion.AngleAxis(GetAngle(snakeTail.transform.position, target.transform.position), Vector3.forward);

        for (int i = 1; i < Snake.Count; i++)
        {
            Snake[i].position = Vector2.Lerp(Positions[i], Positions[i - 1], distance / tailDiameter);
            Snake[i].transform.rotation = Quaternion.Euler(0, 0, -90) *
                Quaternion.AngleAxis(GetAngle(Snake[i].transform.position, Snake[i - 1].transform.position), Vector3.forward);
        }
    }

    private float GetAngle(Vector3 infrom, Vector3 into)
    {
        Vector2 from = Vector2.right;
        Vector3 to = into - infrom;

        float ang = Vector2.Angle(from, to);
        Vector3 cross = Vector3.Cross(from, to);

        if (cross.z > 0)
            ang = 360 - ang;

        ang *= -1f;

        return ang;
    }

    public void AddTail()
    {
        color.a = 1;
        tail = Instantiate(snakeTail, Positions[Positions.Count - 1], Quaternion.identity, transform);
        tail.name = snakeTail.name;
        tail.GetComponent<SpriteRenderer>().color = color;
        Snake.Add(tail.transform);
        Positions.Add(tail.transform.position);
    }

    public void RemoveTail()
    {
        Destroy(Snake[1].gameObject);
        Snake.RemoveAt(1);
        Positions.RemoveAt(2);
    }
}