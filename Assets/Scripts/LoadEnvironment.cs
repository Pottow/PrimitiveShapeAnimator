using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadEnvironment : MonoBehaviour
{
    [SerializeField] GameObject hudController;
    Camera mainCamera;
    HUDObjectCreation hudObjectCreation;
    HUDObjectModification hudObjectModification;

    // List<GameObject> objectList;
    
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
    StreamReader reader;

    

    private void Awake() {
        mainCamera = Camera.main;
        hudObjectCreation = hudController.GetComponent<HUDObjectCreation>();
        hudObjectModification = hudController.GetComponent<HUDObjectModification>();
        // objectData = new List<float[]>();
    }

    public void LoadObjectPositions(){
        //choose save file x
        int x= 0;
        //edit above line for when choosing is possible
        savePath = Application.persistentDataPath + "/saveFile" + x + ".txt";
        if (!File.Exists(savePath)){
            string [] allObjectData = File.ReadAllLines(savePath);
            for (int y = 0; y< allObjectData.Length; y++){
                string objectData = allObjectData[y];
                string [] splitObjectData = objectData.Split(",");
                float [] splitObjectFloats = new float [9]; 
                for (int j = 2; j < splitObjectFloats.Length; j++){
                    splitObjectFloats [j] = float.Parse(splitObjectData [j]);
                hudObjectCreation.CreateObject(splitObjectData [0]);
                hudObjectModification.SetTmpInputFieldStrings(splitObjectFloats);
                hudObjectModification.UpdateOnObjectMove();
                }
            }
            reader.Close();
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
