using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowImageC : MonoBehaviour
{
    Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowArtwork);
    }
    private void ShowArtwork()
    {
        if (GameObject.Find("ImageC").GetComponent<Image>().enabled)
        {
            GameObject.Find("ImageC").GetComponent<Image>().enabled = false;

            sprite = Resources.Load<Sprite>("Images/Close");
            GameObject.Find("Open").GetComponent<Image>().sprite = sprite;
        }
        else
        {
            GameObject.Find("ImageC").GetComponent<Image>().enabled = true;

            sprite = Resources.Load<Sprite>("Images/Show");
            GameObject.Find("Open").GetComponent<Image>().sprite = sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
