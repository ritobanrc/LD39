using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public Transform Player;
    public GameObject RoadPrefab;
    public int InitSpawn = 50;

    public float NextSpawnPoint = 0;

    private void Start()
    {
        for (int i = 0; i < InitSpawn; i++)
        {
            GameObject obj = Instantiate(RoadPrefab, new Vector3(0, 0, NextSpawnPoint), Quaternion.identity, this.transform);
            obj.GetComponent<Road>().isFirst = i == 0;
            NextSpawnPoint += 1;
        }
    }
}
