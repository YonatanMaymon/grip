using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smothness;


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 smothed_position = Vector3.Lerp(transform.position, target.position + offset, smothness);
        transform.position = smothed_position;
    }
}
