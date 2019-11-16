using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform topRight;
    [SerializeField] private Transform bottomLeft;
    [SerializeField] private float stepSize;
    [SerializeField] private int numObjects;

    [SerializeField] private GameObject testObj;

    public void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Vector3 topRightPos = topRight.position;
        Vector3 bottomLeftPos = bottomLeft.position;
        int numXPos = Mathf.RoundToInt((topRightPos.x - bottomLeftPos.x) / stepSize);
        int numYPos = Mathf.RoundToInt((topRightPos.y - bottomLeftPos.y) / stepSize);
        Debug.Log("xpos " + numXPos);
        Debug.Log("ypos " + numYPos);
        for (int i = 0; i < numXPos; ++i)
        {
            for (int j = 0; j < numYPos; ++j)
            {
                Instantiate(testObj, new Vector3(i * stepSize, j * stepSize, topRightPos.z), Quaternion.identity);
            }
        }
    }
}
