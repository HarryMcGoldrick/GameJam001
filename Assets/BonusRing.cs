using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRing : MonoBehaviour
{
    public float radiusOffset = 5f;

    void Start()
    {
        float radius = FindObjectOfType<CenterRing>().GetComponent<CenterRing>().radius;
        Vector3 updatedScale = new Vector3((transform.localScale.x * radius) + radiusOffset,
            (transform.localScale.y * radius) + radiusOffset, (transform.localScale.z * radius) + radiusOffset);
        this.transform.localScale = updatedScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
