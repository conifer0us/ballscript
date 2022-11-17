using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using System; 
using LanguageObjects;
using Properties;

namespace LanguageObjects{
    public class BoolBall : MonoBehaviour, DataFunctionality<bool>  {
        private bool data;

        public void placeObject(Vector3 direction, bool val) {
            float transferspeed = DataProperties.dataspeed;

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

