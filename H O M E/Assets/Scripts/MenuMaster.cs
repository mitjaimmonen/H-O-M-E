using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMaster : MonoBehaviour
{
    public GameObject cursorObject;
    public Animator pretentious;
    public Material selectedMat;
    public Material inactiveMat;
    public GameObject startObj;
    public GameObject quitObj;
    public string sceneName;
    public bool controllable;

    Rigidbody2D cursorRb;
    bool startSelected;
    bool quitSelected;


    bool h;
    bool o;
    bool m;
    bool e;

    // Start is called before the first frame update
    void Start()
    {
        cursorObject.SetActive(false);
        cursorRb = cursorObject.GetComponent<Rigidbody2D>();
        controllable = false;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controllable)
        {
            var v3 = Input.mousePosition;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = -5f;
            Vector2 force = (v3 - cursorObject.transform.position) * 10f;
            // force = Vector2.ClampMagnitude(force, 100f);
            // cursorRb.AddForce(force * Time.deltaTime);
            // cursorRb.velocity = Vector2.ClampMagnitude(cursorRb.velocity, 8f);
            
            cursorObject.transform.right = -force.normalized;

            cursorObject.transform.position += Vector3.ClampMagnitude(Vector3.Lerp(cursorObject.transform.position, v3, Time.deltaTime *5f) - cursorObject.transform.position, 8f*Time.deltaTime);

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("CLick");
                if (startSelected)
                {
                    Debug.Log("Clicked Start");
                    StartGame();
                }
                else if (quitSelected)
                {
                    Debug.Log("Quit");
                    Application.Quit();
                }
            }
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Return))
            {
                StartGame();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
            h = true;
        if (Input.GetKeyDown(KeyCode.O))
            o = true;
        if (Input.GetKeyDown(KeyCode.M))
            m = true;
        if (Input.GetKeyDown(KeyCode.E))
            e = true;

        if (h && o && m && e)
        {
            pretentious.speed = 10f;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Credits");
        }
    }
    void FixedUpdate()
    {
        if (controllable)
        {
            Collider2D col = Physics2D.OverlapPoint((Vector2)(cursorObject.transform.position - cursorObject.transform.right*0.5f));
            Debug.Log(col);
            if (col != null)
            {
                if (col.gameObject == startObj)
                {
                    quitSelected = false;
                    startSelected = true;
                }
                if (col.gameObject == quitObj)
                {
                    startSelected = false;
                    quitSelected = true;
                }
            }
            else
            {
                startSelected = false;
                quitSelected = false;
            }
        }

        quitObj.GetComponent<MeshRenderer>().material = quitSelected ? selectedMat : inactiveMat;
        startObj.GetComponent<MeshRenderer>().material = startSelected ? selectedMat : inactiveMat;
    }

    void StartGame()
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void IntroFinish()
    {
        Debug.Log("Controllable now");
        cursorObject.SetActive(true);
        cursorObject.transform.position = new Vector3(cursorObject.transform.position.x,cursorObject.transform.position.y, -5f);
        controllable = true;
        cursorObject.transform.parent = null;
    }
}
