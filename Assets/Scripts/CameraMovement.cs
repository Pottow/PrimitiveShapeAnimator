using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;


public class CameraMovement : MonoBehaviour
{
    [System.NonSerialized]
    public bool cameraMoveToggle = true;
    Camera mainCamera;
    Vector3 currentCamPosition;
    float verticalCamSpeed = 4f;
    float horizontalCamSpeed = 5f;

    float currentCamRotationX;
    float currentCamRotationY;
    float rotationAlongX = 0.0f;
    float rotationAlongY = 0.0f;
    float sensitivity = 500f;
    float mousePosX;
    float mousePosY;

    //assign the main camera
    private void Start() {
    mainCamera = Camera.main;
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
        if (GetComponent<ObjectCreation>().createdObjectList?.Any() ?? false){
           if (GetComponent<ObjectSelection>().isSelectedObject == true){
                cameraMoveToggle = !cameraMoveToggle;
           }
        }
    }

    //turns camera WASD movement to object WASD
    public void CameraMoveOff(){
        if (GetComponent<ObjectCreation>().createdObjectList?.Any() ?? false){
            cameraMoveToggle = false;
        }
    }

    //turns object WASD to camera WASD movement
     public void CameraMoveOn(){
            cameraMoveToggle = true;
    }
}
