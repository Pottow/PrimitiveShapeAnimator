using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndClicks : MonoBehaviour
{
    [SerializeField] private GameObject cameraController;
    [SerializeField] private GameObject objectController;
    [SerializeField] private GameObject inputController;
    [SerializeField] private GameObject hudController;
    private HUDObjectModification hudObjectModification;
    private CameraMovement cameraMovement;
    private ObjectRotation objectRotation;
    private ObjectMovement objectMovement;
    private ObjectScale objectScale;
    private ObjectSelection objectSelection;
    private ObjectDeletion objectDeletion;
    private ObjectDuplication objectDuplication;
    private MoveModeSettings moveModeSettings;
    private DefaultKeyBindings defaultKeyBindings;


    private void Awake() {
        cameraMovement = cameraController.GetComponent<CameraMovement>();
        objectRotation = objectController.GetComponent<ObjectRotation>();
        objectMovement = objectController.GetComponent<ObjectMovement>();
        objectScale = objectController.GetComponent<ObjectScale>();
        objectSelection = objectController.GetComponent<ObjectSelection>();
        objectDeletion = objectController.GetComponent<ObjectDeletion>();
        objectDuplication = objectController.GetComponent<ObjectDuplication>();
        moveModeSettings = inputController.GetComponent<MoveModeSettings>();
        defaultKeyBindings = inputController.GetComponent<DefaultKeyBindings>();
        hudObjectModification = hudController.GetComponent<HUDObjectModification>();
    }
  
  //listens for keyboard presses and mouse clicks, for user input controls
    void Update()
    {
    //keyboard movement controls
        //camera keyboard movement controls
        if (moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[0]){

            if (Input.GetKey(defaultKeyBindings.Up))
            {
                cameraMovement.MoveUp();
            }
            if (Input.GetKey(defaultKeyBindings.Down))
            {
                cameraMovement.MoveDown();
            }
            if (Input.GetKey(defaultKeyBindings.Forward))
            {
                cameraMovement.MoveForward();
            }

            if (Input.GetKey(defaultKeyBindings.Left))
            {
                cameraMovement.MoveLeft();
            }

            if (Input.GetKey(defaultKeyBindings.Back))
            {
                cameraMovement.MoveBackward();
            }

            if (Input.GetKey(defaultKeyBindings.Right))
            {
                cameraMovement.MoveRight();
            }
        }

       //object keyboard rotation controls
        if(moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[2]){ 
            if (Input.GetKey(defaultKeyBindings.Up))
            {
                KeyCode keypressed = defaultKeyBindings.Up;
                objectRotation.RotateAroundUpAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Down))
            {
                KeyCode keypressed = defaultKeyBindings.Down;
                objectRotation.RotateAroundDownAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Forward))
            {
                KeyCode keypressed = defaultKeyBindings.Forward;
                objectRotation.RotateAroundForwardAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Left))
            {
                KeyCode keypressed = defaultKeyBindings.Left;
                objectRotation.RotateAroundLeftAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Back))
            {
                KeyCode keypressed = defaultKeyBindings.Back;
                objectRotation.RotateAroundBackwardAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Right))
            {
                KeyCode keypressed = defaultKeyBindings.Right;
                objectRotation.RotateAroundRightAxis();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
        }
        //object keyboard movemement controls
        if(moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[1]){
            if (Input.GetKey(defaultKeyBindings.Up))
            {   
                KeyCode keypressed = defaultKeyBindings.Up;
                objectMovement.MoveUp();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Down))
            {
                KeyCode keypressed = defaultKeyBindings.Down;
                objectMovement.MoveDown();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Forward))
            {
                KeyCode keypressed = defaultKeyBindings.Forward;
                objectMovement.MoveForward();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Left))
            {
                KeyCode keypressed = defaultKeyBindings.Left;
                objectMovement.MoveLeft();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Back))
            {
                KeyCode keypressed = defaultKeyBindings.Back;
                objectMovement.MoveBackward();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Right))
            {
                KeyCode keypressed = defaultKeyBindings.Right;
                objectMovement.MoveRight();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
        }
        //object keyboard scale controls
        if(moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[3]){
            if (Input.GetKey(defaultKeyBindings.Up))
            {   
                KeyCode keypressed = defaultKeyBindings.Up;
                objectScale.ScaleUp();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Down))
            {
                KeyCode keypressed = defaultKeyBindings.Down;
                objectScale.ScaleDown();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Forward))
            {
                KeyCode keypressed = defaultKeyBindings.Forward;
                objectScale.ScaleForward();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Left))
            {
                KeyCode keypressed = defaultKeyBindings.Left;
                objectScale.ScaleLeft();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Back))
            {
                KeyCode keypressed = defaultKeyBindings.Back;
                objectScale.ScaleBackward();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
            if (Input.GetKey(defaultKeyBindings.Right))
            {
                KeyCode keypressed = defaultKeyBindings.Right;
                objectScale.ScaleRight();
                hudObjectModification.UpdateOnObjectMove(keypressed);
            }
        }
   

        //keyboard object manipulation controls
        if (Input.GetKeyDown(defaultKeyBindings.Deselect))
        {
            objectSelection.DeselectObject();
        }
        if (Input.GetKeyDown(defaultKeyBindings.Delete))
        {
            objectDeletion.DeleteObject();
        }
        if (Input.GetKeyDown(defaultKeyBindings.RotateMode))
        {
            objectRotation.ObjectRotateOn();
        }
        if (Input.GetKeyDown(defaultKeyBindings.MoveMode))
        {
            objectMovement.ObjectMoveOn();
        }
        if (Input.GetKeyDown(defaultKeyBindings.ScaleMode))
        {
            objectScale.ObjectScaleOn();
        }



        //combos
        if (Input.GetKey(defaultKeyBindings.ComboKey))
        {
            if (Input.GetKeyDown(defaultKeyBindings.Duplicate)){
                objectDuplication.DuplicateObject();
            }
        }
            

        //mouse object manipulation controls
        if (Input.GetMouseButtonDown(0)){
            objectSelection.ClickObject();
        }


        //camera manipulation controls
          if (Input.GetKeyDown(defaultKeyBindings.CameraMode))
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
         if (Input.GetKeyDown(defaultKeyBindings.Quit)){
            Application.Quit();
        }
    }
}
