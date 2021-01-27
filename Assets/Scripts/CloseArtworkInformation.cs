using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseArtworkInformation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(closeUI);
    }


    private void closeUI()
    {
        GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = true;

        //Set as invisible the informations
        GameObject PrefabToTrackedImagesManager = GameObject.Find("PrefabToTrackedImagesManager");
        PrefabToTrackedImagesManagerScript script = PrefabToTrackedImagesManager.GetComponent<PrefabToTrackedImagesManagerScript>();
        script.m_SpawnedOnePrefab.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

    }
}

