using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMovement : MonoBehaviour
{
    public float moveSpeed;
    public float tiltAmount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        float moveY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;

        this.transform.position += new Vector3(moveX, 0, moveY);
    }
}
