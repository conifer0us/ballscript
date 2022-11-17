using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using System; 
using LanguageObjects;
using Properties;

namespace LanguageObjects{
    public class FloatBall : MonoBehaviour, DataFunctionality<float>  {
        private float data;

        public void placeObject(Vector3 direction, float val) {
            float transferspeed = DataProperties.dataspeed;
            
            data = val;
            gameObject.GetComponent<Rigidbody2D>().velocity = direction / direction.magnitude * transferspeed;
            TMP_Text textelement = gameObject.transform.Find("Canvas").transform.Find("Val").GetComponent<TMP_Text>();
            String floatString = val.ToString();
            if (floatString.Length < 5) {
                textelement.text = floatString;
            } else {
                textelement.text = floatString.Substring(0,3) + "~";
            }
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(null);
        }

        public float getDataValue() {
            return data;
        }
    }
}

