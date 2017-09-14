﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 movement;
    public Transform waypoint;
    public Transform waypoint2;
    public float speed;
    private float time = 0f;
    private float timeChange = 0.1f;
    private float timeLimit = 10f;
    private bool isForwards;

    // Use this for initialization
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            isForwards = true;
        }
        else
        {
            isForwards = false;
        }
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isForwards == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, waypoint2.position, step);
            if (transform.position == waypoint2.position)
            {
                time += timeChange;
                if (time >= timeLimit)
                {
                    isForwards = false;
                    time = 0f;
                }
            }
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, waypoint.position, step);
            if (transform.position == waypoint.position)
            {
                time += timeChange;
                if (time >= timeLimit)
                {
                    isForwards = true;
                    time = 0f;
                }                
            }
        }
    }
}