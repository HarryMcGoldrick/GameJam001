using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBoyScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Center"))
        {
            other.GetComponent<CenterRing>().AddPoint();
            Destroy(this.gameObject);
        }
    }
}
