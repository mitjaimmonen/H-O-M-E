using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shape
{
    Circle,
    Triangle,
    Square,
    Pentagon,
    Hexagon
}
public class ShapePieces : MonoBehaviour
{
    public Shape shape = Shape.Circle;
    public float attractForce = 5f;
    public bool allowControl = true;
    public Rigidbody2D rb;
    public float size = 1f;

    private Collider2D col;


    public void InstantiateShapePiece(Shape in_shape, float in_size, Vector2 position)
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        size = in_size;
        shape = in_shape;

        transform.localScale = new Vector3(size,size,size);
        transform.position = new Vector3(position.x,position.y, 0f);
        rb.mass = size;

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

    public void SnugFit(HomePieces homePieces)
    {
        if (!allowControl)
            return;
        
        if (homePieces.shape == shape)
        {
            DisablePiece();
            transform.position = new Vector3(homePieces.transform.position.x, homePieces.transform.position.y, transform.position.z);
            homePieces.Occupied = true;
        }
    }

    void DisablePiece()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        allowControl = false;
        col.enabled = false;
    }

    public void Attract(HomePieces homePieces, float distance01)
    {
        if (!allowControl)
            return;

        Vector2 dir = (Vector2)homePieces.transform.position - (Vector2)transform.position;
        dir.Normalize();

        if (homePieces.shape == shape)
        {
            rb.AddForce(dir*attractForce * Time.deltaTime * (1f-distance01));
        }
    }



}
