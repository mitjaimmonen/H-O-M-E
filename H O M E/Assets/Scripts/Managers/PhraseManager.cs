﻿using System.Collections;
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
    Sprite[] _TooLongSpace;


    List<Sprite[]> findHomeSprites = new List<Sprite[]>();
    bool[] findHomeIndex;
    Sprite[] _FindHomeCry;
    Sprite[] _FindHomeLife;
    Sprite[] _FindHomeNothing;
    Sprite[] _FindHomeSimple;
    Sprite[] _FindHomeHome;
    Sprite[] _FindHomePeace;
    Sprite[] _FindHomeHurtless;
    Sprite[] _FindHomePeaceful;
    Sprite[] _FindHomeSoCold;



    List<Sprite[]> findFriendSprites = new List<Sprite[]>();
    bool[] findFriendIndex;
    Sprite[] _FindFriendComfort;
    Sprite[] _FindFriendLess;
    Sprite[] _FindFriendOfc;
    Sprite[] _FindFriendSomething;
    Sprite[] _FindFriendTender;
    Sprite[] _FindFriendAllAlone;
    Sprite[] _FindFriendIncredible;
    Sprite[] _FindFriendLoveYou;
    Sprite[] _FindFriendOhLove;   

    List<Sprite[]> loseFriendSprites = new List<Sprite[]>();
    bool[] loseFriendIndex;
    Sprite[] _LoseFriendAlone;
    Sprite[] _LoseFriendDisappear;
    Sprite[] _LoseFriendHappening;
    Sprite[] _LoseFriendLoved;
    Sprite[] _LoseFriendSmoke;
    Sprite[] _LoseFriendTime;
    Sprite[] _LoseFriendReachOut;

    List<Sprite[]> wrongHouseSprites = new List<Sprite[]>();
    bool[] wrongHouseIndex;
    Sprite[] _WrongHouseDance;
    Sprite[] _WrongHouseDie;
    Sprite[] _WrongHouseFeelNothing;
    Sprite[] _WrongHouseImage;
    Sprite[] _WrongHouseJazz;
    Sprite[] _WrongHouseKafka;
    Sprite[] _WrongHouseMess;
    Sprite[] _WrongHouseShut;
    Sprite[] _WrongHouseSisyphus;
    Sprite[] _WrongHouseWanderer;
    Sprite[] _WrongHouseWild;

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
        InitializeIndexes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeIndexes()
    {
        tooLongIndex = new bool[tooLongSprites.Count];
        for (int i = 0; i < tooLongIndex.Length; i++)
        {
            tooLongIndex[i] = true;
        }
        findHomeIndex = new bool[findHomeSprites.Count];
        for (int i = 0; i < findHomeIndex.Length; i++)
        {
            findHomeIndex[i] = true;
        }
        findFriendIndex = new bool[findFriendSprites.Count];
        for (int i = 0; i < findFriendIndex.Length; i++)
        {
            findFriendIndex[i] = true;
        }
        loseFriendIndex = new bool[loseFriendSprites.Count];
        for (int i = 0; i < loseFriendIndex.Length; i++)
        {
            loseFriendIndex[i] = true;
        }
        wrongHouseIndex= new bool[wrongHouseSprites.Count];
        for (int i = 0; i < wrongHouseIndex.Length; i++)
        {
            wrongHouseIndex[i] = true;
        }
    }

    void LoadSprites()
    {
        _WrongHouseDance = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseDance);
        _WrongHouseDie = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseDie);
        _WrongHouseFeelNothing = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseFeelNothing);
        _WrongHouseImage = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseImage);
        _WrongHouseJazz = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseJazz);
        _WrongHouseKafka = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseKafka);
        _WrongHouseMess = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseMess);
        _WrongHouseShut = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseShut);
        _WrongHouseSisyphus = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseSisyphus);
        _WrongHouseWanderer = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseWanderer);
        _WrongHouseWild = Resources.LoadAll<Sprite>("Phrases/Wrong house/dance");
        wrongHouseSprites.Add(_WrongHouseWild);

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
        _LoseFriendReachOut = Resources.LoadAll<Sprite>("Phrases/Losing a friend/ReachOut");
        loseFriendSprites.Add(_LoseFriendReachOut);

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
        _FindFriendAllAlone = Resources.LoadAll<Sprite>("Phrases/Find a home/allalone");
        findFriendSprites.Add(_FindFriendAllAlone);
        _FindFriendIncredible = Resources.LoadAll<Sprite>("Phrases/Find a home/incredible");
        findFriendSprites.Add(_FindFriendIncredible);
        _FindFriendLoveYou = Resources.LoadAll<Sprite>("Phrases/Find a home/LoveYou");
        findFriendSprites.Add(_FindFriendLoveYou);
        _FindFriendOhLove = Resources.LoadAll<Sprite>("Phrases/Find a home/OhLove");
        findFriendSprites.Add(_FindFriendOhLove);

        _FindHomeCry = Resources.LoadAll<Sprite>("Phrases/Find a home/cry-inverted");
        findHomeSprites.Add(_FindHomeCry);
        _FindHomeLife = Resources.LoadAll<Sprite>("Phrases/Find a home/life");
        findHomeSprites.Add(_FindHomeLife);
        _FindHomeNothing = Resources.LoadAll<Sprite>("Phrases/Find a home/nothing");
        findHomeSprites.Add(_FindHomeNothing);
        _FindHomeSimple = Resources.LoadAll<Sprite>("Phrases/Find a home/simple");
        findHomeSprites.Add(_FindHomeSimple);
        _FindHomeHome = Resources.LoadAll<Sprite>("Phrases/Find a home/home");
        findHomeSprites.Add(_FindHomeHome);
        _FindHomePeace = Resources.LoadAll<Sprite>("Phrases/Find a home/HomePeace");
        findHomeSprites.Add(_FindHomePeace);
        _FindHomeHurtless = Resources.LoadAll<Sprite>("Phrases/Find a home/hurtless");
        findHomeSprites.Add(_FindHomeHurtless);
        _FindHomePeaceful = Resources.LoadAll<Sprite>("Phrases/Find a home/peaceful");
        findHomeSprites.Add(_FindHomePeaceful);
        _FindHomeSoCold = Resources.LoadAll<Sprite>("Phrases/Find a home/SoCold");
        findHomeSprites.Add(_FindHomeSoCold);

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
        _TooLongSpace = Resources.LoadAll<Sprite>("Phrases/Too long without home/Space");
        tooLongSprites.Add(_TooLongSpace);

    }

    public void DisplayPhrase(Sprite[] phrase)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FlashPhrase(phrase));
            StartCoroutine(FadeIn());
        }
    }

    public void DisplayFindFriendPhrase()
    {
        int randomPhrase = Random.Range(0, findFriendSprites.Count);
        DisplayPhrase(findFriendSprites[randomPhrase]);
    }

    public void DisplayFindHomePhrase()
    {
        int randomPhrase = Random.Range(0, findHomeSprites.Count);
        DisplayPhrase(findHomeSprites[randomPhrase]);
    }

    public void DisplayTooLongPhrase()
    {
        int randomPhrase = Random.Range(0, tooLongSprites.Count);
        DisplayPhrase(tooLongSprites[randomPhrase]);
    }

    public void DisplayLoseFriendPhrase()
    {
        int randomPhrase = Random.Range(0, loseFriendSprites.Count);
        DisplayPhrase(loseFriendSprites[randomPhrase]);
    }

    public void DisplayWrongHomePhrase()
    {
        int randomPhrase = Random.Range(0, wrongHouseSprites.Count);
        DisplayPhrase(wrongHouseSprites[randomPhrase]);
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
        while (elapsedTime < .5f)
        {
            Debug.Log("fading in");
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1f, (elapsedTime / .5f));
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
            c.a = Mathf.Lerp(1, 0f, (elapsedTime / 1.5f));
            phrase.color = c;
            yield return null;
        }
        phrase.enabled = false;
    }


}
