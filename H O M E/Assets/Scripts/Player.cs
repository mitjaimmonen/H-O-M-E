using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shape
{
    round,
    triangle,
    square,
    pentagon,
    hexagon
}

public class Player : MonoBehaviour
{
    public Shape shape = Shape.round;
    public float speed = 5f;
    public float acceleration = 5f;
    public float deacceleration = 2f;
    public float attractForce = 5f;

    private bool allowControl = true;
    private Vector2 velModifier;
    private bool moveInput;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allowControl)
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
        rb.AddForce(-rb.velocity * deacceleration);

        if (moveInput)
        {
            rb.AddForce(velModifier * acceleration);
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
    }

    public void SnugFit(HomePieces homePieces)
    {
        if (homePieces.shape == shape)
        {
            transform.position = new Vector3(homePieces.transform.position.x, homePieces.transform.position.y, transform.position.z);
            velModifier = Vector2.zero;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            allowControl = false;
        }
    }

    public void Attract(HomePieces homePieces, float distance01)
    {
        Vector2 dir = (Vector2)homePieces.transform.position - (Vector2)transform.position;
        dir.Normalize();

        if (homePieces.shape == shape)
        {
            rb.AddForce(dir*attractForce * Time.deltaTime * (1f-distance01));
        }
    }

}
