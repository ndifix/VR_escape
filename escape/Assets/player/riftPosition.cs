using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class riftPosition : MonoBehaviour
{
    public float speed = 0.1f;
    float InitialY = 0;
    float Step(float key, float border) { //return key>=border?key:0f;
        return key;
    }
    float Max(float a,float b) { return a < b ? b : a; }
    public float speedLimit = 0.05f;
    private float pi = 3.141592f;

    void Start()
    {
        //InitialY = this.transform.position.y;   
    }

    // Update is called once per frame
    void Update()
    {
        InitialY += 1;
        Vector3 position = InputTracking.GetLocalPosition(XRNode.CenterEye);
        Quaternion rotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
        float angleY = InputTracking.GetLocalRotation(XRNode.CenterEye).eulerAngles.y;
        angleY *= pi / 180.0f;
        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        
        float front =speed * (stickL+stickR).y;
        float right =speed * (stickL+stickR).x;
        
        float x = front * Mathf.Sin(angleY) + right * Mathf.Cos(angleY);
        float z = front * Mathf.Cos(angleY) - right * Mathf.Sin(angleY);
        if (x != 0.0f) x = x / Mathf.Abs(x) * Step(Mathf.Abs(x), speedLimit);
        if (z != 0.0f) z = z / Mathf.Abs(z) * Step(Mathf.Abs(z), speedLimit);

        //frontBack = 0.01f;LR = 0.01f;
        Vector3 optInput = new Vector3(x, 0, z);

        this.transform.Translate(optInput);

        //Debug.Log(optInput);
    }
}