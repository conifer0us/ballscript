using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using PlacementScripts;
using TMPro;

public class ChangeMode : MonoBehaviour
{
    public PlacementInterface[] NameToScript;
    
    void Start() {
        NameToScript = 
        new PlacementInterface[6]
        {null, //None
        new PlacementScripts.IntBall(), //IntBall 
        new PlacementScripts.FloatBall(), //FloatBall
        new PlacementScripts.StringBall(), //StringBall
        new BoolBall(), //BoolBall
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Operator/AddBlock") as GameObject) //AddBlock
        }; 
    }

    // Update is called once per frame
    public void changePlacementMode() {
        int newVal = gameObject.GetComponent<TMP_Dropdown>().value;
        PlacementInterface newplacementtype = NameToScript[newVal]; 
        GameObject.Find("ScriptRunner").GetComponent<ClickController>().changePlacementScript(newplacementtype);
    } 
}
