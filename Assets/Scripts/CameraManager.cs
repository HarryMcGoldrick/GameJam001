using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float delay;
    public Vector3 baseOffset;
    public float offsetPerBoy;
    public Transform pointToFollow;
    
    private Vector3 newPosition;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    private CenterRing centerRing;

    private void Start()
    {
        centerRing = FindObjectOfType<CenterRing>();
    }


    private void Update()
    {
        UpdateCameraForRadius();
        newPosition = pointToFollow.position + offset;
        this.transform.position = new Vector3(this.transform.position.x, newPosition.y, this.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, delay);
    }

    void UpdateCameraForRadius()
    {
        offset = new Vector3(baseOffset.x, baseOffset.y + centerRing.radius * offsetPerBoy, baseOffset.z);
    }


}
