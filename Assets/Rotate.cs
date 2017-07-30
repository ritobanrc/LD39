using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 3;


    void Update()
    {
        this.transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}
