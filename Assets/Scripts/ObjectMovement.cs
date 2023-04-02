using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMovement : MonoBehaviour
{
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject inputController;
    [SerializeField] private GameObject objectController;
    ObjectSelection objectSelection;
    MoveModeSettings moveModeSettings;
    GameObject mainObjectMovement;
    Vector3 currentObjPosition;
    float verticalObjSpeed = 4f;
    float horizontalObjSpeed = 5f;

    //assign the main camera
    private void Awake() {
    mainCamera = Camera.main;
    moveModeSettings = inputController.GetComponent<MoveModeSettings>();
    objectSelection = objectController.GetComponent<ObjectSelection>();
    }

    public GameObject setMainObjectMovement(GameObject mainObject){
        return mainObjectMovement = mainObject;
    }

    public void ObjectMoveOn(){
        if (objectSelection.isSelectedObject  
            && moveModeSettings.getMoveMode() != moveModeSettings.getMoveModeArray()[1]){
                    moveModeSettings.setMoveMode(moveModeSettings.getMoveModeArray()[1]);
        }
        else{
            moveModeSettings.revertToCameraMode();
        }
    }

    //move the object upwards
    public void MoveUp (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObjectMovement.transform.position;
        mainObjectMovement.transform.position +=  mainCamera.transform.up * verticalObjSpeed * Time.deltaTime;
    }

    //move the object downwards
    public void MoveDown (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObjectMovement.transform.position;
        mainObjectMovement.transform.position -=  mainCamera.transform.up * verticalObjSpeed * Time.deltaTime;
    }

    //move the object left
    public void MoveLeft (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObjectMovement.transform.position;
        mainObjectMovement.transform.position -=  mainCamera.transform.right * horizontalObjSpeed * Time.deltaTime;
    }

    //move the object right
    public void MoveRight (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObjectMovement.transform.position;
         mainObjectMovement.transform.position +=  mainCamera.transform.right * horizontalObjSpeed * Time.deltaTime;
    }

    //move the object forward and away from the camera
    public void MoveForward (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObjectMovement.transform.position;
        mainObjectMovement.transform.position +=  mainCamera.transform.forward * horizontalObjSpeed * Time.deltaTime;
    }

    //move the object backward and towards the camera
    public void MoveBackward (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjPosition = mainObjectMovement.transform.position;
        mainObjectMovement.transform.position -=  mainCamera.transform.forward * horizontalObjSpeed * Time.deltaTime;
    }
}
