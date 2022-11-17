using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using TMPro; 

public class SubmitDropdownValue : MonoBehaviour {

    public void submitValue(TMP_Dropdown dropdown) {
        FlowPlacement submitclass = (FlowPlacement) GameObject.Find("ScriptRunner").GetComponent<ClickController>().placementObject;
        submitclass.submitValue(dropdown.value); 
    }
}
