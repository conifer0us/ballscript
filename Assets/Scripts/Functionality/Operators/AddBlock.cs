using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguageObjects;

namespace LanguageObjects {
public class AddBlock : MonoBehaviour
{
    private float num1;

    private float num2; 

    private bool num1set;

    public void OnCollisionEnter2D(Collision2D col) {
        GameObject detectedObject = col.collider.gameObject;
        float workingNum = 0;
        if (detectedObject.GetComponent<LanguageObjects.IntBall>() != null) {
            workingNum = detectedObject.GetComponent<LanguageObjects.IntBall>().getDataValue();
        } else if (detectedObject.GetComponent<LanguageObjects.FloatBall>() != null) {
            workingNum = detectedObject.GetComponent<LanguageObjects.FloatBall>().getDataValue(); 
        } else {
            return;
        }
        GameObject.Destroy(detectedObject);
        if (num1set) {
            num2 = workingNum;
            float sum = num1 + num2;
            Vector3 newObjectPosition = gameObject.transform.position - new Vector3(0, 1, 0);
            if ((int) sum  == sum) {
                GameObject IntBallPrefab = Resources.Load("Prefabs/Lang/Data/IntBall") as GameObject;
                GameObject NewIntBall = UnityEngine.GameObject.Instantiate(IntBallPrefab, newObjectPosition, Quaternion.identity);
                NewIntBall.GetComponent<LanguageObjects.IntBall>().placeObject(new Vector3(0, -1, 0), (int)sum);
            } else {
                GameObject FloatBallPrefab = Resources.Load("Prefabs/Lang/Data/FloatBall") as GameObject;
                GameObject NewFloatBall = UnityEngine.GameObject.Instantiate(FloatBallPrefab, newObjectPosition, Quaternion.identity);
                NewFloatBall.GetComponent<LanguageObjects.FloatBall>().placeObject(new Vector3(0, -1, 0), sum);
            }
            num1set = false;
        } else {
            num1 = workingNum;
            num1set = true;
        }
    }
}
}