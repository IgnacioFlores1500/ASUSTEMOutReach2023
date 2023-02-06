using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugCameraMovmenet : MonoBehaviour
{

    public GameObject DebugPlayer;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = DebugPlayer.transform.position + offset;
    }
}

