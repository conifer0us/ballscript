using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Properties;
using LanguageObjects;

namespace LanguageObjects{
public class Conditional : MonoBehaviour
{
    private bool state = true;

    private float angletrue;
    private float anglefalse;

    private static Color colorFalse = new Color(1f, 0.35294117647f, 0.35294117647f, 0.8f);

    private static Color colorTrue = new Color(0.35294117647f, 1f, 0.35294117647f, 0.8f);

    void Start() {
        angletrue = getObjectAngle();
        anglefalse = getObjectAngle() + Mathf.PI;
    }
    
    public void OnCollisionEnter2D(Collision2D col) {
        GameObject otherObject = col.collider.gameObject;
        if (otherObject.layer != LayerMask.NameToLayer("DataBall")) {
            GameObject.Destroy(otherObject);
            return;
        }
        if (otherObject.GetComponent<BoolBall>() != null) {
            bool ballState = otherObject.GetComponent<BoolBall>().getDataValue();
            if (ballState) {
                setTrue();
            } else {
                setFalse();
            }
            state = ballState;
            GameObject.Destroy(otherObject);
            return; 
        }
        float angle = getObjectAngle();
        Vector3 diff_vector = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        Vector3 newposition = gameObject.transform.position + diff_vector;
        otherObject.transform.position = newposition;
        otherObject.GetComponent<Rigidbody2D>().velocity = diff_vector / diff_vector.magnitude * DataProperties.dataspeed;
    }

    private void setFalse() {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,anglefalse * 180 / Mathf.PI));
        gameObject.transform.Find("Canvas").Find("Foreground").gameObject.GetComponent<SpriteRenderer>().color = colorFalse;
    }

    public void setTrue() {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,angletrue * 180 / Mathf.PI));
        gameObject.transform.Find("Canvas").Find("Foreground").gameObject.GetComponent<SpriteRenderer>().color = colorTrue;
    }

    private float getObjectAngle() {
        return gameObject.transform.rotation.eulerAngles.z * Mathf.PI / 180;
    }
}
}
