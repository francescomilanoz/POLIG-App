using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class IniManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        INIParser ini = new INIParser();

        TextAsset[] l_assets = Resources.LoadAll("Data", typeof(TextAsset)).Cast<TextAsset>().ToArray();
        for (int i = 0; i < l_assets.Length; i++)
        {
            File.WriteAllBytes(Application.persistentDataPath + l_assets[i].name + ".txt", l_assets[i].bytes);
        }

        ini.Open(Application.persistentDataPath + "map.txt");

        /*
        int gradi = ini.ReadValue("Degrees", "room1,door3", 0);

        if (gradi == 90)
        {
            GameObject.Find("title").GetComponent<Image>().enabled = false;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
