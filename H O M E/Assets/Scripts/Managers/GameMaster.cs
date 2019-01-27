using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public CameraHandler mainCamera;
    Spawner spawner;
    List<HomePieces> HomePieces = new List<HomePieces>();

    private static GameMaster _instance;
    public static GameMaster Instance
    {
        get
        {
            return _instance;
        }
    }

    public List<ShapePieces> ListOfPieces()
    {
        return spawner.pieces;
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        spawner = GetComponent<Spawner>();
        spawner.PoolActors();
    }

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }
}
