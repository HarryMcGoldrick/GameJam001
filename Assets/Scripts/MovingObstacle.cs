using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingObstacle : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float RandomRotationStrength;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 tempVect = new Vector3(0, 1, 0);
        tempVect = tempVect.normalized * MoveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + tempVect);
        transform.Rotate(RandomRotationStrength, RandomRotationStrength, RandomRotationStrength);
    }
}
