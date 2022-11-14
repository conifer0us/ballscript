using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using LanguageObjects;
using System;
using TMPro; 

namespace PlacementScripts{
public class IntBall : BasicDataPlacement
{
    public IntBall() {}

    public static String UIPrompt = "Int Value (0)";

    private bool previousMouseClicked;

    private GameObject UIPrefab;

    private GameObject CreatedUI;

    private int val = 0;

    public void onBeginPlacement() {
        UIPrefab = Resources.Load("Prefabs/UI/IntInput") as GameObject;
        UIPrefab.GetComponent<Canvas>().worldCamera = Camera.main;
        UIPrefab.transform.Find("Label").gameObject.GetComponent<TMP_Text>().SetText(UIPrompt);
        CreatedUI = UnityEngine.Object.Instantiate(UIPrefab, new Vector3(0,0,0), Quaternion.identity); 
    }

    public void onEndPlacement() {
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
        GameObject IntBallPrefab = Resources.Load("Prefabs/Lang/Data/IntBall") as GameObject;
        GameObject NewIntBall = UnityEngine.GameObject.Instantiate(IntBallPrefab, position, Quaternion.identity);
        NewIntBall.GetComponent<LanguageObjects.IntBall>().placeObject(new Vector3(0, -1, 0), val);
    }

    public void receiveValue(String s) {
        try {
            val = Int32.Parse(s);
            String builttext = "Int Value (" + val.ToString() + ")";
            CreatedUI.transform.Find("Label").gameObject.GetComponent<TMP_Text>().SetText(builttext);
        } catch {}
    }
}
}