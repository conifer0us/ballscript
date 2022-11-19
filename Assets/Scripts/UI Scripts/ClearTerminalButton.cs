using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTerminalButton : MonoBehaviour
{
    public void OnClearButtonPress() {
        GameObject.Find("ScriptRunner").GetComponent<PrintToStdout>().clear(); 
    }
}
