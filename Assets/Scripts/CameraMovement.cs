using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;


public class CameraMovement : MonoBehaviour
{
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float verticalCamSpeed;
    [SerializeField] private float horizontalCamSpeed;
    [SerializeField] private float rotationAlongX;
    [SerializeField] private float rotationAlongY;
    [SerializeField] private float sensitivity;
    [SerializeField] private GameObject objectController;
    bool cameraMoveToggle;
    HUDObjectCreation hudObjectCreation;
    ObjectSelection objectSelection;
    Vector3 currentCamPosition;
    float currentCamRotationX;
    float currentCamRotationY;
    float mousePosX;
    float mousePosY;

    //assign the main camera
    private void Awake() {
    mainCamera = Camera.main;
    hudObjectCreation = objectController.GetComponent<HUDObjectCreation>();
    objectSelection = objectController.GetComponent<ObjectSelection>();
    }

    //move the camera upwards
    public void MoveUp (){
        EventSystem.current.SetSelectedGameObject(null);
        currentCamPosition = mainCamera.transform.position;
        mainCamera.transform.position +=  mainCamera.transform.up * verticalCamSpeed * Time.deltaTime;
    }

    //move the camera downwards
    public void MoveDown (){
        EventSystem.current.SetSelectedGameObject(null);
        currentCamPosition = mainCamera.transform.position;
        mainCamera.transform.position -=  mainCamera.transform.up * verticalCamSpeed * Time.deltaTime;
    }

     //move the camera left
    public void MoveLeft (){
        EventSystem.current.SetSelectedGameObject(null);
        currentCamPosition = mainCamera.transform.position;
        mainCamera.transform.position -=  mainCamera.transform.right * horizontalCamSpeed * Time.deltaTime;
    }

  //move the camera right
    public void MoveRight (){
        EventSystem.current.SetSelectedGameObject(null);
        currentCamPosition = mainCamera.transform.position;
         mainCamera.transform.position +=  mainCamera.transform.right * horizontalCamSpeed * Time.deltaTime;
    }

    //move the camera forward
    public void MoveForward (){
        EventSystem.current.SetSelectedGameObject(null);
        currentCamPosition = mainCamera.transform.position;
        mainCamera.transform.position +=  mainCamera.transform.forward * horizontalCamSpeed * Time.deltaTime;
    }
     //move the camera backward
    public void MoveBackward (){
        EventSystem.current.SetSelectedGameObject(null);
        currentCamPosition = mainCamera.transform.position;
        mainCamera.transform.position -=  mainCamera.transform.forward * horizontalCamSpeed * Time.deltaTime;
    }

    //rotate the camera to look around
    public void Rotate (){
        currentCamRotationX = mainCamera.transform.rotation.x;
        currentCamRotationY = mainCamera.transform.rotation.y;

        mousePosX = Input.GetAxis("Mouse X");
        mousePosY = Input.GetAxis("Mouse Y");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //note: mouse position is inverse to rotation axis, therefore rAY += mPX
        rotationAlongY += mousePosX * sensitivity * Time.deltaTime;
        rotationAlongX += mousePosY * sensitivity * Time.deltaTime;
       
        mainCamera.transform.rotation = Quaternion.Euler (currentCamRotationX - rotationAlongX,
                                                        currentCamRotationY + rotationAlongY,
                                                        0);
    }

    //toggles between camera WASD movement and object WASD
    public void CameraMoveToggle(){
        if (hudObjectCreation.getCreatedObjectList()?.Any() ?? false){
           if (objectSelection.isSelectedObject == true){
                cameraMoveToggle = !cameraMoveToggle;
           }
        }
    }

    //turns camera WASD movement to object WASD
    public void CameraMoveOff(){
        if (hudObjectCreation.getCreatedObjectList()?.Any() ?? false){
            cameraMoveToggle = false;
        }
    }

    //turns object WASD to camera WASD movement
     public void CameraMoveOn(){
            cameraMoveToggle = true;
    }

    public bool getCameraMoveToggle(){
        return cameraMoveToggle;
    }

}
