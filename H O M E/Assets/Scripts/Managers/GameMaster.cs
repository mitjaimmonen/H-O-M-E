using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public CameraHandler mainCamera;
    Spawner spawner;
    public Spawner GetSpawner
    {
        get { return spawner; }
    }
    List<HomePieces> HomePieces = new List<HomePieces>();

    private Player player;
    public Player Player
    {
        get {
            if (!player)
            {
                var temp = GameObject.FindGameObjectWithTag("Player");
                if (temp)
                    player = temp.GetComponent<Player>();
            }
            return player;
        }
    }

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

    public void AssignPiece(float delay)
    {
        StartCoroutine(AssigningPiece(delay));
    }

    IEnumerator AssigningPiece(float delay)
    {
        yield return new WaitForSeconds(delay);
        Player.MasterPiece = spawner.AssignPiece();
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
