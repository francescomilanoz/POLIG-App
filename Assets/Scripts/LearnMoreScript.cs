using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearnMoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () {

            GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = false;


            //Set as visible the informations
            GameObject PrefabToTrackedImagesManager = GameObject.Find("PrefabToTrackedImagesManager");
            PrefabToTrackedImagesManagerScript script = PrefabToTrackedImagesManager.GetComponent<PrefabToTrackedImagesManagerScript>();
            script.m_SpawnedOnePrefab.SetActive(true);

            Text[] values = script.m_SpawnedOnePrefab.GetComponentsInChildren<Text>();

            GameObject obj = GameObject.Find("AR Session Origin");
            ScanImages scanImages = obj.GetComponent<ScanImages>();
            string artwork = scanImages.whatIsTracking;

            INIParser ini = new INIParser();
            ini.Open(Application.persistentDataPath + "map.txt");
            string info = ini.ReadValue("Artworks", artwork, "null");

            string[] infoSplitted = new string[7];
            infoSplitted = info.Split('|');

            values[0].text = infoSplitted[0];
            values[1].text = "Artist: " + infoSplitted[1] + "\n\nYear: " + infoSplitted[2] + "\n\nMedium: " + infoSplitted[3] + "\n\nDimensions: " + infoSplitted[4] + "\n\nDescription: " + infoSplitted[5];

            //GameObject name = script.m_SpawnedOnePrefab.transform.Find("ArtworkName").gameObject;
            //name.GetComponent<Text>().text = "ciao";

        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
