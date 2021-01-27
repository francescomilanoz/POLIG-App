using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(loadTutorial);
        
    }

    private void loadTutorial()
    {
        INIParser skipTutorial = new INIParser();
        skipTutorial.Open(Application.persistentDataPath + "firstTime.txt");
        skipTutorial.WriteValue("FirstTime", "first", "false");
        skipTutorial.Close();
        
        SceneManager.LoadScene("Introduction");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
