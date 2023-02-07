using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugMovement : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        //GetComponent<Rigidbody>().MovePosition(movement * speed * Time.deltaTime);
    }
}
