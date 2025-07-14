using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public PlayerController playerController;
    public Camera playerCamera;
    private Vector3 cameraRotation;
    private void HandleCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        cameraRotation.y += mouseX * playerController.rotationSpeed;
        cameraRotation.x -= mouseY * playerController.rotationSpeed;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -60f, 60f);

        playerCamera.transform.eulerAngles = cameraRotation;


        float cameraDistance = 3f;
        Vector3 cameraOffset = Vector3.up * 2f;
        playerCamera.transform.position = transform.position - playerCamera.transform.forward * cameraDistance + cameraOffset;
    }
    public void Start()
    {
        if (!playerCamera) playerCamera = Camera.main;
    }
    public void Update()
    {
        HandleCamera();
    }
}
