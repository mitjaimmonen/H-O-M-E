using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePieces : MonoBehaviour
{
    public Shape shape = Shape.Circle;
    public float attractDistance = 1f;
    public float snapDistance = 0.25f;
    public bool Occupied;

    private float size = 1f;
    private CircleCollider2D col;

    public void InstantiateShapePiece(Shape in_shape, float in_size, Vector2 position)
    {
        col = GetComponent<CircleCollider2D>();
        size = in_size;
        shape = in_shape;

        transform.localScale = new Vector3(size,size,size);
        transform.position = new Vector3(position.x,position.y, 2f);

        SetShapeVisual();
    }

    void SetShapeVisual()
    {
        foreach(var item in GetComponentsInChildren<Transform>(true))
        {
            if (item.gameObject.name == shape.ToString())
            {
                item.gameObject.SetActive(true);
            }
            else if (item.gameObject != gameObject)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if (Occupied)
            return;
        
        ShapePieces piece = col.GetComponent<ShapePieces>();
        if (piece && Mathf.Approximately(piece.size, size))
        {
            float magnitude = ((Vector2)col.transform.position - (Vector2)transform.position).magnitude;
            if (magnitude < snapDistance)
            {
                piece.SnugFit(this);
            }
            else if (magnitude < attractDistance)
            {
                piece.Attract(this, magnitude/attractDistance);
                
            }
        }
    }
    
    void DriftSlowly()
    {
        //random direction drift slowly
    }
    
    void Spawn()
    {
        
    }
}


