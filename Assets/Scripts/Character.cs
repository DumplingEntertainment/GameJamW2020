﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Animator animator;

    public GameObject detectionCube;
    public float spawnTime;

    private float horizontalInput;
    private float verticalInput;

    public float speed;
    Vector3 movement;
    int direction; // 0 = down, 1 = up, 2 = left, 3 = right

    enum CharacterState {Alive, Dead};

    CharacterState state = CharacterState.Alive;

    void Start() {
        movement = new Vector3(0, -speed, 0);
        direction = 0;
        spawnTime = 0;
        EventManager.StartListening("OnCollideDeath", SetDeath);
    }

    void SetDeath() {
        state = CharacterState.Dead;
    }

    void FixedUpdate() {
        if (state == CharacterState.Dead) return;

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (direction == 0 || direction == 1) {
            if (verticalInput != 0) {
                horizontalInput = 0;
            }
        }
        else {
            if (horizontalInput != 0) {
                verticalInput = 0;
            }
        }

        animator.SetFloat("HorizontalInput", horizontalInput);
        animator.SetFloat("VerticalInput", verticalInput);

    }
    void Update() {

        if (state == CharacterState.Dead) return;

        // change direction
        switch (direction) {
            case 0:
                if (horizontalInput < 0) {
                    direction = 2;
                } else if (horizontalInput > 0) {
                    direction = 3;
                }
                break;
            case 1:
                if (horizontalInput < 0) {
                    direction = 2;
                } else if (horizontalInput > 0) {
                    direction = 3;
                }
                break;
            case 2:
                if (verticalInput < 0) {
                    direction = 0;
                } else if (verticalInput > 0) {
                    direction = 1;
                }
                break;
            case 3:
                if (verticalInput < 0) {
                    direction = 0;
                } else if (verticalInput > 0) {
                    direction = 1;
                }
                break;
        }

        // change position
        switch (direction) {
            case 0:
                movement = new Vector3(0, -speed * Time.deltaTime, 0);
                transform.position = transform.position + movement;
                break;
            case 1:
                movement = new Vector3(0, speed * Time.deltaTime, 0);
                transform.position = transform.position + movement;
                break;
            case 2:
                movement = new Vector3(-speed * Time.deltaTime, 0, 0);
                transform.position = transform.position + movement;
                break;
            case 3:
                movement = new Vector3(speed * Time.deltaTime, 0, 0);
                transform.position = transform.position + movement;
                break;
        }

        // detection of trail
        spawnTime += Time.deltaTime;
        if (spawnTime >= speed/10.0) {
            spawnTime = 0;
            StartCoroutine(spawnCube(this.transform.position));
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        EventManager.TriggerEvent("OnCollideDeath");
        animator.SetBool("IsCollision", true);
    }

    public IEnumerator spawnCube(Vector3 pos) {
        yield return new WaitForSeconds(0.5f);
        GameObject newObject = Instantiate(detectionCube, pos, Quaternion.identity);
        Destroy(newObject, 6.0f);
    }
    
}
