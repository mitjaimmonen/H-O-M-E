using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Player player;
    private Vector2 lookAtPos;
    // Start is called before the first frame update
    void Start()
    {
        var temp = GameObject.FindGameObjectWithTag("Player");
        player = temp.GetComponent<Player>();
    }

    void Update()
    {
        lookAtPos = Vector2.zero;
        int index = 0;
        for(int i = 0; i < player.ShapePieces.Count; i++)
        {
            if (player.ShapePieces[i].allowControl)
            {
                lookAtPos += (Vector2)player.ShapePieces[i].transform.position;
                index++;
            }
        }
        lookAtPos /= index;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(lookAtPos.x, lookAtPos.y, transform.position.z), Time.deltaTime *5f);
    }
}
