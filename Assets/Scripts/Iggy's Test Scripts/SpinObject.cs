using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float rotateSpeed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }
}
