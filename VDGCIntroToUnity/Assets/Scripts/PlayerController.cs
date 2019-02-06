using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 

    //some variables for the player.
    float playerHorizontalSpeed = 10.0f;
    float playerJumpSpeed = 15.0f;

    //controller reference 
    CharacterController myController;

    //movement holder 
    Vector3 movementVector;

    //Creates movement direction boolean
    bool horiDir = true;

    //Position Variables
    float xPos;
    float yPos;
    float zPos;

    //Movement Variables
    float horiInput;
    bool jumpPressed;

    float xInc;
    float zInc;

    //MoveToMethods

    //MoveToX
    void moveTox(float pos)
    {
        myController.transform.position = new Vector3(pos, myController.transform.position.y, myController.transform.position.z);
    }

    //MoveToY
    void moveToy(float pos)
    {
        myController.transform.position = new Vector3(myController.transform.position.x, pos, myController.transform.position.z);
    }

    //MoveToZ
    void moveToz(float pos)
    {
        myController.transform.position = new Vector3(myController.transform.position.x, myController.transform.position.y, pos);
    }


    // Start is called before the first frame update
    void Start()
    {

        //Creates the player controller
        myController = GetComponent<CharacterController>();

        //Sets Gravity
        Physics.gravity = new Vector3(0, -1.0f, 0);

        //Initilizes movement vector
        movementVector = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {

        //Finds the ball's current position
        xPos = myController.transform.position.x;
        yPos = myController.transform.position.y;
        zPos = myController.transform.position.z;

        //Finds Inputs
        horiInput = Input.GetAxis("Horizontal");
        jumpPressed = Input.GetButtonDown("Jump");

        //Checks if player has changed sides
        if (horiDir)
        {
            //A Variable that finds how much x will be with added
            xInc = (horiInput * playerHorizontalSpeed * Time.deltaTime * -System.Math.Sign(zPos));
            if (xInc + xPos > Globals.border | xInc + xPos < -Globals.border)
            {
                movementVector.x = 0;
                xPos = System.Math.Sign(xPos) * Globals.border;
                movementVector.z = playerHorizontalSpeed * horiInput * System.Math.Sign(xPos);
                horiDir = false;
            }
            else movementVector.x = playerHorizontalSpeed * horiInput * -System.Math.Sign(zPos);
        }
        else
        {
            //A variable that finds how much x will be increased by
            zInc = (horiInput * playerHorizontalSpeed * Time.deltaTime * System.Math.Sign(xPos));
            if (zInc + zPos > Globals.border | zInc + zPos < -Globals.border)
            {
                movementVector.z = 0;
                zPos = System.Math.Sign(zPos) * Globals.border;
                movementVector.x = playerHorizontalSpeed * horiInput * -System.Math.Sign(zPos);
                horiDir = true;
            }
            else movementVector.z = playerHorizontalSpeed * horiInput * System.Math.Sign(xPos);
        }


        //handle jumping logic
        if (jumpPressed && myController.isGrounded)
        {
            movementVector.y = playerJumpSpeed;
        }

        //handle basic gravity 
        movementVector.y = movementVector.y + Physics.gravity.y;

        //utilize deltaTime 
        myController.Move(movementVector*Time.deltaTime);

        if (horiDir) moveToz(zPos);
        else moveTox(xPos);

    }
}
