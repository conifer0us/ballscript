using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Properties;
using LanguageObjects;

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
        if (otherObject.GetComponent<BoolBall>() != null) {
            OppositeObject.GetComponent<BoolBall>().placeObject(-1 * oneDirectionVelocity, otherObject.GetComponent<BoolBall>().getDataValue());
        }
        else if (otherObject.GetComponent<IntBall>() != null) {
            OppositeObject.GetComponent<IntBall>().placeObject(-1 * oneDirectionVelocity, otherObject.GetComponent<IntBall>().getDataValue());
        }
        else if (otherObject.GetComponent<FloatBall>() != null) {
            OppositeObject.GetComponent<FloatBall>().placeObject(-1 * oneDirectionVelocity, otherObject.GetComponent<FloatBall>().getDataValue());
        }
        else if (otherObject.GetComponent<StringBall>() != null) {
            OppositeObject.GetComponent<StringBall>().placeObject(-1 * oneDirectionVelocity, otherObject.GetComponent<StringBall>().getDataValue());
        }
    }
}
}