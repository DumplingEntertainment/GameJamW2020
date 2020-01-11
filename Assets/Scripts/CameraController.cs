using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject character;
    public Vector3 charPos;

    void Start() {
        charPos = character.transform.position;
    }

    void LateUpdate() {

        this.transform.position +=  character.transform.position - charPos;
        charPos = character.transform.position;
    }
}
