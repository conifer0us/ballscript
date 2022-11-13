using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using System;

public class ClickController : MonoBehaviour
{
    public PlacementInterface placementObject = null;
    
    void Start(){}

    void Update()
    {
        // If placement mode is set, pass mouse state to the current Placement Script, which then handles scene manipulations
        if (placementObject != null){
            placementObject.processMouseInput(Input.mousePosition, Input.GetMouseButton(0));
        }
    }

    public void changePlacementScript(PlacementInterface newPlacementScript) {
        if (placementObject != null) {
            placementObject.onEndPlacement();
        }
        placementObject = newPlacementScript;
        if (placementObject != null) {
            placementObject.onBeginPlacement();
        }
    }
}
