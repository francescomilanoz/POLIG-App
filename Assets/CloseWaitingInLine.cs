using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWaitingInLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(closeUI);
    }


    private void closeUI()
    {
        //Set as invisible the informations
        GameObject PrefabToTrackedImagesManager = GameObject.Find("PrefabToTrackedImagesManager");
        PrefabToTrackedImagesManagerScript script = PrefabToTrackedImagesManager.GetComponent<PrefabToTrackedImagesManagerScript>();
        script.m_SpawnedFourPrefab.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

    }
}

