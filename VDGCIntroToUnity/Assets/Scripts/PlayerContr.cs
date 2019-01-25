using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    //some variables for the player.
    public int playerHorizontlalSpeed = 10;
    public int playerJumpSpeed = 200;

    //controller reference 
    public CharacterController myController;

    //movement holder 
    public Vector3 movementVector; 

    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //simple velocity set. 
        movementVector = new Vector3(Input.GetAxis("Horizontal") * playerHorizontlalSpeed, 0f, 0);

        bool jumpDown = Input.GetButtonDown("Jump");

        //handle jumping logic
        if (jumpDown)
        {

        }

        //handle side logic 


        //handle basic gravity 
        movementVector.y = movementVector.y + Physics.gravity.y;
        //utilize deltaTime 
        myController.Move(movementVector*Time.deltaTime);
    }
}
