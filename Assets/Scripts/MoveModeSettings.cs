using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveModeSettings : MonoBehaviour
{
    string moveMode = "Camera";
    string previousMoveMode = "Camera";
    GameObject moveModeType;

    private void Start() {
        moveModeType = GameObject.Find("MoveModeType");
    }

    //checks which move mode is currently active
    public void Update(){
        if (GetComponent<CameraMovement>().cameraMoveToggle == true){
            moveMode = "Camera";
        }
        else{
            if (GetComponent<ObjectRotation>().toggleRotation == true){
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
        moveModeType.GetComponent<TextMeshProUGUI>().text = moveMode;
    }
}
