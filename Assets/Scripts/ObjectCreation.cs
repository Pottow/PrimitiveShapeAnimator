using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ObjectCreation : MonoBehaviour
{
    GameObject shapeChoice;
    string objectType;
    GameObject createdObject;
    [System.NonSerialized]
    public List<GameObject> createdObjectList = new List<GameObject>();
    int createdObjectID;

    //finds the dropdown box containing the choice of shapes
    private void Start() {
        shapeChoice = GameObject.Find("ShapeChoiceBox");
    }

    //creates a shape, instantiates it into the environment, and selects it
    public void CreateObject(){
        objectType = shapeChoice.GetComponent<TMP_Dropdown>().options 
                    [shapeChoice.GetComponent<TMP_Dropdown>().value].text;
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
        createdObject.name = "Object" + createdObjectID;
        GetComponent<ObjectSelection>().DeselectObjectForReselection();
        GetComponent<ObjectSelection>().SelectObject(createdObject);
        GetComponent<CameraMovement>().CameraMoveOff();
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

}
