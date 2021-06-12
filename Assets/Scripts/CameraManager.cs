using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float delay;
    public Vector3 offset;
    public float distanceBeforeUpdate;

    public Transform pointToFollow;
    private Vector3 newPosition;
    private bool isUpdating;

    private Vector3 velocity = Vector3.zero;




    private void Update()
    {
        //newPosition = pointToFollow.position + offset;
        //this.transform.position = new Vector3(this.transform.position.x, newPosition.y, this.transform.position.z);
        //if (Vector3.Distance(newPosition, this.transform.position) > distanceBeforeUpdate)
        //{
        //    //Debug.Log("Updating camera");
        //    //StartCoroutine(SmoothCameraMovement(delay));
        //    //isUpdating = true;
        //}

        transform.position = Vector3.SmoothDamp(transform.position, newPosition,  ref velocity, delay);

    }

    //public IEnumerator SmoothCameraMovement(float duration = 5f)
    //{
    //    if (!isUpdating)
    //    {
    //        for (float t = 0f; t < duration; t += Time.deltaTime)
    //        {
    //            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(newPosition.x, newPosition.y, newPosition.z), t / duration);
    //            yield return 0;
    //        }
    //        isUpdating = false;
    //    }
      
    //    //Camera.main.transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
    //}
}
