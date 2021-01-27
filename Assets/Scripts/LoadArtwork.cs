using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadArtwork : MonoBehaviour
{
    string targetArtwork;
    string targetArtworkID;

    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();

        b.onClick.AddListener(showArtwork);
    }

    private void showArtwork()
    {

        targetArtwork = GetComponent<Button>().GetComponentInChildren<Text>().text;

        //Open Ini file
        INIParser ini = new INIParser();
        ini.Open(Application.persistentDataPath + "map.txt");

        int j = 0;
        while (true)
        {
            j++;
            string valueRead = ini.ReadValue("Artworks", "A" + j, "" + 0);
            if (valueRead.Contains(targetArtwork))
            {
                targetArtworkID = "A" + j;
                break;
            }
            //da cancellare??
            if (valueRead.Equals("0"))
            {
                break;
            }
        }

        Debug.Log("ciao:" + targetArtworkID);

        
        sprite = Resources.Load<Sprite>("Images/" + targetArtworkID);
        GameObject.Find("ImageC").GetComponent<Image>().sprite = sprite;

        GameObject.Find("ImageToCompare").GetComponent<Canvas>().enabled = true;
        GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = false;        
        GameObject.Find("CompareUI").GetComponent<Canvas>().enabled = false;
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
