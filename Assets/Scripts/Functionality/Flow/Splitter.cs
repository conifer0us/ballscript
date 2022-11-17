using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Properties;

namespace LanguageObjects{
public class Splitter : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col) {
        GameObject otherObject = col.collider.gameObject;
        if (otherObject.layer != LayerMask.NameToLayer("DataBall")) {
            GameObject.Destroy(otherObject);
            return;
        }
        float angle = gameObject.transform.rotation.eulerAngles.z * Mathf.PI / 180;
        Vector3 diff_vector = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        Vector3 newposition = gameObject.transform.position + diff_vector;
        otherObject.transform.position = newposition;
        Vector3 oneDirectionVelocity = diff_vector / diff_vector.magnitude * DataProperties.dataspeed;
        otherObject.GetComponent<Rigidbody2D>().velocity = oneDirectionVelocity;
        GameObject OppositeObject = GameObject.Instantiate(otherObject, gameObject.transform.position - diff_vector, Quaternion.identity);
        OppositeObject.GetComponent<Rigidbody2D>().velocity = -1 * oneDirectionVelocity; 
    }
}
}