﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    Vector2 movement;
    private bool freezePlayer = false;
    PlayerController playerController;

    public Rigidbody2D rigidBody;

    void Start() {
        GameObject thePlayer = GameObject.Find("player");
        playerController = thePlayer.GetComponent<PlayerController>();
        
    }
    // Update is called once per frame
    void Update()
    {
        freezePlayer = playerController.doingAction;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!freezePlayer) {
            rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}