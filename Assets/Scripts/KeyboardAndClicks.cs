using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndClicks : MonoBehaviour
{
  
  //listens for keyboard presses and mouse clicks, for user input controls
    void Update()
    {
    //keyboard movement controls
        //camera keyboard movement controls
        if (GetComponent<CameraMovement>().cameraMoveToggle == true){

            if (Input.GetKey(KeyCode.E))
            {
                GetComponent<CameraMovement>().MoveUp();
            }
            if (Input.GetKey(KeyCode.Q))
            {
                GetComponent<CameraMovement>().MoveDown();
            }
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<CameraMovement>().MoveForward();
            }

            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<CameraMovement>().MoveLeft();
            }

            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<CameraMovement>().MoveBackward();
            }

            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<CameraMovement>().MoveRight();
            }
        }
       //object keyboard rotation controls
        else{
            if(GetComponent<ObjectRotation>().toggleRotation){ 
                if (Input.GetKey(KeyCode.E))
                {
                    GetComponent<ObjectRotation>().RotateAroundUpAxis();
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    GetComponent<ObjectRotation>().RotateAroundDownAxis();
                }
                if (Input.GetKey(KeyCode.W))
                {
                    GetComponent<ObjectRotation>().RotateAroundForwardAxis();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    GetComponent<ObjectRotation>().RotateAroundLeftAxis();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    GetComponent<ObjectRotation>().RotateAroundBackwardAxis();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    GetComponent<ObjectRotation>().RotateAroundRightAxis();
                }
            }
            //object keyboard movemement controls
            else{
                if (Input.GetKey(KeyCode.E))
                {
                    GetComponent<ObjectMovement>().MoveUp();
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    GetComponent<ObjectMovement>().MoveDown();
                }
                if (Input.GetKey(KeyCode.W))
                {
                    GetComponent<ObjectMovement>().MoveForward();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    GetComponent<ObjectMovement>().MoveLeft();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    GetComponent<ObjectMovement>().MoveBackward();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    GetComponent<ObjectMovement>().MoveRight();
                }
            }
        }

        //keyboard object manipulation controls
           if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<ObjectSelection>().DeselectObject();
        }
           if (Input.GetKeyDown(KeyCode.Delete))
        {
            GetComponent<ObjectDeletion>().DeleteObject();
        }
          if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<ObjectRotation>().ToggleRotation();
        }


        //mouse object manipulation controls
        if (Input.GetMouseButtonDown(0)){
            GetComponent<ObjectSelection>().ClickObject();
        }


        //camera manipulation controls
          if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<CameraMovement>().CameraMoveToggle();
        }

        //mouse camera manipulation controls
        if (Input.GetMouseButton(1)){
            GetComponent<CameraMovement>().Rotate();
        }
        if (Input.GetMouseButtonUp(1)){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //software controls
         if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
