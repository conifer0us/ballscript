using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorCamera : MonoBehaviour
{    
    private GameObject parentObject;

    private Vector3 prevposition;

    private Vector3 movementDirection;

    private float positionVelocity = 0;

    private static int maxMagnitude = 10;

    private static float movementFactor = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.gameObject;
        prevposition = parentObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentposition = Input.mousePosition;
        if (Input.GetMouseButton(0) && currentposition != prevposition) {
            Vector3 posDif = prevposition - currentposition;
            movementDirection = posDif / posDif.magnitude;
            positionVelocity = Mathf.Clamp(posDif.magnitude, 0, 10);
            if (posDif.magnitude > maxMagnitude) {
                posDif = movementDirection * maxMagnitude;
            }
            parentObject.transform.position += movementFactor * posDif;
        } 
        
        prevposition = currentposition;
    }
}
