using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Updates camera position when mouse is right clicked and dragged. 
public class EditorCamera : MonoBehaviour
{    
    private GameObject parentObject;

    private Vector3 prevposition;

    private Vector3 movementDirection;

    private float positionVelocity = 0;

    private static int maxMagnitude = 10;

    private static float maxOrthoSize = 10f;

    private static float minOrthoSize = 4f;

    private static int scrollsensitivity = 2;

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
        if (Input.GetMouseButton(1) && currentposition != prevposition) {
            Vector3 posDif = prevposition - currentposition;
            movementDirection = posDif / posDif.magnitude;
            positionVelocity = Mathf.Clamp(posDif.magnitude, 0, 10);
            if (posDif.magnitude > maxMagnitude) {
                posDif = movementDirection * maxMagnitude;
            }
            parentObject.transform.position += movementFactor * posDif * gameObject.GetComponent<Camera>().orthographicSize / 5;
        } 
        
        prevposition = currentposition;

        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        bool objectSelected = EventSystem.current.IsPointerOverGameObject();

        if (!objectSelected && mouseWheel < 0 && gameObject.GetComponent<Camera>().orthographicSize < maxOrthoSize) {
            gameObject.GetComponent<Camera>().orthographicSize += scrollsensitivity * 0.1f;
        } else if (!objectSelected && mouseWheel > 0 && gameObject.GetComponent<Camera>().orthographicSize > minOrthoSize) {
            gameObject.GetComponent<Camera>().orthographicSize -= scrollsensitivity * 0.1f;
        }
    }
}
