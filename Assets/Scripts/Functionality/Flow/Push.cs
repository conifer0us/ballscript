using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguageObjects;

namespace LanguageObjects{
public class Push : MonoBehaviour
{

    public StackAPI stack;

    void Start() {
        stack = GameObject.Find("ScriptRunner").GetComponent<StackAPI>();
    }

    void OnCollisionEnter2D (Collision2D col) {
        GameObject otherObject = col.collider.gameObject;
        stack.pushObject(otherObject);
    }
}
}