using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CompareScript : MonoBehaviour
{
    string artwork;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Compare);
    }

    private void Compare()
    {

        GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = false;

        GameObject obj = GameObject.Find("AR Session Origin");
        ScanImages scanImages = obj.GetComponent<ScanImages>();
        artwork = scanImages.whatIsTracking;

        GameObject.Find("CompareUI").GetComponent<Canvas>().enabled = true;
        GameObject compareListObj = GameObject.Find("CompareList");
        CompareList compareList = compareListObj.GetComponent<CompareList>();
        compareList.artwork = artwork;

        //Open Ini file
        INIParser ini = new INIParser();
        ini.Open(Application.persistentDataPath + "map.txt");

        compareList.artworkScannedValue = ini.ReadValue("Artworks", artwork, "null");
        compareList.artworkScannedDetails = compareList.artworkScannedValue.Split('|');

        //Delete precedent operations
        compareList.artist.Clear();
        compareList.date.Clear();
        compareList.color.Clear();

        //Set Actist button as active
        GameObject obj1 = GameObject.Find("Artist");
        ArtistScript artistScript = obj1.GetComponent<ArtistScript>();
        artistScript.GetComponent<Button>().Select();

        GameObject obj2 = GameObject.Find("Artist");
        artistScript = obj2.GetComponent<ArtistScript>();
        artistScript.activeArtist = true;
        artistScript.clicked = true;

        GameObject obj3 = GameObject.Find("Date");
        DateScript dateScript = obj3.GetComponent<DateScript>();
        dateScript.activeDate = false;

        GameObject obj4 = GameObject.Find("Color");
        ColorScript colorScript = obj4.GetComponent<ColorScript>();
        colorScript.activeColor = false;


        for (int z = 0; z < compareList.artworks.Count(); z++)
        {
            if (!compareList.artworkScannedDetails[0].Equals(compareList.artworksDetails[z][0]))
            {
                if (compareList.artworksDetails[z][1].Equals(compareList.artworkScannedDetails[1]))
                {
                    compareList.artist.Add(compareList.artworksDetails[z][0]);
                }
                if (compareList.artworksDetails[z][2].Equals(compareList.artworkScannedDetails[2]))
                {
                    compareList.date.Add(compareList.artworksDetails[z][0]);
                }
                if (compareList.artworksDetails[z][8].Equals(compareList.artworkScannedDetails[8]))
                {
                    compareList.color.Add(compareList.artworksDetails[z][0]);
                }
            }            
        }


        compareList.artist.Sort();
        compareList.date.Sort();
        compareList.color.Sort();

        compareList.NotifyDatasetChanged();
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
