using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhraseManager : MonoBehaviour
{
    List<Sprite[]> tooLongSprites = new List<Sprite[]>();
    bool[] tooLongIndex;
    Sprite[] _TooLongBar;
    Sprite[] _TooLongBliss;
    Sprite[] _TooLongDinner;
    Sprite[] _TooLongTriumph;
    Sprite[] _TooLongJob;
    Sprite[] _TooLongPeace;
    Sprite[] _TooLongSurrealism;
    Sprite[] _TooLongWind;

    List<Sprite[]> findHomeSprites = new List<Sprite[]>();
    bool[] findHomeIndex;
    Sprite[] _FindHomeCry;
    Sprite[] _FindHomeLife;
    Sprite[] _FindHomeNothing;
    Sprite[] _FindHomeSimple;

    List<Sprite[]> findFriendSprites = new List<Sprite[]>();
    bool[] findFriendIndex;
    Sprite[] _FindFriendComfort;
    Sprite[] _FindFriendLess;
    Sprite[] _FindFriendOfc;
    Sprite[] _FindFriendSomething;
    Sprite[] _FindFriendTender;

    List<Sprite[]> loseFriendSprites = new List<Sprite[]>();
    bool[] loseFriendIndex;
    Sprite[] _LoseFriendAlone;
    Sprite[] _LoseFriendDisappear;
    Sprite[] _LoseFriendHappening;
    Sprite[] _LoseFriendLoved;
    Sprite[] _LoseFriendSmoke;
    Sprite[] _LoseFriendTime;

    Image phrase;

    private void Awake()
    {
        phrase = GetComponent<Image>();
        Color c = phrase.color;
        c.a = 0;
        phrase.color = c;
        phrase.enabled = false;
    }

    void Start()
    {
        LoadSprites();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPhrase();
    }

    void LoadSprites()
    {
        _LoseFriendAlone = Resources.LoadAll<Sprite>("Phrases/Losing a friend/alone");
        loseFriendSprites.Add(_LoseFriendAlone);
        _LoseFriendDisappear = Resources.LoadAll<Sprite>("Phrases/Losing a friend/disappear");
        loseFriendSprites.Add(_LoseFriendAlone);
        _LoseFriendHappening = Resources.LoadAll<Sprite>("Phrases/Losing a friend/happening");
        loseFriendSprites.Add(_LoseFriendAlone);
        _LoseFriendLoved = Resources.LoadAll<Sprite>("Phrases/Losing a friend/loved");
        loseFriendSprites.Add(_LoseFriendAlone);
        _LoseFriendSmoke = Resources.LoadAll<Sprite>("Phrases/Losing a friend/smoke");
        loseFriendSprites.Add(_LoseFriendAlone);
        _LoseFriendTime = Resources.LoadAll<Sprite>("Phrases/Losing a friend/time");
        loseFriendSprites.Add(_LoseFriendAlone);

        _FindFriendComfort = Resources.LoadAll<Sprite>("Phrases/Find a home/comfort");
        findFriendSprites.Add(_FindFriendComfort);
        _FindFriendLess = Resources.LoadAll<Sprite>("Phrases/Find a home/less3");
        findFriendSprites.Add(_FindFriendLess);
        _FindFriendOfc = Resources.LoadAll<Sprite>("Phrases/Find a home/ofc");
        findFriendSprites.Add(_FindFriendOfc);
        _FindFriendSomething = Resources.LoadAll<Sprite>("Phrases/Find a home/something");
        findFriendSprites.Add(_FindFriendSomething);
        _FindFriendTender = Resources.LoadAll<Sprite>("Phrases/Find a home/tender");
        findFriendSprites.Add(_FindFriendTender);

        _FindHomeCry = Resources.LoadAll<Sprite>("Phrases/Find a home/cry-inverted");
        findHomeSprites.Add(_FindHomeCry);
        _FindHomeLife = Resources.LoadAll<Sprite>("Phrases/Find a home/life");
        findHomeSprites.Add(_FindHomeLife);
        _FindHomeNothing = Resources.LoadAll<Sprite>("Phrases/Find a home/nothing");
        findHomeSprites.Add(_FindHomeNothing);
        _FindHomeSimple = Resources.LoadAll<Sprite>("Phrases/Find a home/simple");
        findHomeSprites.Add(_FindHomeSimple);

        _TooLongBar = Resources.LoadAll<Sprite>("Phrases/Too long without home/bar");
        tooLongSprites.Add(_TooLongBar);
        _TooLongBliss = Resources.LoadAll<Sprite>("Phrases/Too long without home/bliss");
        tooLongSprites.Add(_TooLongBliss);
        _TooLongDinner = Resources.LoadAll<Sprite>("Phrases/Too long without home/dinner");
        tooLongSprites.Add(_TooLongDinner);
        _TooLongTriumph = Resources.LoadAll<Sprite>("Phrases/Too long without home/triumph");
        tooLongSprites.Add(_TooLongBar);
        _TooLongJob = Resources.LoadAll<Sprite>("Phrases/Too long without home/job");
        tooLongSprites.Add(_TooLongTriumph);
        _TooLongPeace = Resources.LoadAll<Sprite>("Phrases/Too long without home/peace");
        tooLongSprites.Add(_TooLongPeace);
        _TooLongSurrealism = Resources.LoadAll<Sprite>("Phrases/Too long without home/surrealism");
        tooLongSprites.Add(_TooLongSurrealism);
        _TooLongWind = Resources.LoadAll<Sprite>("Phrases/Too long without home/wind");
        tooLongSprites.Add(_TooLongWind);

    }

    public void DisplayPhrase()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FlashPhrase(_TooLongBliss));
            StartCoroutine(FadeIn());
        }
    }

    public void DisplayFindFriendPhrase()
    {

    }

    IEnumerator FlashPhrase(Sprite[] sprites)
    {
        phrase.sprite = sprites[0];
        phrase.enabled = true;
        yield return new WaitForSeconds(0.2f);
        phrase.sprite = sprites[1];
        yield return new WaitForSeconds(0.2f);
        phrase.sprite = sprites[0];
        yield return new WaitForSeconds(0.2f);
        phrase.sprite = sprites[1];
        yield return new WaitForSeconds(0.2f);
        phrase.sprite = sprites[0];
        yield return new WaitForSeconds(0.2f);
        phrase.sprite = sprites[1];
        yield return new WaitForSeconds(0.2f);   
        phrase.sprite = sprites[0];
        yield return new WaitForSeconds(0.2f);
        phrase.sprite = sprites[1];
        yield return new WaitForSeconds(0.2f);
        phrase.sprite = sprites[0];
        yield return new WaitForSeconds(0.2f);
        phrase.sprite = sprites[1];
        

    }

    IEnumerator FadeIn()
    {
        //phrase.color = new Color(phrase.color.r, phrase.color.g, phrase.color.b, 0);
        Color c = phrase.color;
        float elapsedTime = 0.0f;
        while(elapsedTime < .5f)
        {
            Debug.Log("fading in");
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1f, (elapsedTime/.5f));
            phrase.color = c;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeOut(c));
    }

    IEnumerator FadeOut(Color c)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < 1.5f)
        {
            Debug.Log("fading  out");
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0f, (elapsedTime /1.5f));
            phrase.color = c;
            yield return null;
        }
        phrase.enabled = false;
    }


}
