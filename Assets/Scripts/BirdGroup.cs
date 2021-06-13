using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGroup : MonoBehaviour
{
    public float birdSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * birdSpeed * Time.deltaTime;
    }
}
