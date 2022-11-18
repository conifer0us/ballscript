using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlacementScripts;

namespace PlacementScripts {
public class Deletion : PlacementInterface {
        public void onBeginPlacement() {}

        private bool prevMouseClick = false;

        public void processMouseInput(Vector3 mousePos, bool leftClick) {
            if (prevMouseClick && !leftClick) {
                Collider2D collisionObject = Physics2D.OverlapCircle(mousePos, 0.05f, LayerMask.GetMask("Operators", "DataBall"));
                if (collisionObject != null) {
                    UnityEngine.GameObject.Destroy(collisionObject.gameObject);
                }
            }
            prevMouseClick = leftClick; 
        }

        public void onEndPlacement() {}
    }
}
