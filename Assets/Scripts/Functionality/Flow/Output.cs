using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguageObjects;
using System;
using TMPro;

namespace LanguageObjects {
public class Output : MonoBehaviour
{

    TMP_Text stdout;

    void Start() {
        stdout = GameObject.Find("stdout").GetComponent<TMP_Text>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject other_object = collision.collider.gameObject;
        String data = null; 
        if (other_object.GetComponent<IntBall>() != null) {
            data = other_object.GetComponent<IntBall>().getDataValue().ToString();
        } else if (other_object.GetComponent<FloatBall>() != null) {
            data = other_object.GetComponent<FloatBall>().getDataValue().ToString();
        } else if (other_object.GetComponent<BoolBall>() != null) {
            data = other_object.GetComponent<BoolBall>().getDataValue().ToString();
        } else if (other_object.GetComponent<StringBall>() != null) {
            data = other_object.GetComponent<StringBall>().getDataValue().ToString();
        } 
        if (data != null) {
            printData(data);
        }
        GameObject.Destroy(other_object);
    }

    public void printData(String data) {
        stdout.text += data + "\n";
    }
}
}