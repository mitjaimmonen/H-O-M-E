using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float yOffset;
    private Player player;
    private Vector2 lookAtPos = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        lookAtPos = Vector2.zero;
        var temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
        if (player && player.MasterPiece)
        {
            lookAtPos = player.MasterPiece.transform.position;
            transform.position = new Vector3(lookAtPos.x, lookAtPos.y + yOffset, transform.position.z);
        }
    }

    void Update()
    {
        if (player.MasterPiece == null)
            return;
        lookAtPos = player.MasterPiece.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(lookAtPos.x, lookAtPos.y + yOffset, transform.position.z), Time.deltaTime *5f);
    }

    public void TransformToRightEdge()
    {
       
        transform.position = new Vector3(transform.position.x + 97f, transform.position.y, transform.position.z);
        lookAtPos = player.MasterPiece.transform.position;
       
    }

    public void TransformToLeftEdge()
    {
        transform.position = new Vector3(transform.position.x - 97f, transform.position.y, transform.position.z);
        lookAtPos = player.MasterPiece.transform.position;

    }

    public void TransformToUpEdge()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 97f, transform.position.z);
        lookAtPos = player.MasterPiece.transform.position;

    }

    public void TransformToDownEdge()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 97f, transform.position.z);
        lookAtPos = player.MasterPiece.transform.position;

    }
}
