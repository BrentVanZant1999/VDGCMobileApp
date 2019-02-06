using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float dist = 22.0f;

    //Creates the player object
    public GameObject player;

    //Creates the lighting object
    public GameObject Light;

    //Creates the block object
    public Transform block;

    //The variable tracking the camera's rotation
    float rotSpeed = 250.0f;

    //A function used to find a -pi to pi angle
    public double getAngleRad(Vector2 me, Vector2 target)
    {
        return System.Math.Atan2(target.y - me.y, target.x - me.x);
    }

    //A function used to find a -180 to 180 deg angle
    public double getAngleDeg(Vector2 me, Vector2 target)
    {
        return System.Math.Atan2(target.y - me.y, target.x - me.x) * (180 / System.Math.PI);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Finds player's position
        float xPos = player.transform.position.x;
        float zPos = player.transform.position.z;

        //Finds player's positin signs
        int xSign = System.Math.Sign(xPos);
        int zSign = System.Math.Sign(zPos);

        //Player position vector2
        Vector2 playerPos = new Vector2(xPos, zPos);

        //Block position vector2
        Vector2 blockPos = new Vector2(block.position.x, block.position.z);

        //Camera position vector2
        Vector2 camPos = new Vector2(transform.position.x, transform.position.z);

        //Direction Variables
        float start = (float)getAngleRad(Vector2.zero, camPos);
        float end;
        if (xPos == Globals.border * xSign && xPos != 0) end = (float)getAngleRad(Vector2.zero, new Vector2(dist * xSign, 0));
        else end = (float)getAngleRad(Vector2.zero, new Vector2(0, dist * zSign));

        //Finds the difference between the start and end positions
        float diff = (end - start) * (float)(180 / System.Math.PI);

        float rotDir;
        float direction = ((float)System.Math.Cos(start) * (float)System.Math.Sin(end)) - ((float)System.Math.Cos(end) * (float)System.Math.Sin(start));
        if (direction > 0.0f) rotDir = 1.0f;
        else rotDir = -1.0f;

        //Sets camera position
        if (xPos == Globals.border * xSign && xPos != 0)
        {
            //Checks whether the camera is in place yet
            if (transform.position.x != dist * xSign)
            {
                if (rotSpeed * Time.deltaTime < System.Math.Abs(diff)) transform.RotateAround(block.position, Vector3.up, rotSpeed * -rotDir * Time.deltaTime);
                else transform.position = new Vector3(dist * xSign, block.position.y, 0);
            }
        }
        else
        {
            //Checks if the camera is in place yet
            if (transform.position.z != dist * zSign)
            {
                if (rotSpeed * Time.deltaTime < System.Math.Abs(diff)) transform.RotateAround(block.position, Vector3.up, rotSpeed * -rotDir * Time.deltaTime);
                else transform.position = new Vector3(0, block.position.y, dist * zSign);
            }
        }

        //Sets the camera's rotation to watch the center
        transform.LookAt(block, Vector3.up);

        //Moves the light to the camera
        Light.transform.position = transform.position;
        Light.transform.LookAt(player.transform, Vector3.up);

    }
}
