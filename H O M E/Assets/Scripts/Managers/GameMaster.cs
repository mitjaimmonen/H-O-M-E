using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    Camera mainCamera;
    HoleSpawner HoleSpawner;
    List<HomePieces> HomePieces = new List<HomePieces>();

    private static GameMaster _instance;
    public static GameMaster Instance
    {
        get
        {
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
