using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;
using PlacementScripts;
using UnityEngine.EventSystems; 

namespace PlacementScripts{

//Framing Class for Data Placement That Must Receive UI Input to set Values
// Includes a receiveValue function to be used by UI elements and a placeObject function to transform the data into a physical element

public interface BasicDataPlacement : PlacementInterface 
{
    public abstract void placeObject(Vector3 position);

    public abstract void receiveValue(String value);
}
}