using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using PlacementScripts;
using TMPro;

public class ChangeMode : MonoBehaviour
{
    PlacementInterface [] NameToScript = 
        {null, //None
        new PlacementScripts.IntBall(), //IntBall 
        new PlacementScripts.FloatBall(), //FloatBall
        new PlacementScripts.StringBall(), //StringBall
        new BoolBall()}; //BoolBall

    // Update is called once per frame
    public void changePlacementMode() {
        int newVal = gameObject.GetComponent<TMP_Dropdown>().value;
        PlacementInterface newplacementtype = NameToScript[newVal]; 
        GameObject.Find("ScriptRunner").GetComponent<ClickController>().changePlacementScript(newplacementtype);
    } 
}
