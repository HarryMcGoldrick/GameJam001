using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float RandomRotationStrength;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 tempVect = new Vector3(0, 1, 0);
        tempVect = tempVect.normalized * MoveSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(transform.position + tempVect);
        transform.Rotate(RandomRotationStrength, RandomRotationStrength, RandomRotationStrength);
    }
}
