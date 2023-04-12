using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectSelection : MonoBehaviour
{
    
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject objectController;
    [SerializeField] private GameObject cameraController;
    [SerializeField] private GameObject hudController;
    [SerializeField] private GameObject inputController;
    private MoveModeSettings moveModeSettings;
    private ObjectMovement objectMovement;
    private ObjectRotation objectRotation;
    private ObjectScale objectScale;
    private CameraMovement cameraMovement;
    private HUDObjectModification hudObjectModification;

    public GameObject selectedObject;
    public GameObject previousSelectedObject;
    public bool isSelectedObject = false;
    RaycastHit hit;
    Ray rayOrigin;
    GameObject objectClicked;
    
    //assign the main camera
    private void Awake() {
        mainCamera = Camera.main;
        objectMovement = objectController.GetComponent<ObjectMovement>();
        objectRotation = objectController.GetComponent<ObjectRotation>();
        objectScale = objectController.GetComponent<ObjectScale>();
        cameraMovement = cameraController.GetComponent<CameraMovement>();
        hudObjectModification = hudController.GetComponent<HUDObjectModification>();
        moveModeSettings = inputController.GetComponent<MoveModeSettings>();
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
        objectMovement.setMainObjectMovement(selectedObject);
        objectRotation.setMainObjectRotation(selectedObject);
        objectScale.setMainObjectScale(selectedObject);
        if (moveModeSettings.getMoveMode() == moveModeSettings.getMoveModeArray()[0]){
        moveModeSettings.revertToPreviousMode();
        }
        // moveModeSettings.setMoveMode(moveModeSettings.getMoveModeArray()[1]);
        hudObjectModification.ShowModifiers();
        hudObjectModification.UpdateOnObjectMove();
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
        hudObjectModification.HideModifiers();
        moveModeSettings.setMoveMode(moveModeSettings.getMoveModeArray()[0]);
    }
}
