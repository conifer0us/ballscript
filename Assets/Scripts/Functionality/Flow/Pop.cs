using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguageObjects;
using Properties;

namespace LanguageObjects{
public class Pop : MonoBehaviour
{

    public StackAPI stack;

    void Start() {
        stack = GameObject.Find("ScriptRunner").GetComponent<StackAPI>();
    }

    void OnCollisionEnter2D (Collision2D col) {
        GameObject.Destroy(col.collider.gameObject);
        stack.popObject(gameObject.transform.position - new Vector3(0, 1, 0), new Vector3(0,-1 * DataProperties.dataspeed,0));
    }
}
}