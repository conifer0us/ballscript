using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LanguageObjects;
using UnityEngine.SceneManagement;

public class SceneManipulationAPI : MonoBehaviour
{
    public static void resetProgram() {
        List<GameObject> rootObjects = getStateAndClearBalls();
        foreach (GameObject sceneObject in rootObjects) {
            if (sceneObject.layer == LayerMask.NameToLayer("Operators") && sceneObject.GetComponent<Conditional>() != null) {
                sceneObject.GetComponent<Conditional>().setTrue();
            }
        }
    }

    public static void clearObjects() {
        List<GameObject> rootObjects = getStateAndClearBalls();
        foreach (GameObject sceneObject in rootObjects) {
            if (sceneObject.layer == LayerMask.NameToLayer("Operators")) {
                GameObject.Destroy(sceneObject);
            }
        }
    }

    public static void clearBalls() {
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);
        foreach (GameObject sceneObject in rootObjects) {
            if (sceneObject.layer == LayerMask.NameToLayer("DataBall")) {
                GameObject.Destroy(sceneObject);
            }
        }
    }

    private static List<GameObject> getStateAndClearBalls() {
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);
        foreach (GameObject sceneObject in rootObjects) {
            if (sceneObject.layer == LayerMask.NameToLayer("DataBall")) {
                GameObject.Destroy(sceneObject);
            }
        }
        return rootObjects;
    }
}
