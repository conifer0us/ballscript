using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro; 

public class PrintToStdout : MonoBehaviour
{
    Vector3 nextPosition;
    GameObject newLinePrefab;    
    GameObject stdout;

    void Start() {
        stdout = GameObject.Find("stdoutContent");
        nextPosition = new Vector3(0, -10, 0);
        newLinePrefab = Resources.Load("Prefabs/UI/stdoutLine") as GameObject;
    }

    public void placeLine(String data) {
        GameObject newLine = GameObject.Instantiate(newLinePrefab);
        newLine.GetComponent<TMP_Text>().text = data;
        newLine.transform.SetParent(stdout.transform, false);
        newLine.transform.position = nextPosition;
        nextPosition -= new Vector3(0, 20, 0);
    }

    public void clear() {
        nextPosition = new Vector3(0, -10, 0);
        foreach (Transform child in stdout.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
