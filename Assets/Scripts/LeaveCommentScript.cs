using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaveCommentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
   

        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () {

            

            //Set as visible the video
            GameObject PrefabToTrackedImagesManager = GameObject.Find("PrefabToTrackedImagesManager");
            PrefabToTrackedImagesManagerScript script = PrefabToTrackedImagesManager.GetComponent<PrefabToTrackedImagesManagerScript>();
            script.m_SpawnedThreePrefab.SetActive(true);

            script.m_SpawnedThreePrefab.GetComponentInChildren<LoadCommentsManager>().todo = true;

            GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = false;

        });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
