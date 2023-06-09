﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyOwnClass;

public class CameraFly : MonoBehaviour
{

    
    public float speed = 15.0f;
    private Vector3 transfer;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;


    void Start()
    {
        originalRotation = transform.rotation;

    }

    void Update()   
    {
        // Движения мыши -> Вращение камеры
        rotationX += Input.GetAxis("Mouse X") * DifferentThings.mouseSensitivity;
        rotationY += Input.GetAxis("Mouse Y") * DifferentThings.mouseSensitivity;
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
        transform.rotation = originalRotation * xQuaternion * yQuaternion;
        // перемещение камеры
        transfer = transform.forward * Input.GetAxis("Vertical");
        transfer += transform.right * Input.GetAxis("Horizontal");
        transform.position += transfer * DifferentThings.CameraSpeed * Time.deltaTime;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

}
