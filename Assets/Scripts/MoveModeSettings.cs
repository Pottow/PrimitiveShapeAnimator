using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveModeSettings : MonoBehaviour
{
    [SerializeField] string moveMode;
    [SerializeField] string previousMoveMode;
    [SerializeField] string [] moveModeArray;
    [SerializeField] private GameObject cameraController;
    [SerializeField] private GameObject objectController;
    [SerializeField] private GameObject moveModeType;

    private CameraMovement cameraMovement;
    private ObjectRotation objectRotation;
    private TextMeshProUGUI textMeshProUGUI;
    

    private void Awake() {
        cameraMovement = cameraController.GetComponent<CameraMovement>();
        objectRotation = objectController.GetComponent<ObjectRotation>();
        textMeshProUGUI = moveModeType.GetComponent<TextMeshProUGUI>();
        moveModeArray = new string [] {"Camera", "Move Object", "Rotate Object", "Scale Object"};
    }


     public string [] getMoveModeArray(){
        return moveModeArray;
    }
    
    public string getMoveMode(){
        return moveMode;
    }

    public void setMoveMode(string setMoveMode){
        previousMoveMode = moveMode;
        moveMode = setMoveMode;
        textMeshProUGUI.text = moveMode;
    }
    public void revertToCameraMode(){
        setMoveMode(getMoveModeArray()[0]);
        textMeshProUGUI.text = moveMode;
    }

    public void revertToPreviousMode(){
        moveMode = previousMoveMode;
        textMeshProUGUI.text = moveMode;
    }
}
