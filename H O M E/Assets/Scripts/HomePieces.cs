using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePieces : MonoBehaviour
{
    public Shape shape = Shape.Circle;
    public float attractDistance = 1f;
    public float attractForce = 1f;
    public float snapDistance = 0.25f;
    public float driftSpeed;
    public bool Occupied;

    public List<GameObject> CirclePrefabs;
    public List<GameObject> BlobPrefabs;
    public List<GameObject> DiamondPrefabs;
    public List<GameObject> TrianglePrefabs;
    public List<GameObject> ZigZagPrefabs;
    public List<GameObject> ArrowPrefabs;
    public List<GameObject> OctahedronPrefabs;
    public List<GameObject> HexagonPrefabs;
    public List<GameObject> squarePrefabs;

    GameObject shapeVisual;

    private float size = 1f;
    private CircleCollider2D col;

    public void Instantiate(Shape in_shape, Vector2 position)
    {
        col = GetComponent<CircleCollider2D>();
        shape = in_shape;

        transform.localScale = new Vector3(size,size,size);
        transform.position = new Vector3(position.x,position.y, 2f);

        SetShapeVisual();
    }

    void SetShapeVisual()
    {
        switch (shape)
        {
            case Shape.Circle :
                shapeVisual = Instantiate(CirclePrefabs[Random.Range(0,CirclePrefabs.Count)], transform.position, transform.rotation);
            break;
            case Shape.Blob :
                shapeVisual = Instantiate(BlobPrefabs[Random.Range(0,BlobPrefabs.Count)], transform.position, transform.rotation);
            break;
            case Shape.Diamond :
                shapeVisual = Instantiate(DiamondPrefabs[Random.Range(0,DiamondPrefabs.Count)], transform.position, transform.rotation);
            break;
            case Shape.Triangle :
                shapeVisual = Instantiate(TrianglePrefabs[Random.Range(0,TrianglePrefabs.Count)], transform.position, transform.rotation);
            break;
            case Shape.ZigZag :
                shapeVisual = Instantiate(ZigZagPrefabs[Random.Range(0,ZigZagPrefabs.Count)], transform.position, transform.rotation);
            break;
            case Shape.Arrow :
                shapeVisual = Instantiate(ArrowPrefabs[Random.Range(0,ArrowPrefabs.Count)], transform.position, transform.rotation);
            break;
            case Shape.Octahedron :
                shapeVisual = Instantiate(OctahedronPrefabs[Random.Range(0,OctahedronPrefabs.Count)], transform.position, transform.rotation);
            break;
            case Shape.Hexagon :
                shapeVisual = Instantiate(HexagonPrefabs[Random.Range(0,HexagonPrefabs.Count)], transform.position, transform.rotation);
            break;
            case Shape.Square :
                shapeVisual = Instantiate(squarePrefabs[Random.Range(0,squarePrefabs.Count)], transform.position, transform.rotation);
            break;
            
            default:
            break;
        }
    
        if (shapeVisual)
            shapeVisual.transform.parent = transform;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Occupied)
            return;
        
        ShapePieces piece = col.GetComponentInParent<ShapePieces>();
        if (piece)
        {
            float magnitude = ((Vector2)col.transform.position - (Vector2)transform.position).magnitude;
            if (magnitude < snapDistance && Quaternion.Angle(transform.rotation, piece.transform.rotation) < 10f)
            {
                piece.SnugFit(this);
            }
            else if (magnitude < attractDistance)
            {
                piece.GetAttracted(this, ((attractDistance-magnitude)/attractDistance) * attractForce, magnitude/attractDistance);
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


