using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public Shape shape = Shape.round;
    public float attractDistance = 1f;
    public float snapDistance = 0.25f;
    
    void OnTriggerStay2D(Collider2D col)
    {
        float magnitude = ((Vector2)col.transform.position - (Vector2)transform.position).magnitude;
        if (magnitude < snapDistance)
        {
            if (col.GetComponent<Player>())
            {
                col.GetComponent<Player>().SnugFit(this);
            }
        }
        else if (magnitude < attractDistance)
        {
            if (col.GetComponent<Player>())
            {
                col.GetComponent<Player>().Attract(this, magnitude/attractDistance);
            }
        }
    }
}
