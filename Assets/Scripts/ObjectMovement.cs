using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMovement : MonoBehaviour
{
    
    [SerializeField] private Camera mainCamera;
    GameObject mainObjectMovement;
    Vector3 currentObjPosition;
    float verticalObjSpeed = 4f;
    float horizontalObjSpeed = 5f;

    //assign the main camera
    private void Awake() {
    mainCamera = Camera.main;
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

    public GameObject setMainObjectMovement(GameObject mainObject){
        return mainObjectMovement = mainObject;
    }

}
