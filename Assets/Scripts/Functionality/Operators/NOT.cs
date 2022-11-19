using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguageObjects;

namespace LanguageObjects {
public class NOT : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col) {
        GameObject otherObject = col.collider.gameObject;
        if (otherObject.GetComponent<BoolBall>() != null) {
            bool newVal = !(otherObject.GetComponent<BoolBall>().getDataValue());
            GameObject BallPrefab = Resources.Load("Prefabs/Lang/Data/BoolBall") as GameObject;
            GameObject NewBall = GameObject.Instantiate(BallPrefab, gameObject.transform.position - new Vector3(0, 1, 0), Quaternion.identity);
            NewBall.GetComponent<BoolBall>().placeObject(new Vector3(0, -1, 0), newVal);
        }
        GameObject.Destroy(otherObject);
    }
}
}