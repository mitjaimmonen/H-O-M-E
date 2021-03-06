﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int maxHomesPerType;
    public int minHomesPerType;

    public GameObject homePrefab;
    public GameObject piecePrefab;
    public GameObject playerPiece;

    public float actorRadius;
    public float displayRadius = 1;
    public Vector2 regionSize;
    public int rejectionSamples = 30;

    public float maxDistFromPlayer;
    public float minDistFromPlayer;
    public float minDistFromPath;


    public List<Vector2> points = new List<Vector2>();
    public List<GameObject> homes = new List<GameObject>();
    public List<ShapePieces> pieces = new List<ShapePieces>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PoolActors()
    {
        points = PoissonDiscSampling.GeneratePoints(actorRadius, regionSize, rejectionSamples);
        int pointsCounter = 1;
        int shapeTypes = System.Enum.GetNames(typeof(Shape)).Length;
        int playerType = Random.Range(0, shapeTypes);
        GameObject playerPiece = Instantiate(piecePrefab);
        ShapePieces shapePiece = playerPiece.GetComponent<ShapePieces>();
        shapePiece.Instantiate((Shape)playerType, points[0]);
        shapePiece.AllowControl = true;
        pieces.Add(shapePiece);


        GameObject homeToSpawn = Instantiate(homePrefab);
        homeToSpawn.GetComponent<HomePieces>().Instantiate((Shape)playerType, points[pointsCounter]);
        homes.Add(homeToSpawn);
        pointsCounter++;


        for (int i = 0; i < shapeTypes; i++)
        {

            GameObject pieceToSpawn = Instantiate(piecePrefab);
            shapePiece = pieceToSpawn.GetComponent<ShapePieces>();
            shapePiece.Instantiate((Shape)i, points[pointsCounter]);
            shapePiece.transform.rotation = Quaternion.LookRotation(Vector3.forward, Random.insideUnitCircle);
            pointsCounter++;
            pieces.Add(shapePiece);

            int homesToSpawn = Random.Range(minHomesPerType, maxHomesPerType);

            for (int j = 0; j < homesToSpawn; j++)
            {
                homeToSpawn = Instantiate(homePrefab);
                homeToSpawn.GetComponent<HomePieces>().Instantiate((Shape)i, points[pointsCounter]);
                homeToSpawn.transform.rotation = Quaternion.LookRotation(Vector3.forward, Random.insideUnitCircle);
                homes.Add(homeToSpawn);
                pointsCounter++;
            }


        }

    }

    public ShapePieces AssignPiece()
    {
        int index = 0;
        List<ShapePieces> tempList = pieces;

        while (tempList.Count > 0)
        {
            index = Random.Range(0, tempList.Count);

            if (tempList[index].snugFit)
            {
                tempList.RemoveAt(index);
            }
            else
            {
                tempList[index].AllowControl = true;
                return tempList[index];
            }

        }

        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(regionSize / 2, regionSize);
        if (points != null)
        {
            foreach (Vector2 point in points)
            {
                Gizmos.DrawSphere(point, displayRadius);
            }
        }
    }

    //private Vector2 CalculateHomeSpawnPosition(GameObject piece, GameObject playerPiece)
    //{
    //    float randomX = 0;
    //    float randomY = 0;
    //    Vector2 spawnPosition;
    //   // if (piece == playerPiece)
    //    {
    //      //  Quaternion.Euler(0, Random.Range(0, 360), 0) * new Vector2(0, 1) * Random.Range(5, 20);
    //        spawnPosition = Random.insideUnitCircle * 20 + (Vector2)piece.transform.position;
    //    }



    //    return spawnPosition;
    //}
}
