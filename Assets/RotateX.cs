using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateX : MonoBehaviour
{

    public float speed = 3;


    void Update()
    {
        this.transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
}
