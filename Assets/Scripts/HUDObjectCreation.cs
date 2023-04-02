using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HUDObjectCreation : MonoBehaviour
{
    [SerializeField] GameObject shapeChoice;
    [SerializeField] GameObject cameraController;
    [SerializeField] GameObject objectController;
    [SerializeField] GameObject inputController;
    MoveModeSettings moveModeSettings;
    ObjectSelection objectSelection;
    CameraMovement cameraMovement;
    TMP_Dropdown tmp_Dropdown;
    GameObject createdObject;
    string objectType;
    private List<GameObject> createdObjectList = new List<GameObject>();
    int createdObjectID;

    private void Awake() {
        tmp_Dropdown = shapeChoice.GetComponent<TMP_Dropdown>();
        objectSelection = objectController.GetComponent<ObjectSelection>();
        cameraMovement = cameraController.GetComponent<CameraMovement>();
        moveModeSettings = inputController.GetComponent<MoveModeSettings>();
    }

    //creates a shape, instantiates it into the environment, and selects it
    public void CreateObject(){
        objectType = tmp_Dropdown.options 
                    [tmp_Dropdown.value].text;
        switch (objectType){
            case "Cube":
                createdObject = CreateCube();
                break;
            case "Sphere":
                createdObject = CreateSphere();
                break;
            case "Capsule":
                createdObject = CreateCapsule();
                break;
            case "Cylinder":
                createdObject = CreateCylinder();
                break;
            case "Plane":
                createdObject = CreatePlane();
                break;
            case "Quad":
                createdObject = CreateQuad();
                break;
            default:
                createdObject = CreateCube();
                break;
        }
        createdObjectList.Add(createdObject);
        createdObjectID = createdObjectList.IndexOf(createdObjectList [^1]);
        createdObject.name = "Object" + createdObjectID + " (" + objectType +")";
        objectSelection.DeselectObjectForReselection();
        objectSelection.SelectObject(createdObject);
        EventSystem.current.SetSelectedGameObject(null);
    }

    //creates a specific shape: cube, sphere, etc.
    GameObject CreateCube() {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0, 0);
        return cube;
    }
    GameObject CreateSphere() {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(0, 0, 0);
        return sphere;
    }
    GameObject CreateCapsule() {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(0, 0, 0);
        return capsule;
    }
    GameObject CreateCylinder() {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.position = new Vector3(0, 0, 0);
        return cylinder;
    }

    GameObject CreatePlane(){
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.position = new Vector3(0, 0, 0);
        return plane;
    }

    GameObject CreateQuad(){
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.transform.position = new Vector3(0, 0, 0);
        return quad;
    }


    public List<GameObject> getCreatedObjectList(){
        return createdObjectList;
    }
}
