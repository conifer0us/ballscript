using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using System;
using TMPro; 

public class IntBall : BasicDataPlacement
{
    public IntBall() {}

    public static String UIPrompt = "Int Value (0)";

    public GameObject UIPrefab;

    public GameObject CreatedUI;

    public int val = 0;

    public override void onBeginPlacement() {
        UIPrefab = Resources.Load("Prefabs/UI/IntInput") as GameObject;
        UIPrefab.GetComponent<Canvas>().worldCamera = Camera.main;
        UIPrefab.transform.Find("Label").gameObject.GetComponent<TMP_Text>().SetText(UIPrompt);
        UIPrefab.transform.Find("InputField").gameObject.GetComponent<SubmitValue>().submitclass = this; 
        CreatedUI = UnityEngine.Object.Instantiate(UIPrefab, new Vector3(0,0,0), Quaternion.identity); 
    }

    public override void onEndPlacement() {
        UnityEngine.Object.Destroy(CreatedUI);
    }

    public override void placeObject(Vector3 position) {
        Debug.Log("Placing Int Ball with Value " + val.ToString());
    }

    public override void receiveValue(String s) {
        try {
            val = Int32.Parse(s);
            UIPrefab.transform.Find("Label").GetComponent<TextMeshPro>().text = "Int Value (" + val.ToString() + ")";
        } catch {}
    }
}
