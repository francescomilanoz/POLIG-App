using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class CompareList : UI.RecyclerView<CompareList.Holder>.Adapter
{

    //Artworks list creation
    public List<string> artworks = new List<string>();
    //Artworks list creation with separated details
    public List<string[]> artworksDetails = new List<string[]>();
    //One list with all artworks with the same artist, date, color
    public List<string> artist = new List<string>();
    public List<string> date = new List<string>();
    public List<string> color = new List<string>();

    public GameObject row;
    GameObject obj1;
    GameObject obj2;
    GameObject obj3;

    ArtistScript artistScript;
    DateScript dateScript;
    ColorScript colorScript;
        
    public string artworkScannedValue;
    public string[] artworkScannedDetails;
    public string artwork;

    private void Start()
    {
        //Open Ini file
        INIParser ini = new INIParser();
        ini.Open(Application.persistentDataPath + "map.txt");

        int j = 0;
        while (true)
        {
            j++;
            string valueRead = ini.ReadValue("Artworks", "A" + j, "" + 0);
            artworks.Add(valueRead);
            Debug.Log("" + artworks[j - 1]);

            if (artworks[j - 1].Equals("0"))
            {
                artworks.Remove("0");
                break;
            }
        }

        //ini artworks output splitted with '|'
        for (int z = 0; z < artworks.Count(); z++)
        {
            artworksDetails.Add(artworks[z].Split('|'));
        }

        GameObject obj4 = GameObject.Find("AR Session Origin");
        ScanImages scannedImages = obj4.GetComponent<ScanImages>();
        artwork = scannedImages.whatIsTracking;

        artworkScannedValue = ini.ReadValue("Artworks", artwork, "null");
        
        artworkScannedDetails = artworkScannedValue.Split('|');

        //Delete precedent operations
        artist.Clear();
        date.Clear();
        color.Clear();

        for (int z = 0; z < artworks.Count(); z++)
        {
            if (artworksDetails[z][1].Equals(artworkScannedDetails[1]))
            {
                artist.Add(artworksDetails[z][0]);
            }            
            if (artworksDetails[z][2].Equals(artworkScannedDetails[2]))
            {
                date.Add(artworksDetails[z][0]);
            }
            if (artworksDetails[z][8].Equals(artworkScannedDetails[8]))
            {
                color.Add(artworksDetails[z][0]);
            }

        }

        //Order lists
        artist.Sort();
        date.Sort();
        color.Sort();

        ini.Close();
        NotifyDatasetChanged();
    }

    public Vector3 GetGridPosition(GameObject obj)
    {
        GameObject objAux = new GameObject();
        objAux.transform.position = obj.transform.position;
        return objAux.transform.position;
    }

    public override int GetItemCount()
    {
        obj1 = GameObject.Find("Artist");
        artistScript = obj1.GetComponent<ArtistScript>();

        obj2 = GameObject.Find("Date");
        dateScript = obj2.GetComponent<DateScript>();

        obj3 = GameObject.Find("Color");
        colorScript = obj3.GetComponent<ColorScript>();

        int counter = 0;

        if (artistScript.activeArtist)
        {
            counter = artist.Count();
        }

        if (dateScript.activeDate)
        {
            counter = date.Count();
        }

        if (colorScript.activeColor)
        {
            counter = color.Count();
        }
        return counter;
    }

    public override void OnBindViewHolder(Holder holder, int i)
    {
        
        obj1 = GameObject.Find("Artist");
        artistScript = obj1.GetComponent<ArtistScript>();

        obj2 = GameObject.Find("Date");
        dateScript = obj2.GetComponent<DateScript>();

        obj3 = GameObject.Find("Color");
        colorScript = obj3.GetComponent<ColorScript>();

        //check if Painting Button is clicked
        if (artistScript.activeArtist)
        {
            holder.text.text = artist[i];
        }
        //check if Sculpture Button is clicked
        if (dateScript.activeDate)
        {
            holder.text.text = date[i];
        }
        //check if Other Button is clicked
        if (colorScript.activeColor)
        {
            holder.text.text = color[i];
        }
    }

    public override GameObject OnCreateViewHolder()
    {
        return Instantiate(row);
    }

    public class Holder : ViewHolder
    {
        public Text text;

        public Holder(GameObject itemView) : base(itemView)
        {
            text = itemView.transform.Find("textRow").GetComponent<Text>();
        }
    }

    public void Update()
    {
    }
}
