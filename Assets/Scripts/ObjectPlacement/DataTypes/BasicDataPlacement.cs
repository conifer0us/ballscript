using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;
using PlacementScripts;
using UnityEngine.EventSystems; 

namespace PlacementScripts{
public abstract class BasicDataPlacement : PlacementInterface 
{
    public BasicDataPlacement() {}

    public GameObject Prefab;

    protected bool mouseClicked;

    protected bool previousMouseClicked;

    public virtual void onBeginPlacement() {}

    public virtual void processMouseInput(Vector3 mousePosition, bool mouseclicked) {}

    public virtual void placeObject(Vector3 position) {
    }

    public virtual void onEndPlacement() {}

    public virtual void receiveValue(String value) {}
}
}