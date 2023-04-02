using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectScale : MonoBehaviour
{
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject inputController;
    [SerializeField] private GameObject objectController;
    ObjectSelection objectSelection;
    MoveModeSettings moveModeSettings;
    GameObject mainObjectScale;
    Vector3 currentObjScale;
    float verticalObjSpeed = 4f;
    float horizontalObjSpeed = 5f;

    //assign the main camera
    private void Awake() {
    mainCamera = Camera.main;
    moveModeSettings = inputController.GetComponent<MoveModeSettings>();
    objectSelection = objectController.GetComponent<ObjectSelection>();
    }

    public GameObject setMainObjectScale(GameObject mainObject){
        return mainObjectScale = mainObject;
    }

    public void ObjectScaleOn(){
        if (objectSelection.isSelectedObject  
            && moveModeSettings.getMoveMode() != moveModeSettings.getMoveModeArray()[3]){
                    moveModeSettings.setMoveMode(moveModeSettings.getMoveModeArray()[3]);
        }
        else{
            moveModeSettings.revertToCameraMode();
        }
    }

    //Scale the object upwards
    public void ScaleUp (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjScale = mainObjectScale.transform.localScale;
        mainObjectScale.transform.localScale +=  mainCamera.transform.up * verticalObjSpeed * Time.deltaTime;
    }

    //Scale the object downwards
    public void ScaleDown (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjScale = mainObjectScale.transform.localScale;
        mainObjectScale.transform.localScale -=  mainCamera.transform.up * verticalObjSpeed * Time.deltaTime;
    }

    //Scale the object left
    public void ScaleLeft (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjScale = mainObjectScale.transform.localScale;
        mainObjectScale.transform.localScale -=  mainCamera.transform.right * horizontalObjSpeed * Time.deltaTime;
    }

    //Scale the object right
    public void ScaleRight (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjScale = mainObjectScale.transform.localScale;
        mainObjectScale.transform.localScale +=  mainCamera.transform.right * horizontalObjSpeed * Time.deltaTime;
    }

    //Scale the object forward and away from the camera
    public void ScaleForward (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjScale = mainObjectScale.transform.localScale;
        mainObjectScale.transform.localScale +=  mainCamera.transform.forward * horizontalObjSpeed * Time.deltaTime;
    }

    //Scale the object backward and towards the camera
    public void ScaleBackward (){
        EventSystem.current.SetSelectedGameObject(null);
        currentObjScale = mainObjectScale.transform.localScale;
        mainObjectScale.transform.localScale -=  mainCamera.transform.forward * horizontalObjSpeed * Time.deltaTime;
    }
}

