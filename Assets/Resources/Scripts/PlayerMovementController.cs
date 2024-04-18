using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float defaultMovementSpeed;
    public float extraAccelereationSpeed;
    public float breakingFactor;
    public float defaultTurnSpeed;

    private void FixedUpdate()
    {
        //define forward speed and break
        float movementSpeed = defaultMovementSpeed;
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movementSpeed += extraAccelereationSpeed;
        }else if(Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S)){
            movementSpeed *= breakingFactor;
        }

        //move object according to defined speeds
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);

        //rotate left and right
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, defaultTurnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward, defaultTurnSpeed * Time.deltaTime);

        }
    }

}
