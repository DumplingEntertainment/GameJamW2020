using System.Collections;
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
    }
}
