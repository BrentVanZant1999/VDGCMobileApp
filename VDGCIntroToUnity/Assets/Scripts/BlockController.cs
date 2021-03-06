﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int numCollisions = 0;
    //Finds the ground object
    public GameObject Ground;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), Ground.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -transform.localScale.y) Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        numCollisions++;
        if (numCollisions == 3)
        {
            Destroy(gameObject);
        }
    }

}
