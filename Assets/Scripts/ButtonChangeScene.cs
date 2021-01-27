using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChangeScene : MonoBehaviour
{

	public void LoadOtherScene(string nameSceneToLoad)
    {
        SceneManager.LoadScene(nameSceneToLoad);
    }
    
}
