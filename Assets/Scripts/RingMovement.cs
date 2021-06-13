using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMovement : MonoBehaviour
{
    public float moveSpeed;
    public float tiltAmount;

    public float fallSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        float moveY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;

        this.transform.position = new Vector3(this.transform.position.x + moveX, this.transform.position.y - (fallSpeed * Time.deltaTime), this.transform.position.z + moveY);

    }
}
