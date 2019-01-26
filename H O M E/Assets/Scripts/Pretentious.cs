using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pretentious : MonoBehaviour
{
    public GameObject animArrow;

    public void IntroFinish()
    {
        var temp = GameObject.FindGameObjectWithTag("GameController");
        if (temp)
        {
            GetComponent<Animator>().enabled = false;
            animArrow.SetActive(false);
            Debug.Log("Found master");
            var master = temp.GetComponent<MenuMaster>();
            master.IntroFinish();
        }
    }
}
