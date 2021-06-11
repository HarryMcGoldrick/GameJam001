using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float speed;
    public float offset;


    void Start()
    {
        StartCoroutine(SmoothCameraMovement(this.transform.position.y + 10, 20));
    }

    public IEnumerator SmoothCameraMovement(float targetYPos, float duration = 5f)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Camera.main.transform.position.x, targetYPos + offset, Camera.main.transform.position.z), t / duration);
            yield return 0;
        }
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, targetYPos + offset, Camera.main.transform.position.z);
    }
}
