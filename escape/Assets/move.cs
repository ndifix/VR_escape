using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class move : MonoBehaviour {
	public int speed = 10;
	private float pi=3.141592f;
	// Use this for initialization
	void Start () {
        Vector3 vec;
	    vec.x = 0;vec.y = 1;vec.z = 0;
		this.transform.position = vec;
	}
	
	// Update is called once per frame
	void Update () {
        if (!XRDevice.isPresent)
        {
            float angle = this.transform.rotation.y;
            angle *= pi / 180.0f;
            //平行移動
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(speed * Mathf.Sin(angle), 0, speed * Mathf.Cos(angle));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(speed * Mathf.Sin(angle + pi), 0, speed * Mathf.Cos(angle + pi));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(speed * Mathf.Sin(angle - pi / 2), 0, speed * Mathf.Cos(angle - pi / 2));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(speed * Mathf.Sin(angle + pi / 2), 0, speed * Mathf.Cos(angle + pi / 2));
            }

            //回転移動
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(0, -5, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Rotate(0, 5, 0);
            }
        }

        if (XRDevice.isPresent)
        {///Riftあり
            
        }
	}
}
