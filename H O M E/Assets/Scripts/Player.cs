using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Vector2 velModifier;
    private bool moveInput;

    private ShapePieces masterPiece;
    public ShapePieces MasterPiece
    {
        get { return masterPiece; }
        set
        {
            SetMasterPiece(masterPiece, value);
        }
    }
    private List<ShapePieces> activeShapes = new List<ShapePieces>();
    public List<ShapePieces> ActiveShapePieces
    {
        get
        {
            return activeShapes;
        }
    }
    private List<ShapePieces> shapes = new List<ShapePieces>();
    public List<ShapePieces> ShapePieces
    {
        get
        {
            shapes = GameMaster.Instance.ListOfPieces();

            return shapes;
        }
    }

    public void UpdateActivePieces()
    {
        activeShapes.Clear();
        for (int i = 0; i < ShapePieces.Count; i++)
        {
            if (ShapePieces[i].AllowControl)
            {
                activeShapes.Add(ShapePieces[i]);
                if (MasterPiece == null || !MasterPiece.AllowControl)
                    MasterPiece = ShapePieces[i];
            }
        }
    }

    private void SwitchMasterPiece()
    {
        if (ActiveShapePieces.Count > 1)
        {
            if (MasterPiece == null || !MasterPiece.AllowControl)
            {
                MasterPiece = ActiveShapePieces[0];
            }
            else
            {
                int curIndex = ActiveShapePieces.IndexOf(MasterPiece);
                curIndex++;
                if (curIndex < ActiveShapePieces.Count)
                    MasterPiece = ActiveShapePieces[curIndex];
                else
                    MasterPiece = ActiveShapePieces[0];
            }
        }
    }

    private void SetMasterPiece(ShapePieces currentPiece, ShapePieces newPiece)
    {
        masterPiece = newPiece;

        if (currentPiece != null)
        {
            currentPiece.IsMaster = false;
        }
        newPiece.IsMaster = true;

    }

    void Awake()
    {
        //REPLACE WITH GAMEMASTER GETTER WHICH KNOWS ALL SHAPE PIECES
        //GameObject[] temp = GameObject.FindGameObjectsWithTag("ShapePiece");
        //List<ShapePieces> pieces = new List<ShapePieces>();
        //foreach(var piece in temp)
        //{
        //    shapes.Add(piece.GetComponent<ShapePieces>());
        //}
        UpdateActivePieces();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        ApplyVelocity();
    }

    void HandleInput()
    {
        moveInput = false;
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            velModifier.x = Input.GetAxis("Horizontal");
            moveInput = true;
        }
        else
        {
            velModifier.x = 0;
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            velModifier.y = Input.GetAxis("Vertical");
            moveInput = true;
        }
        else
        {
            velModifier.y = 0;
        }


        if (Input.GetButtonDown("Jump"))
        {
            SwitchMasterPiece();
        }
    }

    void ApplyVelocity()
    {
        for (int i = 0; i < ShapePieces.Count; i++)
        {
            if (ShapePieces[i].AllowControl)
            {
                //Always apply deacceleration
                ShapePieces[i].Move(-ShapePieces[i].rb.velocity, false);

                if (moveInput)
                {
                    //Acceleration when there is input
                    ShapePieces[i].Move(velModifier, true);
                }
            }
        }
    }

    public void TransformToRightEdge()
    {
        foreach (ShapePieces shape in activeShapes)
        {
            shape.transform.position = new Vector3(shape.transform.position.x + 87, shape.transform.position.y, shape.transform.position.z);
        }
        GameMaster.Instance.mainCamera.TransformToRightEdge();
    }

    public void TransformToLeftEdge()
    {
        foreach (ShapePieces shape in activeShapes)
        {
            shape.transform.position = new Vector3(shape.transform.position.x - 87, shape.transform.position.y, shape.transform.position.z);
        }
        GameMaster.Instance.mainCamera.TransformToLeftEdge();
    }

    public void TransformToUpEdge()
    {
        foreach (ShapePieces shape in activeShapes)
        {
            shape.transform.position = new Vector3(shape.transform.position.x, shape.transform.position.y + 87, shape.transform.position.z);
        }
        GameMaster.Instance.mainCamera.TransformToUpEdge();
    }

    public void TransformToDownEdge()
    {
        foreach (ShapePieces shape in activeShapes)
        {
            shape.transform.position = new Vector3(shape.transform.position.x, shape.transform.position.y - 87, shape.transform.position.z);
        }
        GameMaster.Instance.mainCamera.TransformToDownEdge();
    }


}

        masterPiece = newPiece;

        if (currentPiece != null && currentPiece.IsMaster)
    }

    public void PieceSnugFit(ShapePieces piece)
    {
        if (masterPiece == null || piece.IsMaster || piece == masterPiece)
            SwitchMasterPiece();

        if (ActiveShapePieces.Count == 0)
        {
            GameMaster.Instance.AssignPiece(2f);
        }
    }

    public void TransformToRightEdge()
    {
        foreach (ShapePieces shape in activeShapes)
        {
            shape.transform.position = new Vector3(shape.transform.position.x + 87, shape.transform.position.y, shape.transform.position.z);
        }
        GameMaster.Instance.mainCamera.TransformToRightEdge();
    }

    public void TransformToLeftEdge()
    {
        foreach (ShapePieces shape in activeShapes)
        {
            shape.transform.position = new Vector3(shape.transform.position.x - 87, shape.transform.position.y, shape.transform.position.z);
        }
        GameMaster.Instance.mainCamera.TransformToLeftEdge();
    }

    public void TransformToUpEdge()
    {
        foreach (ShapePieces shape in activeShapes)
        {
            shape.transform.position = new Vector3(shape.transform.position.x, shape.transform.position.y + 87, shape.transform.position.z);
        }
        GameMaster.Instance.mainCamera.TransformToUpEdge();
    }

    public void TransformToDownEdge()
    {
        foreach (ShapePieces shape in activeShapes)
        {
            shape.transform.position = new Vector3(shape.transform.position.x, shape.transform.position.y - 87, shape.transform.position.z);
        }
        GameMaster.Instance.mainCamera.TransformToDownEdge();
    }

