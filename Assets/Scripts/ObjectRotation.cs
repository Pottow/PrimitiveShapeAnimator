using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] GameObject objectController;
    [SerializeField] GameObject cameraController;
    ObjectSelection objectSelection;
    CameraMovement cameraMovement;
    GameObject mainObjectRotation;
    Quaternion currentObjRotation;
    float rotationSpeed = 100;
    float currentForwardRotation;
    public bool toggleRotation;
    
    
    
    //assign the main camera
    private void Awake() {
        mainCamera = Camera.main;
        objectSelection = objectController.GetComponent<ObjectSelection>();
        cameraMovement = cameraController.GetComponent<CameraMovement>();
    }

    //toggles object rotation mode
    public void ToggleRotation(){
        if (objectSelection.isSelectedObject == true){
                toggleRotation = !toggleRotation;
                if (toggleRotation == true){
                    cameraMovement.CameraMoveOff();
                }
        } 
    }

   //turns off object rotation mode
    public void ToggleRotationOff(){
        if (objectSelection.isSelectedObject == true){
                toggleRotation = false;
        } 
    }

    //turns on object rotation mode
    public void ToggleRotationOn(){
        if (objectSelection.isSelectedObject == true){
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


    public GameObject setMainObjectRotation(GameObject mainObject){
        return mainObjectRotation = mainObject;
    }
}
