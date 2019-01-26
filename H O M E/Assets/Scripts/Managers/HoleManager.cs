using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public int maxHomesPerType;
    public int minHomesPerType;

    public GameObject[] homePrefabs;

    public float maxDistFromPlayer;
    public float minDistFromPlayer;
    public float minDistFromPath;

    List<GameObject> pooledHomes = new List<GameObject>();
    List<GameObject> activeHomes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PoolHomes()
    {
        int homeTypes = System.Enum.GetNames(typeof(Shape)).Length;

        for (int i = 0; i < homeTypes; i++)
        {
            int homesToSpawn = Random.Range(minHomesPerType, maxHomesPerType + 1);

            for (int j = 0; j < homesToSpawn; j++)
            {
                GameObject homeToPool = Instantiate(homePrefabs[i]);
                homeToPool.SetActive(false);
                pooledHomes.Add(homeToPool);
            }
        }

    }
}
