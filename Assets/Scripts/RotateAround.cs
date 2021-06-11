using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 axis;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Center").transform;
    }

    void Update()
    {
        this.transform.RotateAround(target.position, axis, Time.deltaTime * speed);
    }
}
