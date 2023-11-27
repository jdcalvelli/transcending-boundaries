using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManagement : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera impactCamera;

    void Start()
    {
        SetMainCamera();
    }

    public void SetMainCamera()
    {
        mainCamera.Priority = 20;
        impactCamera.Priority = 10;
    }

    public void SetImpactCamera(Transform targetImpact)
    {
        impactCamera.Follow = targetImpact;
        impactCamera.LookAt = targetImpact;

        mainCamera.Priority = 10;
        impactCamera.Priority = 20;
    }

    void Update()
    {
        
    }
}
