using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform snakeTail;
    public float tailDiameter;

    private List<Transform> Tail = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();

    private void Awake()
    {
        positions.Add(snakeTail.position);
    }
     
    private void Update()
    {
        float distance = ((Vector2) snakeTail.position - positions[0]).magnitude;

        if (distance > tailDiameter)
        {
            // Направление от старого положения головы, к новому
            Vector2 direction = ((Vector2) snakeTail.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * tailDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= tailDiameter;
        }

        for (int i = 0; i < Tail.Count; i++)
            Tail[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / tailDiameter);
    }

    public void AddTail()
    {
        Transform tail = Instantiate(snakeTail, positions[positions.Count - 1], Quaternion.identity, transform);
        Tail.Add(tail);
        positions.Add(tail.position);
    }

    public void RemoveTail()
    {
        Destroy(Tail[0].gameObject);
        Tail.RemoveAt(0);
        positions.RemoveAt(1);
    }
}