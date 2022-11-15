using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;

namespace PlacementScripts {
public class SimpleOperatorPlacement : PlacementInterface
{
    GameObject Prefab;

    private bool previousMouseClicked;

    public SimpleOperatorPlacement(GameObject prefab) {
        Prefab = prefab;
    }

    public void onBeginPlacement() {}

    public void processMouseInput(Vector3 mousepos, bool mouseClicked) {
        if (mousepos.y < -4.5) {
            return;
        }
        if (!previousMouseClicked || mouseClicked) {
            previousMouseClicked = mouseClicked;
            return;
        } else {previousMouseClicked = mouseClicked;}
        Vector3 newLocation = getSnappedLocation(mousepos);
        Collider2D collisionObject = Physics2D.OverlapCircle(newLocation, 0.1f, LayerMask.GetMask("Operators"));
        if (collisionObject == null) {
            GameObject.Instantiate(Prefab, newLocation, Quaternion.identity); 
        }
    }

    public void onEndPlacement() {}

    public static Vector3 getSnappedLocation(Vector3 inputvector) {
        return new Vector3(Mathf.Floor(inputvector.x + .5f), (float) Mathf.Floor(inputvector.y + .5f), inputvector.z);
    }
}
}