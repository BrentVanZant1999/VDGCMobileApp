using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    //some variables for the player.
    private float playerHorizontlalSpeed = 10;
    private float playerJumpSpeed = 200;
    private float myPosX;
    private float myPosY;
    private float myPosZ;

    public float rightBoundary;
    public float leftBoundary; 

    //controller reference 
    public CharacterController myController;

    //movement holder 
    private Vector3 movementVector; 

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        myPosX = myController.transform.position.x;
        myPosY = myController.transform.position.y;
        myPosZ = myController.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        myPosX = myController.transform.position.x;
        myPosY = myController.transform.position.y;
        myPosZ = myController.transform.position.z;
        //check to see if the player is inputing horizontal movement
        float isMovingHorizontally = Input.GetAxis("Horizontal");
        //check to see if the player is current holding the jump button down. 
        bool jumpDown = Input.GetButtonDown("Jump");


        movementVector = new Vector3(isMovingHorizontally * playerHorizontlalSpeed, 0f, 0);

        //handle basic gravity 
        movementVector.y = movementVector.y + Physics.gravity.y;
        //utilize deltaTime 
        myController.Move(movementVector*Time.deltaTime); 
        outofbounds();

    }
    //function to handle bounds.
    void outofbounds()
    {
        if (transform.position.x < leftBoundary) { transform.position = new Vector3(leftBoundary, myPosY, myPosZ); }
        if (transform.position.x > rightBoundary) { transform.position = new Vector3(rightBoundary, myPosY, myPosZ); }

    }
}
