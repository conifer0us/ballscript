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

    private bool mouseClicked;

    private bool previousMouseClicked;

    public virtual void onBeginPlacement() {}

    public void processMouseInput(Vector3 mousePosition, bool mouseclicked) {
        if (EventSystem.current.currentSelectedGameObject != null || mousePosition.y < -4.5) {
            return;
        }
        if (previousMouseClicked && !mouseClicked) {
            placeObject(mousePosition);
        }
        previousMouseClicked = mouseClicked;
    }

    public virtual void placeObject(Vector3 position) {
        GameObject.Instantiate(Prefab, position, Quaternion.identity);
    }

    public virtual void onEndPlacement() {}

    public virtual void receiveValue(String value) {}
}
}