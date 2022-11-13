using System.Collections;
using System; 
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using TMPro; 

public class SubmitValue : MonoBehaviour
{
    public void submitValue(TMP_InputField field) {
        BasicDataPlacement submitclass = (BasicDataPlacement) GameObject.Find("ScriptRunner").GetComponent<ClickController>().placementObject;
        submitclass.receiveValue(field.text);
    }
}
