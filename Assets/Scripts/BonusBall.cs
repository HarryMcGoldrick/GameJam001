using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBall : MonoBehaviour
{
    public int boyMultiplier = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Center"))
        {
            CenterRing center = other.GetComponent<CenterRing>();
            center.AddManyPoints(center.points.Count * 2);
            Destroy(this.gameObject);
        }
    }
}
