using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float acceleration;
    public float deacceleration;

    private Vector2 velModifier;
    private Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            velModifier.x = Input.GetAxis("Horizontal");

        }
        else
        {
            velModifier.x = 0;
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            velModifier.y = Input.GetAxis("Vertical");
        }
        else
        {
            velModifier.y = 0;
        }
    }
}
