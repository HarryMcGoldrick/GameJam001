using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBoyScript : MonoBehaviour
{
    public float impactForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForceAtPosition(Vector3.up * impactForce, collision.GetContact(0).point, ForceMode.Impulse);
            this.gameObject.tag = "Untagged";
            this.gameObject.transform.SetParent(null);
            FindObjectOfType<CenterRing>().GetComponent<CenterRing>().RemovePoint(this.gameObject);
            int rand = Random.Range(1, 4);

            FindObjectOfType<SoundManager>().PlayOnce("OnObstacleHitScream" + rand);
            FindObjectOfType<SoundManager>().Play("OnObstacleHitImpact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Assume bonus ring
        if (other.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<ScoreManager>().baseMultiplier += other.GetComponent<BonusRing>().multiplier;
            FindObjectOfType<SoundManager>().PlayOnce("RingDing");
        }
    }

}
