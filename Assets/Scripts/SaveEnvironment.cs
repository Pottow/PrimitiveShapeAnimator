using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveEnvironment : MonoBehaviour
{

    [SerializeField] GameObject hudController;
    Camera mainCamera;
    HUDObjectCreation hudObjectCreation;

    List<GameObject> objectList;
    
    int objectIndex;
    float posX;
    float posY;
    float posZ;
    
    float rotX;
    float rotY;
    float rotZ;

    float scaleX;
    float scaleY;
    float scaleZ;

    string savePath;
    float []  singleObjectData;
    List <float[]> objectData;
    StreamWriter writer;

    

    private void Awake() {
        mainCamera = Camera.main;
        hudObjectCreation = hudController.GetComponent<HUDObjectCreation>();
        objectData = new List<float[]>();
    }

    public void SaveObjectPositions(){
        objectList = hudObjectCreation.getCreatedObjectList();
        objectIndex = 0;
        foreach (var objects in objectList)
        {
            
            posX = objects.transform.position.x;
            posY = objects.transform.position.y;
            posZ = objects.transform.position.z;

            CleanXRotation(objects);
            rotY = objects.transform.localEulerAngles.y;
            rotZ = objects.transform.localEulerAngles.z;

            scaleX = objects.transform.localScale.x;
            scaleY = objects.transform.localScale.y;
            scaleZ = objects.transform.localScale.z;

            singleObjectData = new float [] {objectIndex, posX, posY, posZ, rotX, rotY, rotZ, scaleX, scaleY, scaleZ};
            objectData.Add(singleObjectData);
            objectIndex = objectIndex + 1;
        }

            for (int x = 0; x <= 100; x++){
                if(x == 100){
                    Debug.Log("File saved and maximum save limit reached. Remove save files to save more.");
                }

                savePath = Application.persistentDataPath + "/saveFile" + x + ".txt";
                if (!File.Exists(savePath)){
                    writer = new StreamWriter(savePath, true);
                    foreach (float [] singleObject in objectData){
                        foreach (float objectDatum in singleObject){
                            writer.Write(objectDatum + ",");
                        }
                        writer.WriteLine();
                    }
                    writer.Close();
                    break;
                }
            }
    }

     public void CleanXRotation(GameObject savingObject){
        if (savingObject.transform.localEulerAngles.y >= 180 
            && savingObject.transform.localEulerAngles.z >= 180
            && savingObject.transform.localEulerAngles.x <= 90){
                rotX =  (-1 * savingObject.transform.localEulerAngles.x + 180);
            }
        else if (savingObject.transform.localEulerAngles.y < 180 
            && savingObject.transform.localEulerAngles.z < 180
            && savingObject.transform.localEulerAngles.x < 90){
                rotX = (savingObject.transform.localEulerAngles.x);
            }
        else if (savingObject.transform.localEulerAngles.y >= 180 
        && savingObject.transform.localEulerAngles.z >= 180
        && savingObject.transform.localEulerAngles.x > 270){
            rotX = (-1 * savingObject.transform.localEulerAngles.x + 540);
        }  
        else 
        {
            rotX = (savingObject.transform.localEulerAngles.x);
        }
    }
}