using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;

namespace PlacementScripts {
public class Splitter : Redirect
{
    public override void onBeginPlacement() {
        Prefab = Resources.Load("Prefabs/Lang/Flow/Splitter") as GameObject;
        GameObject UIPrefab = Resources.Load("Prefabs/UI/DropdownInput") as GameObject;
        UIPrefab.GetComponent<Canvas>().worldCamera = Camera.main;
        CreatedUI = UnityEngine.Object.Instantiate(UIPrefab, new Vector3(0,0,0), Quaternion.identity);
    }
}
}