using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 5f;
    public float deacceleration = 2f;

    private Vector2 velModifier;
    private bool moveInput;

    private List<ShapePieces> shapes = new List<ShapePieces>();
    public List<ShapePieces> ShapePieces
    {
        get{
            //REPLACE WITH GAMEMASTER GETTER WHICH KNOWS ALL SHAPE PIECES
            return shapes;
        }
    }

    void Start()
    {
            //REPLACE WITH GAMEMASTER GETTER WHICH KNOWS ALL SHAPE PIECES
            GameObject[] temp = GameObject.FindGameObjectsWithTag("ShapePiece");
            List<ShapePieces> pieces = new List<ShapePieces>();
            foreach(var piece in temp)
            {
                shapes.Add(piece.GetComponent<ShapePieces>());
            }
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
    }

    void ApplyVelocity()
    {
        for(int i = 0; i < ShapePieces.Count; i++)
        {
            if (ShapePieces[i].allowControl)
            {
                ShapePieces[i].rb.AddForce(-ShapePieces[i].rb.velocity * deacceleration);

                if (moveInput)
                {
                    ShapePieces[i].rb.AddForce(velModifier * acceleration);
                }

                ShapePieces[i].rb.velocity = Vector2.ClampMagnitude(ShapePieces[i].rb.velocity, speed);
            }
        }
    }


}
