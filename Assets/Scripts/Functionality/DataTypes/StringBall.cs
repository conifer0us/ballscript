using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using System; 
using LanguageObjects;
using Properties;

namespace LanguageObjects{
    public class StringBall : MonoBehaviour, DataFunctionality<String>  {
        private String data;

        public void placeObject(Vector3 direction, String val) {
            float transferspeed = DataProperties.dataspeed;
            
            data = val;
            gameObject.GetComponent<Rigidbody2D>().velocity = direction / direction.magnitude * transferspeed;
            TMP_Text textelement = gameObject.transform.Find("Canvas").transform.Find("Val").GetComponent<TMP_Text>();
            if (val.Length < 3) {
                textelement.text = "'" + val + "'";
            } else {
                textelement.text = "'" + val.Substring(0,1) + "'~";
            }
        }

        public String getDataValue() {
            return data;
        }
    }
}
