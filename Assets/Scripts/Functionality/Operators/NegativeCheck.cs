using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguageObjects;

namespace LanguageObjects {
public class NegativeCheck : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col) {
        GameObject otherObject = col.collider.gameObject;
        float currentvalue = 0;
        bool ret = true;
        if (otherObject.GetComponent<LanguageObjects.IntBall>() != null) {
            currentvalue = otherObject.GetComponent<LanguageObjects.IntBall>().getDataValue();
        } else if (otherObject.GetComponent<LanguageObjects.FloatBall>() != null) {
            currentvalue = otherObject.GetComponent<LanguageObjects.FloatBall>().getDataValue();
        } else {ret = false;}
        GameObject.Destroy(otherObject);
        if (ret) {
            GameObject BallPrefab = Resources.Load("Prefabs/Lang/Data/BoolBall") as GameObject;
            GameObject NewBall = UnityEngine.GameObject.Instantiate(BallPrefab, gameObject.transform.position - new Vector3(0, 1, 0), Quaternion.identity);
            NewBall.GetComponent<LanguageObjects.BoolBall>().placeObject(new Vector3(0, -1, 0), (currentvalue < 0));
        }
    }
}
}