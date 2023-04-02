using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndClicks : MonoBehaviour
{
    [SerializeField] private GameObject cameraController;
    [SerializeField] private GameObject objectController;
    [SerializeField] private GameObject inputController;
    [SerializeField] private GameObject hudController;
    HUDObjectModification hudObjectModification;
    private CameraMovement cameraMovement;
    private ObjectRotation objectRotation;
    private ObjectMovement objectMovement;
    private ObjectScale objectScale;
    private ObjectSelection objectSelection;
    private ObjectDeletion objectDeletion;
    private MoveModeSettings moveModeSettings;


    private void Awake() {
        cameraMovement = cameraController.GetComponent<CameraMovement>();
        objectRotation = objectController.GetComponent<ObjectRotation>();
        objectMovement = objectController.GetComponent<ObjectMovement>();
        objectScale = objectController.GetComponent<ObjectScale>();
        objectSelection = objectController.GetComponent<ObjectSelection>();
        objectDeletion = objectController.GetComponent<ObjectDeletion>();
        moveModeSettings = inputController.GetComponent<MoveModeSettings>();
        hudObjectModification = hudController.GetComponent<HUDObjectModification>();
    }
  
  //listens for keyboard presses and mouse clicks, for user input controls
    void Update()
    {
    //keyboard movement controls
        //camera keyboard movement controls
        if (moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[0]){

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
        if(moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[2]){ 
            if (Input.GetKey(KeyCode.E))
            {
                KeyCode keypressed = KeyCode.E;
                objectRotation.RotateAroundUpAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                KeyCode keypressed = KeyCode.Q;
                objectRotation.RotateAroundDownAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                KeyCode keypressed = KeyCode.W;
                objectRotation.RotateAroundForwardAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                KeyCode keypressed = KeyCode.A;
                objectRotation.RotateAroundLeftAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                KeyCode keypressed = KeyCode.S;
                objectRotation.RotateAroundBackwardAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                KeyCode keypressed = KeyCode.D;
                objectRotation.RotateAroundRightAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
        }
        //object keyboard movemement controls
        if(moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[1]){
            if (Input.GetKey(KeyCode.E))
            {   
                KeyCode keypressed = KeyCode.E;
                objectMovement.MoveUp();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                KeyCode keypressed = KeyCode.Q;
                objectMovement.MoveDown();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                KeyCode keypressed = KeyCode.W;
                objectMovement.MoveForward();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                KeyCode keypressed = KeyCode.A;
                objectMovement.MoveLeft();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                KeyCode keypressed = KeyCode.S;
                objectMovement.MoveBackward();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                KeyCode keypressed = KeyCode.D;
                objectMovement.MoveRight();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
        }
        //object keyboard scale controls
        if(moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[3]){
            if (Input.GetKey(KeyCode.E))
            {   
                KeyCode keypressed = KeyCode.E;
                objectScale.ScaleUp();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                KeyCode keypressed = KeyCode.Q;
                objectScale.ScaleDown();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                KeyCode keypressed = KeyCode.W;
                objectScale.ScaleForward();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                KeyCode keypressed = KeyCode.A;
                objectScale.ScaleLeft();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                KeyCode keypressed = KeyCode.S;
                objectScale.ScaleBackward();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                KeyCode keypressed = KeyCode.D;
                objectScale.ScaleRight();
                hudObjectModification.UpdateOnObjectMove(keypressed);
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
            objectRotation.ObjectRotateOn();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            objectMovement.ObjectMoveOn();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            objectScale.ObjectScaleOn();
        }



        //mouse object manipulation controls
        if (Input.GetMouseButtonDown(0)){
            objectSelection.ClickObject();
        }


        //camera manipulation controls
          if (Input.GetKeyDown(KeyCode.C))
        {
            cameraMovement.CameraMoveOn();
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
