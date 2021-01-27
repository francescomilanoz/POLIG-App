using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoShowArtwork : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowArtworkNo);
    }

    private void ShowArtworkNo()
    {
        if (!GameObject.Find("ImageC").GetComponent<Image>().enabled)
        {
            GameObject.Find("ImageC").GetComponent<Image>().enabled = true;
            GameObject.Find("Open").GetComponent<Canvas>().enabled = true;
            //GetComponent<Canvas>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
