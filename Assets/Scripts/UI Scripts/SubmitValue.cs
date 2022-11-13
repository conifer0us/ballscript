using System.Collections;
using System; 
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using TMPro; 

public class SubmitValue : MonoBehaviour
{
    public BasicDataPlacement submitclass;

    public void submitValue() {
        submitclass.receiveValue(gameObject.GetComponent<TMP_InputField>().text);
    }
}
