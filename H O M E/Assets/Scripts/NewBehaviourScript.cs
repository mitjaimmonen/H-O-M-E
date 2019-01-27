using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float sine1;
    float sine2;
    float sine3;
    public float magnitude = 0.06f;
    public float sine1M;
    public float sine2M;
    public float sine3M;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sine1 = Mathf.Sin(Time.time*sine1M);
        sine2 = Mathf.Sin(Time.time*sine2M);
        sine3 = Mathf.Sin(Time.time*sine3M);

        transform.position = (startPos + new Vector3(sine1*sine2 * magnitude, sine2*sine3 * magnitude, 0));
    }
}
