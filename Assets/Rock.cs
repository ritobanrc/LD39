using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    PlayerController player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        Vector3 distance = player.transform.position - this.transform.position;
        if (distance.sqrMagnitude < 0.1)
        {
            player.Explode();
        }
    }
}
