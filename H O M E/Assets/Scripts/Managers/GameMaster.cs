using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public Image FadeOverlay;
    public Color FadeColor;

    public CameraHandler mainCamera;
    private PhraseManager phraseManager;
    public PhraseManager PhraseManager
    {
        get
        {
            if (!phraseManager)
            {
                phraseManager = Camera.main.GetComponentInChildren<PhraseManager>();
            }
            return phraseManager;
        }
    }

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


    bool g;
    bool a;
    bool m;
    bool e;
    bool gameOverInAction;

    private void Awake()
    {
        // SceneManager.activeSceneChanged += SceneChanged;
        StartCoroutine(FadeIn());
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
        spawner = GetComponent<Spawner>();
        spawner.PoolActors();
    }

    //void SceneChanged(Scene oldScene, Scene newScene)
    //{
    //    StartCoroutine(FadeIn());
    //    spawner = GetComponent<Spawner>();
    //    if (spawner)
    //        spawner.PoolActors();
    //}

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
        if (Player.FindablePieces.Count == 0 && Player.ActiveShapePieces.Count == 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.G))
            g = true;
        if (Input.GetKeyDown(KeyCode.A))
            a = true;
        if (Input.GetKeyDown(KeyCode.M))
            m = true;
        if (Input.GetKeyDown(KeyCode.E))
            e = true;

        if (g && a && m && e)
            GameOver();
    }


    IEnumerator FadeIn()
    {
        FadeOverlay.color = Color.black;
        FadeOverlay.enabled = true;
        float t = 0;
        while (t <= 1f)
        {
            FadeOverlay.color = Color.Lerp(FadeColor, Color.clear, t);
            t += Time.deltaTime;
            yield return null;
        }

        FadeOverlay.enabled = false;

        yield break;
    }


    void GameOver()
    {
        if (!gameOverInAction)
        {
            gameOverInAction = true;
            Debug.Log("Game is Over");
            StartCoroutine(GameOverLoop());
        }
    }

    IEnumerator GameOverLoop()
    {
        FadeOverlay.color = Color.clear;
        FadeOverlay.enabled = true;
        float t = 0;

        //Call first end text.
        GameMaster.Instance.PhraseManager.DisplayEndPhrases();
        yield return new WaitForSeconds(1.75f);
        //Call second/third end text.

        while (t <= 2f)
        {
            FadeOverlay.color = Color.Lerp(Color.clear, FadeColor, t/2f);
            t += Time.deltaTime;
            yield return null;
        }

        //Shows "home"
        yield return new WaitForSeconds(5f);

        //GOes to credits
        SceneManager.LoadScene("Credits");
    }
}
