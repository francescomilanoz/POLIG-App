using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ArtworksList : UI.RecyclerView<ArtworksList.Holder>.Adapter {

    //Artworks list creation
    public List<string> artworks = new List<string>();
    //Artworks list creation with separated name, room, details
    public List<string[]> artworksNameRoom = new List<string[]>();
    //One list with all paintings, one with sculptures, one with others
    public List<string> paintings = new List<string>();
    public List<string> sculptures = new List<string>();
    public List<string> others = new List<string>();

    public GameObject row;
    GameObject obj1;
    GameObject obj2;
    GameObject obj3;
    SculptureScript sculptureScript;
    PaintingScript paintingScript;
    OtherScript otherScript;


    private void Start()
    {
        //Open Ini file
        INIParser ini = new INIParser();

        TextAsset[] l_assets = Resources.LoadAll("Data", typeof(TextAsset)).Cast<TextAsset>().ToArray();
        for (int i = 0; i < l_assets.Length; i++)
        {
            File.WriteAllBytes(Application.persistentDataPath + l_assets[i].name + ".txt", l_assets[i].bytes);
        }

        ini.Open(Application.persistentDataPath + "map.txt");


        int j = 0;
        while (true)
        {
            j++;
            string valueRead = ini.ReadValue("Artworks", "A" + j, "" + 0);
            artworks.Add(valueRead);
            Debug.Log("" + artworks[j-1]);


            if (artworks[j - 1].Equals("0"))
            {
                artworks.Remove("0");
                break;
            }
        }

        //ini artworks output splitted with '|'
        for (int z = 0; z < artworks.Count(); z++)
        {
            artworksNameRoom.Add(artworks[z].Split('|'));
        }

        //artworksNameRoom slitted between painting, sculpture or other
        for (int z = 0; z < artworks.Count(); z++)
        {
            if (artworksNameRoom[z][7].Equals("Painting")){
                paintings.Add(artworksNameRoom[z][0]);
            }
            if (artworksNameRoom[z][7].Equals("Sculpture"))
            {
                sculptures.Add(artworksNameRoom[z][0]);
            }
            if (artworksNameRoom[z][7].Equals("Other"))
            {
                others.Add(artworksNameRoom[z][0]);
            }

        }

        //Order lists
        paintings.Sort();
        sculptures.Sort();
        others.Sort();

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
        obj1 = GameObject.Find("Painting");
        paintingScript = obj1.GetComponent<PaintingScript>();

        obj2 = GameObject.Find("Sculpture");
        sculptureScript = obj2.GetComponent<SculptureScript>();

        obj3 = GameObject.Find("Other");
        otherScript = obj3.GetComponent<OtherScript>();

        int counter = 0;

        if (paintingScript.activePainting)
        {
            counter = paintings.Count();
        }
       
        if (sculptureScript.activeSculpture)
        {
            counter = sculptures.Count();
        }

        if (otherScript.activeOther)
        {
            counter = others.Count();
        }
        return counter;
    }

    public override void OnBindViewHolder(Holder holder, int i)
    {
        
        obj1 = GameObject.Find("Painting");
        paintingScript = obj1.GetComponent<PaintingScript>();

        obj2 = GameObject.Find("Sculpture");
        sculptureScript = obj2.GetComponent<SculptureScript>();

        obj2 = GameObject.Find("Other");
        otherScript = obj2.GetComponent<OtherScript>();

        //check if Painting Button is clicked
        if (paintingScript.activePainting)
        {
            holder.text.text = paintings[i];
        }
        //check if Sculpture Button is clicked
        if (sculptureScript.activeSculpture)
        {
            holder.text.text = sculptures[i];
        }
        //check if Other Button is clicked
        if (otherScript.activeOther)
        {
            holder.text.text = others[i];
        }

        /*
        holder.button.onClick.RemoveAllListeners();
        holder.button.onClick.AddListener(delegate ()
        {
           //Azione da eseguire
        });
        */
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