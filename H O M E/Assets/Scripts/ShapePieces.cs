using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shape
{
    Circle,
    Blob,
    Diamond,
    Triangle,
    ZigZag,
    Arrow,
    Octahedron,
    Hexagon,
    Square
}
public class ShapePieces : MonoBehaviour
{
    public bool debugInstantiate = false;
    public bool debugControl = false;
    public bool debugShapeChange = false;
    public float snapOffDistance = 10f;
    public float changeShapeInterval = 45f;
    public Shape shape = Shape.Circle;
    public SkinnedMeshRenderer meshRenderer;
    public GameObject shapeDataParent;
    public float attractDistance = 5f;
    public float attractForce = 50f;
    public Material plebMat;
    public Material masterMat;

    private float intervalTimer;
    private Player player;

    float sine1;
    float sine2;
    float sine3;
    public float magnitude = 0.34f;
    public float sine1M = 0.27f;
    public float sine2M = 0.85f;
    public float sine3M = 0.72f;
    public Vector3 startPos;

    private bool isMaster = false;
    public bool IsMaster
    {
        get { return isMaster; }
        set
        {
            isMaster = value;
            UpdateMaterials();
        }
    }
    private bool allowControl = false;
    public bool AllowControl
    {
        get { return allowControl; }
        set
        {
            Debug.Log("player is " + player);
            allowControl = value;
            if (player)
                player.UpdateActivePieces();
        }
    }
    public Rigidbody2D rb;


