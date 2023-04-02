using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Linq;


public class HUDObjectModification : MonoBehaviour
{
    
    [SerializeField] GameObject objectController;
    [SerializeField] GameObject shapeModifiers;
    [SerializeField] GameObject xPos;
    [SerializeField] GameObject yPos;
    [SerializeField] GameObject zPos;
    [SerializeField] GameObject xRot;
    [SerializeField] GameObject yRot;
    [SerializeField] GameObject zRot;
    [SerializeField] GameObject xScale;
    [SerializeField] GameObject yScale;
    [SerializeField] GameObject zScale;
    GameObject mainObjectModification;

    private ObjectSelection objectSelection;
    private TMP_InputField xPosTMP_InputField;
    private TMP_InputField yPosTMP_InputField;
    private TMP_InputField zPosTMP_InputField;

    private TMP_InputField xRotTMP_InputField;
    private TMP_InputField yRotTMP_InputField;
    private TMP_InputField zRotTMP_InputField;

    private TMP_InputField xScaleTMP_InputField;
    private TMP_InputField yScaleTMP_InputField;
    private TMP_InputField zScaleTMP_InputField;

    private GameObject [] shapeModifiersArray;
    private TMP_InputField [] tmp_InputFields;
    
    private string [] shapeModifiersString;
    private float [] shapeModifiersFloat;
    

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

    float [] posFloats;
    float [] rotFloats;
    float [] sclaeFloats;

    Vector3 mainObjectModificationPos;
    Quaternion mainObjectModificationRot;
    Vector3 mainObjectModificationScale;
    public bool isUserMakingModifications;

    // locates shape modifying input fields and the shape modifying tab
    private void Awake()
    {   
        objectSelection = objectController.GetComponent<ObjectSelection>();
        shapeModifiersArray = new GameObject [9] {xPos,
                                                yPos,
                                                zPos,
                                                xRot,
                                                yRot,
                                                zRot,
                                                xScale,
                                                yScale,
                                                zScale};
        xPosTMP_InputField = xPos.GetComponent<TMP_InputField>();
        yPosTMP_InputField = yPos.GetComponent<TMP_InputField>();
        zPosTMP_InputField = zPos.GetComponent<TMP_InputField>();
        xRotTMP_InputField = xRot.GetComponent<TMP_InputField>();
        yRotTMP_InputField = yRot.GetComponent<TMP_InputField>();
        zRotTMP_InputField = zRot.GetComponent<TMP_InputField>();
        xScaleTMP_InputField = xScale.GetComponent<TMP_InputField>();
        yScaleTMP_InputField = yScale.GetComponent<TMP_InputField>();
        zScaleTMP_InputField = zScale.GetComponent<TMP_InputField>();
        tmp_InputFields = new TMP_InputField [9]{xPosTMP_InputField,
                                                yPosTMP_InputField,
                                                zPosTMP_InputField,
                                                xRotTMP_InputField,
                                                yRotTMP_InputField,
                                                zRotTMP_InputField,
                                                xScaleTMP_InputField,
                                                yScaleTMP_InputField,
                                                zScaleTMP_InputField};
        shapeModifiersString = new string [9] {xPosText,
                                                yPosText,
                                                zPosText,
                                                xRotText,
                                                yRotText,
                                                zRotText,
                                                xScaleText,
                                                yScaleText,
                                                zScaleText};
        shapeModifiersFloat = new float [9] {xPosFloat,
                                            yPosFloat,
                                            zPosFloat,
                                            xRotFloat,
                                            yRotFloat,
                                            zRotFloat,
                                            xScaleFloat,
                                            yScaleFloat,
                                            zScaleFloat};


        EventSystem.current.SetSelectedGameObject(null);
        shapeModifiers.SetActive(false);
    }

    //show the shape modifying tab
    public void ShowModifiers (){
        shapeModifiers.SetActive(true);
        mainObjectModification = objectSelection.selectedObject;
    }

    //hide the shape modifying tab
    public void HideModifiers (){
        shapeModifiers.SetActive(false);
    }

    public void UpdateOnObjectMove(KeyCode keypressed){
        if (mainObjectModification != null && isUserMakingModifications == false){

            if (keypressed == KeyCode.A || keypressed == KeyCode.D){
                xPos.GetComponent<TMP_InputField>().text = mainObjectModification.transform.position.x.ToString();
                CleanXRotationForUpdateOnObjectMove();
                xScaleTMP_InputField.text = mainObjectModification.transform.localScale.x.ToString();
            }

            if (keypressed == KeyCode.Q || keypressed == KeyCode.E){
                yPosTMP_InputField.text = mainObjectModification.transform.position.y.ToString();
                yRotTMP_InputField.text = mainObjectModification.transform.localEulerAngles.y.ToString();
                yScaleTMP_InputField.text = mainObjectModification.transform.localScale.y.ToString();
            }

            if (keypressed == KeyCode.W || keypressed == KeyCode.S){
                zPosTMP_InputField.text = mainObjectModification.transform.position.z.ToString();
                zRotTMP_InputField.text = mainObjectModification.transform.localEulerAngles.z.ToString();
                zScaleTMP_InputField.text = mainObjectModification.transform.localScale.z.ToString();
            }
        }
    }

