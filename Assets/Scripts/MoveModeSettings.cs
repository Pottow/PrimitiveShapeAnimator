using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveModeSettings : MonoBehaviour
{
    [SerializeField] string moveMode;
    [SerializeField] string previousMoveMode;
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
    }

    //checks which move mode is currently active
    public void Update(){
        //gotta add switch rather than if/else
        if (cameraMovement.getCameraMoveToggle() == true){
            moveMode = "Camera";
        }
        else{
            if (objectRotation.toggleRotation == true){
                moveMode = "Rotate Object";
            }
            else{
                moveMode = "Move Object";
            }
        }
        if (previousMoveMode != moveMode){
            DisplayMoveMode(moveMode);
            previousMoveMode = moveMode;
            }
    }
    //displays move mode to user
    public void DisplayMoveMode(string moveMode){
        textMeshProUGUI.text = moveMode;
    }
}
