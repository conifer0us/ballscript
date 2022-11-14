using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using LanguageObjects;
using System;
using TMPro; 

namespace PlacementScripts{
public class StringBall : BasicDataPlacement
{
    public StringBall() {}

    public static String UIPrompt = "String Value ('')";

    private bool previousMouseClicked;

    private GameObject UIPrefab;

    private GameObject CreatedUI;

    private String val = "";

    public void onBeginPlacement() {
        UIPrefab = Resources.Load("Prefabs/UI/SingleTextData") as GameObject;
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
        GameObject BallPrefab = Resources.Load("Prefabs/Lang/Data/StringBall") as GameObject;
        GameObject NewBall = UnityEngine.GameObject.Instantiate(BallPrefab, position, Quaternion.identity);
        NewBall.GetComponent<LanguageObjects.StringBall>().placeObject(new Vector3(0, -1, 0), val);
    }

    public void receiveValue(String s) {
        try {
            val = s;
            String builttext = "String Value ('" + val + "')";
            CreatedUI.transform.Find("Label").gameObject.GetComponent<TMP_Text>().SetText(builttext);
        } catch {}
    }
}
}