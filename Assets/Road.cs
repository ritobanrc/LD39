using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject fuelTankPrefab;
    public GameObject AllTheRocks;
    public float tankProb = 0.01f;
    public float rockProb = 0.05f;

    InfiniteRoad spawner;
    public bool isFirst;

    private void Start()
    {
        spawner = FindObjectOfType<InfiniteRoad>();
        if (isFirst)
            return;
        if (Random.value < tankProb)
        {
            int lane = Random.Range(-1, 1);
            Instantiate(fuelTankPrefab, new Vector3(lane, 0, this.transform.position.z), Quaternion.identity, this.transform);
        }
        else if (Random.value < rockProb)
        {
            int lane = Random.Range(-1, 1);
            GameObject prefab = AllTheRocks.transform.GetChild(Random.Range(0, AllTheRocks.transform.childCount - 1)).gameObject;
            Instantiate(prefab, new Vector3(lane, 0, this.transform.position.z), Quaternion.identity, this.transform);
        }
    }

    private void LateUpdate()
    {
        if (spawner.Player.position.z - 2f >= this.transform.position.z)
        {
            this.transform.position = new Vector3(0, 0, spawner.NextSpawnPoint);
            foreach (Transform child in transform)
            {
                if (child.name != "road")
                    Destroy(child.gameObject);
            }
            Start();
            spawner.NextSpawnPoint += 1;
        }
    }
}
