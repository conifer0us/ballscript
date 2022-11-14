using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    private GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float groundReach = parentObject.transform.localScale.x / 2;
        float cameraReach = Mathf.Abs(Camera.main.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height) + Mathf.Abs(Camera.main.transform.position.x);
        if (groundReach - cameraReach < 10) {
            Vector3 parentScale = parentObject.transform.localScale;
            Vector3 tempScale = parentScale + new Vector3(parentScale.x, 0,0);
            parentObject.transform.localScale = tempScale;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        GameObject.Destroy(col.collider.gameObject);
    }
}
