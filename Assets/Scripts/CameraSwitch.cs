using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject[] cinematicCameras;
    [SerializeField] CinemachineVirtualCamera povCam, thirdPersonCam;

    int currentCam = 0;
    float timeSinceAnyKey;

    void Start()
    {
        StartCoroutine(CamreaViewer());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            CameraSwitcher();
    }

    IEnumerator CamreaViewer()
    {
        while (true)
        {
            if (Input.anyKey||Input.GetAxis("Mouse X") !=0 || Input.GetAxis("Mouse Y") != 0)
            {
                timeSinceAnyKey = 0; 
            }
            else
            {
                timeSinceAnyKey += Time.deltaTime;
            }
            if (timeSinceAnyKey >= 5)
            {
                currentCam = (currentCam + 1) % cinematicCameras.Length;
                ResetPriority();
                SetPriority();
                timeSinceAnyKey = 0;
            }
            yield return null;
        }
    }

    void CameraSwitcher()
    {
        if (povCam.Priority == 11)
        {
            povCam.Priority = 10;
            thirdPersonCam.Priority = 11;
        }
        else if (thirdPersonCam.Priority == 11)
        {
            thirdPersonCam.Priority = 10;
            povCam.Priority = 11;
        }
    }

    void ResetPriority()
    {
        foreach (var camerea in cinematicCameras)
        {
            if (camerea.GetComponent<CinemachineVirtualCamera>())
            {
                camerea.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
            if (camerea.GetComponent<CinemachineBlendListCamera>())
            {
                camerea.GetComponent<CinemachineBlendListCamera>().Priority = 10;
            }
        }
    }

    void SetPriority()
    {
        if (cinematicCameras[currentCam].GetComponent<CinemachineBlendListCamera>())
        {
            cinematicCameras[currentCam].GetComponent<CinemachineBlendListCamera>().Priority = 11;
        }
        if (cinematicCameras[currentCam].GetComponent<CinemachineVirtualCamera>())
        {
            cinematicCameras[currentCam].GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
    }
}
