using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using LanguageObjects;
using System;
using TMPro; 

namespace PlacementScripts{
public class BoolBall : BasicDataPlacement
{
    public BoolBall() {}

    public static String UIPrompt = "Bool Value (True)";

    private bool previousMouseClicked;

    private GameObject UIPrefab;

    private GameObject CreatedUI;

    private bool val = true;

    public void onBeginPlacement() {
        UIPrefab = Resources.Load("Prefabs/UI/SingleTextData") as GameObject;
        UIPrefab.GetComponent<Canvas>().worldCamera = Camera.main;
        UIPrefab.transform.Find("Label").gameObject.GetComponent<TMP_Text>().SetText(UIPrompt);
        CreatedUI = UnityEngine.Object.Instantiate(UIPrefab, new Vector3(0,0,0), Quaternion.identity); 
    }

    public void onEndPlacement() {
        val = true;
        UnityEngine.Object.Destroy(CreatedUI);
    }

    public void processMouseInput(Vector3 mousePosition, bool mouseClicked)
    {
        if (mousePosition.y < -4.5) {
            return;
        }
        if (previousMouseClicked && !mouseClicked) {
            placeObject(mousePosition);
        }
        previousMouseClicked = mouseClicked;
    }

    public void placeObject(Vector3 position) {
        GameObject BallPrefab = Resources.Load("Prefabs/Lang/Data/BoolBall") as GameObject;
        GameObject NewBall = UnityEngine.GameObject.Instantiate(BallPrefab, position, Quaternion.identity);
        NewBall.GetComponent<LanguageObjects.BoolBall>().placeObject(new Vector3(0, -1, 0), val);
    }

    public void receiveValue(String s) {
        try {
            String newText = s.ToLower();
            if (newText == "true" || newText =="t") {
                val = true;
            } else if (newText == "false" || newText == "f") {
                val = false;
            } else {return;}
            String builttext = "Bool Value (" + val.ToString() + ")";
            CreatedUI.transform.Find("Label").gameObject.GetComponent<TMP_Text>().SetText(builttext);
        } catch {}
    }
}
}
