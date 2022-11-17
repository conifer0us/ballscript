using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;

namespace PlacementScripts{
public class Redirect : FlowPlacement
{
    public Redirect() {}

    protected int direction;
    
    protected GameObject Prefab;

    protected GameObject CreatedUI;

    protected bool previousMouseClicked;

    public virtual void onBeginPlacement() {
        Prefab = Resources.Load("Prefabs/Lang/Flow/Redirect") as GameObject;
        GameObject UIPrefab = Resources.Load("Prefabs/UI/DropdownInput") as GameObject;
        UIPrefab.GetComponent<Canvas>().worldCamera = Camera.main;
        CreatedUI = UnityEngine.Object.Instantiate(UIPrefab, new Vector3(0,0,0), Quaternion.identity);
    }

    public void processMouseInput(Vector3 mousepos, bool mouseClicked) {
        if (mousepos.y < -4.5) {
            return;
        }
        if (!previousMouseClicked || mouseClicked) {
            previousMouseClicked = mouseClicked;
            return;
        } else {previousMouseClicked = mouseClicked;}
        Vector3 newLocation = SimpleOperatorPlacement.getSnappedLocation(mousepos);
        Collider2D collisionObject = Physics2D.OverlapCircle(newLocation, 0.1f, LayerMask.GetMask("Operators"));
        if (collisionObject == null) {
            placeObject(newLocation, direction);
        }
    }


    // Places the Flow Operator at the specified position with the specified direction int (0 is right, 1 is left, 2 is down, 3 is up)
    public void placeObject(Vector3 position, int direction) {
        Quaternion rotation = Quaternion.identity; 
        if (direction == 1) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        } else if (direction == 2) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        } else if (direction == 3) {
            rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        } else if (direction != 0) {return;}
        GameObject newOperator = GameObject.Instantiate(Prefab, position, rotation); 
    }

    public void onEndPlacement() {
        UnityEngine.GameObject.Destroy(CreatedUI);
    }

    public void submitValue(int val) {
        direction = val;
    }
}
}