using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform orientation;
    [SerializeField]
    Transform LookAt;
    [SerializeField]
    Transform playerObj;



    void Update()
    {
        // rotate orientation
        Vector3 viewDir = LookAt.position - new Vector3(transform.position.x, LookAt.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
     
            // playerObj.forward = viewDir.normalized;
        
    }
}
