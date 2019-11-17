using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MapGenerator : MonoBehaviour
{
    // MapGeneration
    [SerializeField] private Transform topRight;
    [SerializeField] private Transform bottomLeft;
    [SerializeField] private float stepSize;
    [SerializeField] private int numObjects;
    [SerializeField] private List<GameObject> islandObjects;
    
    //Events
    [SerializeField] private List<GameObject> eventObjects;
    [SerializeField] private float roundTime;
    [SerializeField] private int beginningBufferEvents;
    [SerializeField] private int numEvents;
    public Transform player;
    
    private float currTime;
    private bool gameOver;
    
    private HashSet<int> spawnedPositions = new HashSet<int>();
    
    private static MapGenerator _instance;

    public static MapGenerator Instance => _instance;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }
    
    private void Start()
    {
        GenerateMap();
        currTime = roundTime;
        StartCoroutine(GenerateEvents());
    }

    private void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime <= 0f)
        {
            gameOver = true;
            //TODO end game
        }
    }

    public void GenerateMap()
    {
        for (int i = 0; i < numObjects; ++i)
        {
            SpawnRandom(PickIslandObject());
        }
    }

    public IEnumerator GenerateEvents()
    {
        float eventStepSize = roundTime / (beginningBufferEvents + numEvents);
        float currSlot = eventStepSize * beginningBufferEvents;
        yield return new WaitForSeconds(currSlot);
        while (!gameOver)
        {
            float time = UnityEngine.Random.Range(currSlot, currSlot + eventStepSize);
            currSlot += eventStepSize;
            Invoke(nameof(SpawnEventAtPlayer), time);
            yield return new WaitForSeconds(eventStepSize);
        }
    }
    
    public void SpawnEventAtPlayer()
    {
        GameObject toSpawn = PickEvent();
        GameObject spawned = Instantiate(toSpawn, player.position, toSpawn.transform.rotation);
        spawned.transform.parent = player.transform;
    }
    
    public List<int> GetNeighbors(int x, int y, int xMax, int yMax)
    {
        List<int> res = new List<int>();
        for (int i = -1; i <= 1; ++i)
        {
            for (int j = -1; j <= 1; ++j)
            {
                if (x == 0 && y == 0) continue;
                int newX = x + i;
                int newY = y + j;
                if (newX < xMax &&
                    newX >= 0 &&
                    newY < yMax &&
                    newY >= 0)
                {
                    res.Add(x*xMax + y);
                }
                
            }
        }
        return res;
    }

    public void SpawnRandom(GameObject objToSpawn)
    {
        Vector3 topRightPos = topRight.position;
        Vector3 bottomLeftPos = bottomLeft.position;
        int numXPos = Mathf.RoundToInt((topRightPos.x - bottomLeftPos.x) / stepSize);
        int numZPos = Mathf.RoundToInt((topRightPos.z - bottomLeftPos.z) / stepSize);
        float xDiff = (topRightPos.x - bottomLeftPos.x - stepSize * numXPos)/2f;
        float zDiff = (topRightPos.z - bottomLeftPos.z - stepSize * numZPos)/2f;
        
        int rand;
        do
        {
            rand = UnityEngine.Random.Range(0, numXPos * numZPos);
        } while (spawnedPositions.Contains(rand));
        spawnedPositions.Add(rand);
        
        int x = rand / numXPos;
        int y = rand % numZPos;
        Instantiate(objToSpawn,  new Vector3(-1f*xDiff + bottomLeftPos.x + x * stepSize, topRightPos.y, -1f*zDiff + bottomLeftPos.z + y * stepSize), Quaternion.identity);
    }

    public GameObject PickIslandObject()
    {
        return islandObjects[UnityEngine.Random.Range(0, islandObjects.Count)];
    }
    
    public GameObject PickEvent()
    {
        return eventObjects[UnityEngine.Random.Range(0, eventObjects.Count)];
    }
    
}
