using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangerTrevor : MonoBehaviour
{
    public string SceneToLoad;
    int sceneIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        print(SceneManager.sceneCountInBuildSettings);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton0) || OVRInput.GetUp(OVRInput.Button.One))
        {
            //print(sceneIndex);
            print(SceneToLoad);
            SceneManager.LoadScene(SceneToLoad);
            //SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName(SceneToLoad));

        }
    }
}