    public void UpdateOnObjectMove(){
        if (mainObjectModification != null && isUserMakingModifications == false){

            xPosTMP_InputField.text= mainObjectModification.transform.position.x.ToString();
            CleanXRotationForUpdateOnObjectMove();
            xScaleTMP_InputField.text = mainObjectModification.transform.localScale.x.ToString();

            yPosTMP_InputField.text = mainObjectModification.transform.position.y.ToString();
            yRotTMP_InputField.text = mainObjectModification.transform.localEulerAngles.y.ToString();
            yScaleTMP_InputField.text = mainObjectModification.transform.localScale.y.ToString();

            zPosTMP_InputField.text = mainObjectModification.transform.position.z.ToString();
            zRotTMP_InputField.text = mainObjectModification.transform.localEulerAngles.z.ToString();
            zScaleTMP_InputField.text = mainObjectModification.transform.localScale.z.ToString();
        }
    }

    public void CleanXRotationForUpdateOnObjectMove(){
        if (mainObjectModification.transform.localEulerAngles.y >= 180 
            && mainObjectModification.transform.localEulerAngles.z >= 180
            && mainObjectModification.transform.localEulerAngles.x <= 90){
                xRotTMP_InputField.text = 
                    (-1 * mainObjectModification.transform.localEulerAngles.x + 180).ToString();
            }
        else if (mainObjectModification.transform.localEulerAngles.y < 180 
            && mainObjectModification.transform.localEulerAngles.z < 180
            && mainObjectModification.transform.localEulerAngles.x < 90){
                xRotTMP_InputField.text = 
                    (mainObjectModification.transform.localEulerAngles.x).ToString();
            }
        else if (mainObjectModification.transform.localEulerAngles.y >= 180 
        && mainObjectModification.transform.localEulerAngles.z >= 180
        && mainObjectModification.transform.localEulerAngles.x > 270){
            xRotTMP_InputField.text = 
                (-1 * mainObjectModification.transform.localEulerAngles.x + 540).ToString();
        }  
        else 
        {
            xRotTMP_InputField.text = 
                (mainObjectModification.transform.localEulerAngles.x).ToString();
        }
    }

    //stops input fields from updating while user is modifying shape
    public void UserModifying(){
        isUserMakingModifications = true;
    }

    //modifies selected shape according to values input by user into input fields
    public void UpdateUserModifications(){
        if (isUserMakingModifications == true){
            for( int i = 0; i < tmp_InputFields.Length; i++){
                shapeModifiersString [i] = tmp_InputFields [i].text;
            }

            for( int j = 0; j < shapeModifiersFloat.Length; j ++){
                shapeModifiersFloat [j] = TestForBadInput (shapeModifiersString[j]);
            } 

            mainObjectModification.transform.position = 
                new Vector3 (shapeModifiersFloat [0], shapeModifiersFloat [1], shapeModifiersFloat [2]);
            mainObjectModification.transform.rotation =
                Quaternion.Euler (shapeModifiersFloat [3], shapeModifiersFloat [4], shapeModifiersFloat [5]);
            mainObjectModification.transform.localScale = 
                new Vector3 (shapeModifiersFloat [6], shapeModifiersFloat [7], shapeModifiersFloat [8]);
        }
    }

    //starts input fields updating when user is no longer modifying shape
    public void UserStoppedModifying(){
        isUserMakingModifications = false;
    }

    //cleans the user input to be only numeric. Non-numeric and null go to default values.
    public float TestForBadInput(string shapeModInput){
        if (!float.TryParse(shapeModInput, out testForBadInput)
                || shapeModInput == null){
            if (shapeModInput == shapeModifiersString[8] 
                || shapeModInput == shapeModifiersString[7]
                || shapeModInput == shapeModifiersString[6]){
                testForBadInput = 1f;
            }
            else {
                testForBadInput = 0f;
            }
        }
        return testForBadInput;
    }

    //increments the input field value up by 1 and modifies the object accordingly
    public void IncrementModifier(TMP_InputField inputField){
        UserModifying();
        inputField.text = (TestForBadInput(inputField.text) + 1f).ToString();    
        UpdateUserModifications();
        UserStoppedModifying();
    }

     //decrements the input field value down by 1 and modifies the object accordingly
     public void DecrementModifier(TMP_InputField inputField){
        UserModifying();
        inputField.text = (TestForBadInput(inputField.text) - 1f).ToString();    
        UpdateUserModifications();
        UserStoppedModifying();
    }

    
    public void SetMainObjectModification(GameObject mainObject){
        mainObjectModification = mainObject;
}



}
