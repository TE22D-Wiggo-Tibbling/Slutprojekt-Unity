using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.XR.OpenVR;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform orientation;
    [SerializeField]
    Transform LookAt;
    [SerializeField]
    Transform playerObj;
    [SerializeField]
    Transform enemy;

    // Camera = GetComponent<CinemachineFreeLook>();
        

    void Update()
    {
        // rotate orientation
        Vector3 viewDir = LookAt.position.normalized - new Vector3(transform.position.x, LookAt.position.y, transform.position.z).normalized;
        // orientation.forward = viewDir.normalized;
        // transform.position = viewDir;

            playerObj.forward = viewDir.normalized;
        
    }
}
