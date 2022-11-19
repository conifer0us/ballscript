using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using System; 
using LanguageObjects;
using Properties;

namespace LanguageObjects{
    public class IntVar : MonoBehaviour, DataVarFunctionality<int>  {
        private int data;

        private GameObject IntBallPrefab;

        void Start() {
            IntBallPrefab = Resources.Load("Prefabs/Lang/Data/IntBall") as GameObject;
        }

        public void OnCollisionEnter2D(Collision2D col) {
            GameObject.Destroy(col.collider.gameObject);
            GameObject NewIntBall = UnityEngine.GameObject.Instantiate(IntBallPrefab, gameObject.transform.position - new Vector3(0,1,0), Quaternion.identity);
            NewIntBall.GetComponent<LanguageObjects.IntBall>().placeObject(new Vector3(0, -1, 0), getDataValue());
        }

        public void placeObject(int val) {
            float transferspeed = DataProperties.dataspeed;
            data = val;
            String intString = val.ToString();
            TMP_Text textelement = gameObject.transform.Find("Canvas").transform.Find("Val").GetComponent<TMP_Text>();
            if (intString.Length < 5) {
                textelement.text = intString;
            } else {
                textelement.text = intString.Substring(0,1) + "e" + (intString.Length - 1);
            }
        }

        public int getDataValue() {
            return data;
        }
    }
}