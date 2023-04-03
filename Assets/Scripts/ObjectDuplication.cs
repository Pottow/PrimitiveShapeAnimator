using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ObjectDuplication : MonoBehaviour
{
    [SerializeField] GameObject objectController;
    [SerializeField] GameObject hudController;
    HUDObjectCreation hudObjectCreation;
    HUDObjectModification hudObjectModification;
    ObjectSelection objectSelection;

    Vector3 selectedObjectPosition;
    Quaternion selectedObjectRotation;
    Vector3 selectedObjectScale;


    private void Awake() {
        objectSelection = objectController.GetComponent<ObjectSelection>();
        hudObjectCreation = hudController.GetComponent<HUDObjectCreation>();
    }

    public void DuplicateObject(){
        if (objectSelection.isSelectedObject ==true){
            selectedObjectPosition = objectSelection.selectedObject.transform.position;
            selectedObjectRotation = objectSelection.selectedObject.transform.rotation;
            selectedObjectScale = objectSelection.selectedObject.transform.localScale; 
            hudObjectCreation.CreateObject(objectSelection.selectedObject.GetComponent<MeshFilter>().sharedMesh.name);
            objectSelection.selectedObject.transform.position = selectedObjectPosition;
            objectSelection.selectedObject.transform.rotation = selectedObjectRotation;
            objectSelection.selectedObject.transform.localScale = selectedObjectScale;
        }
    }

}
