using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeletion : MonoBehaviour
{
    //removes the selected object
    public void DeleteObject(){
        if (GetComponent<ObjectSelection>().isSelectedObject == true){
           
            GetComponent<ObjectCreation>().createdObjectList.RemoveAll
            (GameObject => GameObject.name == GetComponent<ObjectSelection>().selectedObject.name);

            GetComponent<ObjectSelection>().DeselectObject();
            Destroy(GetComponent<ObjectSelection>().selectedObject);
            

        }
    }
}
