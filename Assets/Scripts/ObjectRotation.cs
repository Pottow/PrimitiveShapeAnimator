using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] GameObject objectController;
    [SerializeField] GameObject cameraController;
    [SerializeField] private GameObject inputController;
    MoveModeSettings moveModeSettings;
    ObjectSelection objectSelection;
    CameraMovement cameraMovement;
    GameObject mainObjectRotation;
    Quaternion currentObjRotation;
    float rotationSpeed = 100;
    float currentForwardRotation;
    bool toggleRotation;
    
    
    
    //assign the main camera
    private void Awake() {
        mainCamera = Camera.main;
        objectSelection = objectController.GetComponent<ObjectSelection>();
        cameraMovement = cameraController.GetComponent<CameraMovement>();
        moveModeSettings = inputController.GetComponent<MoveModeSettings>();
    }

    public GameObject setMainObjectRotation(GameObject mainObject){
        return mainObjectRotation = mainObject;
    }

    public bool getToggleRotation(){
        return toggleRotation;
    }

    //toggles object rotation mode
    public void ObjectRotateOn(){
        if (objectSelection.isSelectedObject 
            && moveModeSettings.getMoveMode() != moveModeSettings.getMoveModeArray()[2]){
                    moveModeSettings.setMoveMode(moveModeSettings.getMoveModeArray()[2]);
        }
        else{
            moveModeSettings.revertToCameraMode();
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
