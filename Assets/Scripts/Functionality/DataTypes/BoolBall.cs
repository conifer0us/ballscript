using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using System; 
using LanguageObjects;

namespace LanguageObjects{
    public class BoolBall : MonoBehaviour, DataFunctionality<bool>  {
        public static float transferspeed = 20f;

        private bool data;

        public void placeObject(Vector3 direction, bool val) {
            data = val;
            gameObject.GetComponent<Rigidbody2D>().velocity = direction / direction.magnitude * transferspeed;
            TMP_Text textelement = gameObject.transform.Find("Canvas").transform.Find("Val").GetComponent<TMP_Text>();
            if (val) {
                textelement.text = "T";
            } else {
                textelement.text = "F";
            }
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(null);
        }

        public bool getDataValue() {
            return data;
        }
    }
}

