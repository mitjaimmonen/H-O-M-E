using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Player player;
    private Vector2 lookAtPos = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        lookAtPos = Vector2.zero;
        var temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
    }

    void Update()
    {
        if (player.ShapePieces == null || player.ActiveShapePieces.Count < 1)
            return;

        lookAtPos = Vector2.zero;
        int index = 0;
        for(int i = 0; i < player.ActiveShapePieces.Count; i++)
        {
            lookAtPos += (Vector2)player.ActiveShapePieces[i].transform.position;
            Debug.Log(lookAtPos);
            index++;
        }
        lookAtPos /= index;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(lookAtPos.x, lookAtPos.y, transform.position.z), Time.deltaTime *5f);
    }

    public void TransformToRightEdge()
    {
       
        transform.position = new Vector3(transform.position.x + 87, transform.position.y, transform.position.z);
       
    }

    public void TransformToLeftEdge()
    {
        transform.position = new Vector3(transform.position.x - 87, transform.position.y, transform.position.z);

    }

    public void TransformToUpEdge()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 87, transform.position.z);

    }

    public void TransformToDownEdge()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 87, transform.position.z);

    }
}
