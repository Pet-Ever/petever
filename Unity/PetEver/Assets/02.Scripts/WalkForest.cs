using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using UnityEngine.UI;

public class WalkForest : MonoBehaviour
{
    GameObject forestLand;
    GameObject manCharacter;
    Vector3 centerPos;
    Transform manLookAt;
    Transform forestMainCam_tr;

    public Transform Target;
    public float forestWalkSpeed = 0.8f;

    void Start()
    {
        forestLand = GameObject.Find("forestLand");
        Input.gyro.enabled = true;
        PlayerController.isForest = true;
        manCharacter = GameObject.FindGameObjectWithTag("Owner");
        Target = GameObject.Find("WalkLine").transform;
        manLookAt = GameObject.Find("ManLookAt").transform;
        forestMainCam_tr = GameObject.Find("ForestMainCam").transform;

        manCharacter.transform.LookAt(manLookAt);
    }

    void Update()
    {
        manCharacter.transform.RotateAround(Target.position, Vector3.up, forestWalkSpeed * Time.deltaTime);
        forestMainCam_tr.RotateAround(Target.position, Vector3.up, forestWalkSpeed * Time.deltaTime);
        PlayerController.playerAnimator.SetFloat("walking", forestWalkSpeed);
        //transform.Rotate(Input.gyro.rotationRateUnbiased.x, Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
        // UnityEngine.Debug.Log("x: " + Input.gyro.rotationRateUnbiased.x + " y: " + Input.gyro.rotationRateUnbiased.y + " z: " + Input.gyro.rotationRateUnbiased.z);
        if (Math.Abs(Input.gyro.rotationRateUnbiased.x) > 0.3f && Math.Abs(Input.gyro.rotationRateUnbiased.y) > 0.3f && Math.Abs(Input.gyro.rotationRateUnbiased.z) > 0.3f) {
            PlayerController.mov_x = 0;
            PlayerController.mov_y = 0;
            PlayerController.playerSpeed = 0;
        } else {
            PlayerController.mov_x = 0;
            PlayerController.mov_y = 0;
        }
    }
}
