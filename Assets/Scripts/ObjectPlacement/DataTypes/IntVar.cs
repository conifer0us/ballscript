using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;
using LanguageObjects;
using System;
using TMPro; 

namespace PlacementScripts{
public class IntVar : BasicDataPlacement
{
    public IntVar() {}

    public static String UIPrompt = "Int Var Value (0)";

    private bool previousMouseClicked;

    private GameObject UIPrefab;

    private GameObject CreatedUI;

    private int val = 0;

    public void onBeginPlacement() {
        UIPrefab = Resources.Load("Prefabs/UI/SingleTextData") as GameObject;
        UIPrefab.GetComponent<Canvas>().worldCamera = Camera.main;
        UIPrefab.transform.Find("Label").gameObject.GetComponent<TMP_Text>().SetText(UIPrompt);
        CreatedUI = UnityEngine.Object.Instantiate(UIPrefab, new Vector3(0,0,0), Quaternion.identity); 
    }

    public void onEndPlacement() {
        val = 0; 
        UnityEngine.Object.Destroy(CreatedUI);
    }

    public void processMouseInput(Vector3 mousePosition, bool mouseClicked)
    {
        if (mousePosition.y < -4.5) {
            return;
        }
        if (previousMouseClicked && !mouseClicked) {
            placeObject(SimpleOperatorPlacement.getSnappedLocation(mousePosition));
        }
        previousMouseClicked = mouseClicked;
    }

    public void placeObject(Vector3 position) {
        GameObject IntVarPrefab = Resources.Load("Prefabs/Lang/Data/IntVar") as GameObject;
        GameObject NewIntVar = UnityEngine.GameObject.Instantiate(IntVarPrefab, position, Quaternion.identity);
        NewIntVar.GetComponent<LanguageObjects.IntVar>().placeObject(val);
    }

    public void receiveValue(String s) {
        try {
            val = Int32.Parse(s);
            String builttext = "Int Var Value (" + val.ToString() + ")";
            CreatedUI.transform.Find("Label").gameObject.GetComponent<TMP_Text>().SetText(builttext);
        } catch {}
    }
}
}