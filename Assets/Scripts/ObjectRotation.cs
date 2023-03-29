using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotation : MonoBehaviour
{
     [System.NonSerialized]
    public bool toggleRotation;
     [System.NonSerialized]
    public GameObject mainObjectRotation;
    Quaternion currentObjRotation;
    float rotationSpeed = 100;
    float currentForwardRotation;
    Camera mainCamera;
    
    //assign the main camera
    private void Start() {
        mainCamera = Camera.main;
    }

    //toggles object rotation mode
    public void ToggleRotation(){
        if (GetComponent<ObjectSelection>().isSelectedObject == true){
                toggleRotation = !toggleRotation;
                if (toggleRotation == true){
                    GetComponent<CameraMovement>().CameraMoveOff();
                }
        } 
    }

   //turns off object rotation mode
    public void ToggleRotationOff(){
        if (GetComponent<ObjectSelection>().isSelectedObject == true){
                toggleRotation = false;
        } 
    }

    //turns on object rotation mode
    public void ToggleRotationOn(){
        if (GetComponent<ObjectSelection>().isSelectedObject == true){
                toggleRotation = true;
        } 
    }

    //rotate the object around the vertical axis clockwise
    public void RotateAroundUpAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, mainCamera.transform.up) * currentObjRotation;
    }

    //rotate the object around the vertical axis anticlockwise
    public void RotateAroundDownAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -mainCamera.transform.up) * currentObjRotation;
    }

    //rotate the object around the front facing axis anticlockwise
    public void RotateAroundLeftAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, mainCamera.transform.forward) * currentObjRotation;

        
    }

    //rotate the object around the front facing axis clockwise
    public void RotateAroundRightAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -mainCamera.transform.forward) * currentObjRotation;
            
    }

    //rotate the object around the horizontal axis clockwise
    public void RotateAroundForwardAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, mainCamera.transform.right) * currentObjRotation;
    }
    //rotate the object around the horizontal axis anticlockwise
    public void RotateAroundBackwardAxis (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjRotation = mainObjectRotation.transform.rotation;
        mainObjectRotation.transform.rotation = 
            Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -mainCamera.transform.right) * currentObjRotation;
    }
}
