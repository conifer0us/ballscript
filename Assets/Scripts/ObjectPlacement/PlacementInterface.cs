using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlacementScripts {
    public interface PlacementInterface {
        // When a placement script being used by the scriptrunner, 
        // the current mouse position and leftclick state are passed to the processMouseInput function to be processed
        public abstract void processMouseInput(Vector3 mousePos, bool leftClick);

        // When the scriptrunner begins using this placement script, this function is called.
        // onBeginPlacement can be used to perform setup for the placement function. For example, it can create a menu that changes the value of strings in stringballs.
        public abstract void onBeginPlacement();

        // This function is called when the ScriptRunner begins using another script as the placement script. 
        // This function cleans up things done by the placement script.
        public abstract void onEndPlacement();
    }
}