using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using System; 
using LanguageObjects;

namespace LanguageObjects{
    public class IntBall : MonoBehaviour, DataFunctionality<int>  {
        public static float transferspeed = 10f;

        private int data;

        public void placeObject(Vector3 direction, int val) {
            data = val;
            gameObject.GetComponent<Rigidbody2D>().velocity = direction / direction.magnitude * transferspeed;
            String intString = val.ToString();
            TMP_Text textelement = gameObject.transform.Find("Canvas").transform.Find("Val").GetComponent<TMP_Text>();
            if (intString.Length < 5) {
                textelement.text = intString;
            } else {
                textelement.text = intString.Substring(0,2) + "e" + (intString.Length - 2);
            }
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(null);
        }

        public int getDataValue() {
            return data;
        }
    }
}