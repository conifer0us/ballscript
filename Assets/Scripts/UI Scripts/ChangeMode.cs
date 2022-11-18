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
        new PlacementInterface[20]
        {null, //None
        new Deletion(), //Deletion
        new IntBall(), //IntBall 
        new FloatBall(), //FloatBall
        new StringBall(), //StringBall
        new BoolBall(), //BoolBall
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Operator/AddBlock") as GameObject), //AddBlock
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Operator/SubtractBlock") as GameObject), //SubtractBlock
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Operator/MultiplyBlock") as GameObject), //MultiplyBlock
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Operator/DivideBlock") as GameObject), //DivideBlock
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Operator/ModBlock") as GameObject), //ModBlock
        new Redirect(), // Redirect
        new Splitter(), //Splitter
        new Teleporter(), //Teleporter
        new Conditional(), //Conditional
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Flow/Output") as GameObject), //Output
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Flow/PushBlock") as GameObject), //PushBlock
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Flow/PopBlock") as GameObject), //PopBlock
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Operator/NegativeCheck") as GameObject), //NegativeCheck
        new SimpleOperatorPlacement(Resources.Load("Prefabs/Lang/Operator/NOT") as GameObject) //NOT Boolean Operator
        }; 
    }

    // Update is called once per frame
    public void changePlacementMode() {
        int newVal = gameObject.GetComponent<TMP_Dropdown>().value;
        PlacementInterface newplacementtype = NameToScript[newVal]; 
        GameObject.Find("ScriptRunner").GetComponent<ClickController>().changePlacementScript(newplacementtype);
    } 
}
