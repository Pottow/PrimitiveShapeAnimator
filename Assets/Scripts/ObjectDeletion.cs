using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeletion : MonoBehaviour
{
    private GameObject mainObjectDeletion;
    [SerializeField] GameObject objectController;
    [SerializeField] GameObject hudController;
    ObjectSelection objectSelection;
    HUDObjectCreation hudObjectCreation;
    int indexOfDeletedObject;

    public void Awake(){
        objectSelection = objectController.GetComponent<ObjectSelection>();
        hudObjectCreation = hudController.GetComponent<HUDObjectCreation>();
    }


    //removes the selected object 
    public void DeleteObject(){
        if (objectSelection.isSelectedObject == true){
           
            indexOfDeletedObject = hudObjectCreation.getCreatedObjectList().FindIndex
                (GameObject => GameObject.name == objectSelection.selectedObject.name);
            hudObjectCreation.getCreatedObjectList().RemoveAll 
                (GameObject => GameObject.name == objectSelection.selectedObject.name);

            hudObjectCreation.getCreatedObjectTypeList().RemoveAt(indexOfDeletedObject);

            objectSelection.DeselectObject();
            Destroy(objectSelection.selectedObject);
        }
    }

public void setMainObjectDeletion(GameObject mainObject){
    mainObjectDeletion = mainObject;
}

}
