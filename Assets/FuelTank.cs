using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour
{
    public float fuelAmt = 5;
    public AudioClip pickupSound;
    PlayerController player;
    Fuel fuel;


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        fuel = FindObjectOfType<Fuel>();
    }
    private void Update()
    {
        if(Vector3.Distance(player.transform.position, this.transform.position) < 0.3)
        {
            fuel.fuel += fuelAmt;
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            Destroy(gameObject);
        }       
    }
}
