using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Linq;


public class ObjectModification : MonoBehaviour
{
    GameObject mainObjectModification;
    GameObject shapeModifiers;
    GameObject xPos;
    GameObject yPos;
    GameObject zPos;
    GameObject xRot;
    GameObject yRot;
    GameObject zRot;
    GameObject xScale;
    GameObject yScale;
    GameObject zScale;

    string xPosText;
    string yPosText;
    string zPosText;
    string xRotText;
    string yRotText;
    string zRotText;
    string xScaleText;
    string yScaleText;
    string zScaleText;
    float testForBadInput;

    float xPosFloat;
    float yPosFloat;
    float zPosFloat;
    float xRotFloat;
    float yRotFloat;
    float zRotFloat;
    float xScaleFloat;
    float yScaleFloat;
    float zScaleFloat;
    Vector3 mainObjectModificationPos;
    Quaternion mainObjectModificationRot;
    Vector3 mainObjectModificationScale;
    bool isUserMakingModifications;

    // locates shape modifying input fields and the shape modifying tab
    private void Start()
    {   
        EventSystem.current.SetSelectedGameObject(null);
        xPos = GameObject.Find("XPos");
        yPos = GameObject.Find("YPos");
        zPos = GameObject.Find("ZPos");
        xRot = GameObject.Find("XRot");
        yRot = GameObject.Find("YRot");
        zRot = GameObject.Find("ZRot");
        xScale = GameObject.Find("XScale");
        yScale = GameObject.Find("YScale");
        zScale = GameObject.Find("ZScale");
        shapeModifiers = GameObject.Find("ShapeModifiers");
        shapeModifiers.SetActive(false);
    }

    //show the shape modifying tab
    public void ShowModifiers (){
        shapeModifiers.SetActive(true);
        mainObjectModification = GetComponent<ObjectSelection>().selectedObject;
    }

    //hide the shape modifying tab
    public void HideModifiers (){
        shapeModifiers.SetActive(false);
    }

    //update input fields to match selected object's current rotation
    private void Update() {
        if (mainObjectModification != null  
            // && mainObjectModification.transform.position != mainObjectPreviousPos
            && isUserMakingModifications == false){
            xPos.GetComponent<TMP_InputField>().text = mainObjectModification.transform.position.x.ToString();
            yPos.GetComponent<TMP_InputField>().text = mainObjectModification.transform.position.y.ToString();
            zPos.GetComponent<TMP_InputField>().text = mainObjectModification.transform.position.z.ToString();
            if (mainObjectModification.transform.localEulerAngles.y >= 180 
                && mainObjectModification.transform.localEulerAngles.z >= 180
                && mainObjectModification.transform.localEulerAngles.x <= 90){
                    xRot.GetComponent<TMP_InputField>().text = 
                        (-1 * mainObjectModification.transform.localEulerAngles.x + 180).ToString();
                }
            else if (mainObjectModification.transform.localEulerAngles.y < 180 
                && mainObjectModification.transform.localEulerAngles.z < 180
                && mainObjectModification.transform.localEulerAngles.x < 90){
                    xRot.GetComponent<TMP_InputField>().text = 
                        (mainObjectModification.transform.localEulerAngles.x).ToString();
                }
            else if (mainObjectModification.transform.localEulerAngles.y >= 180 
            && mainObjectModification.transform.localEulerAngles.z >= 180
            && mainObjectModification.transform.localEulerAngles.x > 270){
                xRot.GetComponent<TMP_InputField>().text = 
                    (-1 * mainObjectModification.transform.localEulerAngles.x + 540).ToString();
            }  
            else 
            {
                xRot.GetComponent<TMP_InputField>().text = 
                    (mainObjectModification.transform.localEulerAngles.x).ToString();
            }
            

            yRot.GetComponent<TMP_InputField>().text = mainObjectModification.transform.localEulerAngles.y.ToString();
            zRot.GetComponent<TMP_InputField>().text = mainObjectModification.transform.localEulerAngles.z.ToString();
            xScale.GetComponent<TMP_InputField>().text = mainObjectModification.transform.localScale.x.ToString();
            yScale.GetComponent<TMP_InputField>().text = mainObjectModification.transform.localScale.y.ToString();
            zScale.GetComponent<TMP_InputField>().text = mainObjectModification.transform.localScale.z.ToString();
        }
    }

    //stops input fields from updating while user is modifying shape
    public void userModifying(){
        isUserMakingModifications = true;
    }

    //modifies selected shape according to values input by user into input fields
    public void updateUserModifications(){
            xPosText = xPos.GetComponent<TMP_InputField>().text;
            yPosText = yPos.GetComponent<TMP_InputField>().text;
            zPosText = zPos.GetComponent<TMP_InputField>().text;
            xRotText = xRot.GetComponent<TMP_InputField>().text;
            yRotText = yRot.GetComponent<TMP_InputField>().text;
            zRotText = zRot.GetComponent<TMP_InputField>().text;
            xScaleText = xScale.GetComponent<TMP_InputField>().text;
            yScaleText = yScale.GetComponent<TMP_InputField>().text; 
            zScaleText = zScale.GetComponent<TMP_InputField>().text;   

        xPosFloat = TestForBadInput(xPosText, false);
        yPosFloat = TestForBadInput(yPosText, false);
        zPosFloat = TestForBadInput(zPosText, false);
        xRotFloat = TestForBadInput(xRotText, false);
        yRotFloat = TestForBadInput(yRotText, false);
        zRotFloat = TestForBadInput(zRotText, false);
        xScaleFloat = TestForBadInput(xScaleText, true);
        yScaleFloat = TestForBadInput(yScaleText, true);
        zScaleFloat = TestForBadInput(zScaleText, true);
            
        mainObjectModification.transform.position = new Vector3 (xPosFloat, yPosFloat, zPosFloat);
        mainObjectModification.transform.rotation = Quaternion.Euler (xRotFloat, yRotFloat, zRotFloat);
        mainObjectModification.transform.localScale = new Vector3 (xScaleFloat, yScaleFloat, zScaleFloat);
    }

    //starts input fields updating when user is no longer modifying shape
    public void userStoppedModifying(){
        isUserMakingModifications = false;
    }

    //cleans the user input to be only numeric. Non-numeric and null go to default values.
    public float TestForBadInput(string shapeModInput, bool isScale){
        if (!float.TryParse(shapeModInput, out testForBadInput)
                || shapeModInput == null){
            if (isScale == true){
                testForBadInput = 1f;
            }
            else {
                testForBadInput = 0f;
            }
        }
        return testForBadInput;
    }

    //increments the input field value up by 1 and modifies the object accordingly
    public void IncrementModifier(GameObject inputField){
        userModifying();
        inputField.GetComponent<TMP_InputField>().text = 
            (float.Parse(inputField.GetComponent<TMP_InputField>().text) + 1f).ToString();
        updateUserModifications();
        userStoppedModifying();
    }

     //decrements the input field value down by 1 and modifies the object accordingly
     public void DecrementModifier(GameObject inputField){
        userModifying();
        inputField.GetComponent<TMP_InputField>().text = 
            (float.Parse(inputField.GetComponent<TMP_InputField>().text) - 1f).ToString();
        updateUserModifications();
        userStoppedModifying();
    }

}
