using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class StackBottom : MonoBehaviour
{
    private GameObject ground;

    private Vector3 prevscale;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("BottomBound");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rectScale = ground.transform.localScale;
        if (rectScale != prevscale) {
            float thisScale = (float)(rectScale.x / 2 + .5);
            gameObject.transform.localScale = new Vector3(thisScale, 1, 0);
            gameObject.transform.position = new Vector3((float) (-1 * thisScale / 2 + 0.5), -7.5f, 0);
        }
        prevscale = rectScale;
    }
}
