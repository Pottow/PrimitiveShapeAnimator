using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndClicks : MonoBehaviour
{
    [SerializeField] private GameObject cameraController;
    [SerializeField] private GameObject objectController;
    private CameraMovement cameraMovement;
    private ObjectRotation objectRotation;
    private ObjectMovement objectMovement;
    private ObjectSelection objectSelection;
    private ObjectDeletion objectDeletion;


    private void Awake() {
        cameraMovement = cameraController.GetComponent<CameraMovement>();
        objectRotation = objectController.GetComponent<ObjectRotation>();
        objectMovement = objectController.GetComponent<ObjectMovement>();
        objectSelection = objectController.GetComponent<ObjectSelection>();
        objectDeletion = objectController.GetComponent<ObjectDeletion>();
    }
  
  //listens for keyboard presses and mouse clicks, for user input controls
    void Update()
    {
    //keyboard movement controls
        //camera keyboard movement controls
        if (cameraMovement.getCameraMoveToggle() == true){

            if (Input.GetKey(KeyCode.E))
            {
                cameraMovement.MoveUp();
            }
            if (Input.GetKey(KeyCode.Q))
            {
                cameraMovement.MoveDown();
            }
            if (Input.GetKey(KeyCode.W))
            {
                cameraMovement.MoveForward();
            }

            if (Input.GetKey(KeyCode.A))
            {
                cameraMovement.MoveLeft();
            }

            if (Input.GetKey(KeyCode.S))
            {
                cameraMovement.MoveBackward();
            }

            if (Input.GetKey(KeyCode.D))
            {
                cameraMovement.MoveRight();
            }
        }
       //object keyboard rotation controls
        else{
            if(objectRotation.toggleRotation){ 
                if (Input.GetKey(KeyCode.E))
                {
                    objectRotation.RotateAroundUpAxis();
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    objectRotation.RotateAroundDownAxis();
                }
                if (Input.GetKey(KeyCode.W))
                {
                    objectRotation.RotateAroundForwardAxis();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    objectRotation.RotateAroundLeftAxis();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    objectRotation.RotateAroundBackwardAxis();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    objectRotation.RotateAroundRightAxis();
                }
            }
            //object keyboard movemement controls
            else{
                if (Input.GetKey(KeyCode.E))
                {
                    objectMovement.MoveUp();
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    objectMovement.MoveDown();
                }
                if (Input.GetKey(KeyCode.W))
                {
                    objectMovement.MoveForward();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    objectMovement.MoveLeft();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    objectMovement.MoveBackward();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    objectMovement.MoveRight();
                }
            }
        }

        //keyboard object manipulation controls
           if (Input.GetKeyDown(KeyCode.Space))
        {
            objectSelection.DeselectObject();
        }
           if (Input.GetKeyDown(KeyCode.Delete))
        {
            objectDeletion.DeleteObject();
        }
          if (Input.GetKeyDown(KeyCode.R))
        {
            objectRotation.ToggleRotation();
        }


        //mouse object manipulation controls
        if (Input.GetMouseButtonDown(0)){
            objectSelection.ClickObject();
        }


        //camera manipulation controls
          if (Input.GetKeyDown(KeyCode.C))
        {
            cameraMovement.CameraMoveToggle();
        }

        //mouse camera manipulation controls
        if (Input.GetMouseButton(1)){
            cameraMovement.Rotate();
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