    private bool _snugFit;
    public bool snugFit
    {
        get { return _snugFit; }
        set
        {
            _snugFit = value;
            if (player)
                player.UpdateFindablePieces();
        }
    }
    private Collider2D col;
    private ShapeData shapeData;
    private Shape oldShape;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        intervalTimer = Time.time + Random.Range(0f,changeShapeInterval);
        if (!player)
        {
            var temp = GameObject.FindGameObjectWithTag("Player");
            if (temp)
                player = temp.GetComponent<Player>();
        }
        if (debugInstantiate)
        {
            Instantiate(shape, transform.position);
        }
        if (debugControl)
        {
            AllowControl = true;
        }       
    }

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        UpdateShapes();
        if (IsMaster)
        {
            checkForBoundaries();
        }
        else if (AllowControl)
        {
            CheckDistanceToMaster();
        }
        if (oldShape != shape)
        {
            SetShapeData();
        }
        if (!IsMaster && !AllowControl && !snugFit)
        {
            ShuffleAbout();
        }
        if (snugFit)
        {
            meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, Color.black, Time.deltaTime);
        }
        else
        {
            if (intervalTimer+changeShapeInterval < Time.time || debugShapeChange)
            {
                if (Random.Range(0f,100f) > 50f || debugShapeChange)
                {
                    shape = (Shape)Random.Range(0,System.Enum.GetNames(typeof(Shape)).Length);
                    intervalTimer = Time.time;
                    debugShapeChange = false;
                    if (AllowControl)
                        GameMaster.Instance.PhraseManager.DisplayTooLongPhrase();
                }
            }
        }

        Deaccelerate();

        
    }

    public void Instantiate(Shape in_shape, Vector2 position)
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        oldShape = shape;
        shape = in_shape;

        transform.position = new Vector3(position.x,position.y, 0f);

        SetShapeData();
        UpdateShapes();
    }

    void SetShapeData()
    {
        foreach(var item in shapeDataParent.GetComponentsInChildren<ShapeData>(true))
        {
            if (item.gameObject.name == shape.ToString() && !snugFit)
            {
                shapeData = item;
                rb.mass = shapeData.mass;
                oldShape = shape;
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    void UpdateShapes()
    {
        if (shapeData == null)
        {
            Debug.LogWarning("ShapeData is null");
            return;
        }
            
        if (shape != Shape.Square && meshRenderer.GetBlendShapeWeight((int)shape) != 100f)
        {
            meshRenderer.SetBlendShapeWeight((int)shape, Mathf.Lerp(meshRenderer.GetBlendShapeWeight((int)shape), 100f, Time.deltaTime));
            if (meshRenderer.GetBlendShapeWeight((int)shape) > 98f)
            {
                meshRenderer.SetBlendShapeWeight((int)shape, 100f);
            }
        }

        for(int i = 0; i < System.Enum.GetNames(typeof(Shape)).Length; i++)
        {
            if (i != (int)Shape.Square && i != (int)shape && meshRenderer.GetBlendShapeWeight(i) != 0)
            {
                meshRenderer.SetBlendShapeWeight(i, Mathf.Lerp(meshRenderer.GetBlendShapeWeight(i), 0, Time.deltaTime));
                
                if (meshRenderer.GetBlendShapeWeight(i) < 2f)
                {
                    meshRenderer.SetBlendShapeWeight(i, 0);
                }
            }
        }
        // if (!Mathf.Approximately(shapeData.size,transform.localScale.x))
        // {
        //     transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * shapeData.size, Time.deltaTime);
        // }
    }

    void UpdateMaterials()
    {
        GetComponentInChildren<SkinnedMeshRenderer>().material = IsMaster ? masterMat : plebMat;
    }

    public void checkForBoundaries()
    {
        if (transform.position.x <= -15)
            player.TransformToRightEdge();
        if (transform.position.x >= 95)
            player.TransformToLeftEdge();
        if (transform.position.y <= -15)
            player.TransformToUpEdge();
        if (transform.position.y >= 95)
            player.TransformToDownEdge();
    }

    public void CheckDistanceToMaster()
    {
        if ((transform.position-player.MasterPiece.transform.position).magnitude > snapOffDistance)
        {
            AllowControl = false;
            GameMaster.Instance.PhraseManager.DisplayLoseFriendPhrase();
        }
    }

    public void Move(Vector2 velModifier)
    {
        if (shapeData == null)
            return;
            
        rb.AddForce(velModifier * shapeData.acceleration * Time.fixedDeltaTime);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, shapeData.maxSpeed);

    }

    void Deaccelerate()
    {
        if (shapeData)
            rb.AddForce(-rb.velocity * shapeData.deacceleration * Time.fixedDeltaTime);

    }

    public void SnugFit(HomePieces homePieces)
    {
        if (homePieces.shape == shape)
        {
            DisablePiece();
            transform.position = new Vector3(homePieces.transform.position.x, homePieces.transform.position.y, 1f);
            transform.rotation = homePieces.transform.rotation;

            homePieces.Occupied = true;
            snugFit = true;
            player.PieceSnugFit(this);
            GameMaster.Instance.PhraseManager.DisplayFindHomePhrase();
        }
    }

    void DisablePiece()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.simulated = false;
        rb.isKinematic = true;            
        AllowControl = false;
        IsMaster = false;
        if (shapeData)
            shapeData.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ShapePieces shape = col.gameObject.GetComponent<ShapePieces>();
        if (AllowControl && shape != null)
        {
            if (!shape.AllowControl)
            {
                GameMaster.Instance.PhraseManager.DisplayFindFriendPhrase();
                shape.AllowControl = true;
            }
            

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (AllowControl && col.gameObject.GetComponent<ShapePieces>() != null)
        {
            ShapePieces piece = col.gameObject.GetComponent<ShapePieces>();
            float magnitude = ((Vector2)col.transform.position - (Vector2)transform.position).magnitude;
            if (magnitude < attractDistance)
            {
                piece.GetAttracted(this, magnitude/attractDistance * attractForce);
            }
            
        }
    }

    public void GetAttracted(HomePieces homePieces, float force, float magnitude01)
    {
        if (!AllowControl || snugFit)
            return;

        Vector2 dir = (Vector2)homePieces.transform.position - (Vector2)transform.position;
        dir.Normalize();

        if (homePieces.shape == shape)
        {
            rb.AddForce(dir * Time.deltaTime * force);
            transform.rotation = Quaternion.Slerp(transform.rotation, homePieces.transform.rotation, Time.deltaTime * (1f-magnitude01));
        }
        else if (magnitude01 < 0.1f)
        {
            GameMaster.Instance.PhraseManager.DisplayWrongHomePhrase();
        }
    }

    public void GetAttracted(ShapePieces shapePiece, float force)
    {
        if (!AllowControl)
            return;

        Vector2 dir = (Vector2)shapePiece.transform.position - (Vector2)transform.position;
        dir.Normalize();

        if (shapePiece.shape == shape)
        {
            rb.AddForce(dir * Time.deltaTime * force);
        }
    }

    void ShuffleAbout()
    {
        sine1 = Mathf.Sin(Time.time * sine1M);
        sine2 = Mathf.Sin(Time.time * sine2M);
        sine3 = Mathf.Sin(Time.time * sine3M);

        transform.position = (startPos + new Vector3(sine1 * sine2 * magnitude, sine2 * sine3 * magnitude, 0));
    }
    
}
