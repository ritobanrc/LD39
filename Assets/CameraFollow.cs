using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    Vector3 offset;
    private void Start()
    {
        offset = this.transform.position - Target.transform.position;
    }

    private void LateUpdate()
    {
        this.transform.position = Target.transform.position + offset;
    }
}
