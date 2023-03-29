using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSelection : MonoBehaviour
{
     [System.NonSerialized]
    public GameObject selectedObject;
     [System.NonSerialized]
    public GameObject previousSelectedObject;
    [System.NonSerialized]
    public bool isSelectedObject = false;
    RaycastHit hit;
    Ray rayOrigin;
    Camera mainCamera;
    GameObject objectClicked;
    
    //assign the main camera
    private void Start() {
        mainCamera = Camera.main;
    }
    
    //on click, check whether an object, the gui, or the void has been clicked and respond
    public void ClickObject(){
        rayOrigin = mainCamera.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast (rayOrigin, out hit, 100)){
            objectClicked = hit.transform.gameObject;
            if (!EventSystem.current.IsPointerOverGameObject()){
                DeselectObjectForReselection();
                SelectObject(objectClicked);
            }
        }
        else if (!EventSystem.current.IsPointerOverGameObject()){
            DeselectObject();
        }
    }

    //highlight the selected object in yellow
    public void HighlightSelectedObject(GameObject objectSelected){
        objectSelected.GetComponent<Renderer>().material.color = Color.yellow; 
    }

    //assign the selectedObject variable and pass it to other scripts
    public void SelectObject(GameObject objSelectedOrCreated){
        selectedObject = objSelectedOrCreated;
        HighlightSelectedObject(selectedObject);
        GetComponent<ObjectMovement>().mainObject = selectedObject;
        GetComponent<ObjectRotation>().mainObjectRotation = selectedObject;
        GetComponent<CameraMovement>().CameraMoveOff();
        GetComponent<ObjectModification>().ShowModifiers();
        isSelectedObject = true;

        previousSelectedObject = selectedObject;
    }

    //remove highlight when an object is deselected
    public void DehighlightSelectedObject(){
        if (previousSelectedObject != null){
            previousSelectedObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    //deselect one object by selecting another
    public void DeselectObjectForReselection(){
        if (previousSelectedObject != null){
            DehighlightSelectedObject ();
        }
        isSelectedObject = false;
    }

    //deselect all objects and switch back to camera view
    public void DeselectObject(){
        DeselectObjectForReselection();
        GetComponent<ObjectModification>().HideModifiers();
        GetComponent<CameraMovement>().CameraMoveOn();

    }
}
