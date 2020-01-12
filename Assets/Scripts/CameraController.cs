
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject character;
    private Vector3 charPos;
    
    private float z_value;
    public float transitionTime;

    public float lim_down, lim_up, lim_left, lim_right;

    void Start() {
        charPos = character.transform.position;
        z_value = this.transform.position.z;
    }

    void LateUpdate() {
        this.transform.position = Vector3.Lerp(this.transform.position,
        new Vector3(character.transform.position.x, character.transform.position.y, z_value)
        , transitionTime);

        if (this.transform.position.x > lim_right) {
            this.transform.position = new Vector3(lim_right, this.transform.position.y, z_value);
        }
        if (this.transform.position.x < lim_left) {
            this.transform.position = new Vector3(lim_left, this.transform.position.y, z_value);
        }
        if (this.transform.position.y < lim_down) {
            this.transform.position = new Vector3(this.transform.position.x, lim_down, z_value);
        }
        if (this.transform.position.y > lim_up) {
            this.transform.position = new Vector3(this.transform.position.x, lim_up, z_value);
        }
    }
}
