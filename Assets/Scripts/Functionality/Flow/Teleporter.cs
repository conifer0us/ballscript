using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Properties;

namespace LanguageObjects{
public class Teleporter : MonoBehaviour
{

    private GameObject linked_object;

    public void OnCollisionEnter2D(Collision2D col) {
        GameObject otherObject = col.collider.gameObject;
        if (otherObject.layer != LayerMask.NameToLayer("DataBall") || linked_object == null) {
            GameObject.Destroy(otherObject);
            return;
        }
        Vector3 newposition = linked_object.transform.position;
        otherObject.transform.position = newposition;
    }

    public void setLinkedObject(GameObject linkedObject) {
        linked_object = linkedObject;
    }
}
}