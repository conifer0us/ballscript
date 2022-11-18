using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackAPI : MonoBehaviour
{
    Vector3 nextPlacementPosition;

    Stack<GameObject> memory;

    void Start() {
        nextPlacementPosition = new Vector3(-1.5f, -6, 0); 
        memory = new Stack<GameObject>();
    }

    public void pushObject(GameObject obj) {
        memory.Push(obj);
        moveObject(obj, nextPlacementPosition, new Vector3(0,0,0));
        nextPlacementPosition -= new Vector3(1,0,0);
    }

    public void popObject(Vector3 position, Vector3 velocity) {
        GameObject mostRecentPush; 
        try {mostRecentPush = memory.Pop();}
        catch {return;}
        moveObject(mostRecentPush, position, velocity);
        nextPlacementPosition += new Vector3(1,0,0);
    }

    private void moveObject(GameObject obj, Vector3 position, Vector3 velocity) {
        obj.transform.position = position;
        obj.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
