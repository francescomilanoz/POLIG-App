using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class RoomsList : UI.RecyclerView<RoomsList.Holder>.Adapter {

    //Rooms list creation (eg. "room1,Antichi Egizi")
    public List<string> rooms = new List<string>();
    //Rooms list creation with separated name and number (eg. "room1", "Antichi Egizi")
    public List<string[]> roomsNumberName = new List<string[]>();
    //One list with name, one with number
    public List<string> names = new List<string>();
    public List<string> number = new List<string>();

    public GameObject row;
    GameObject obj1;
    GameObject obj2;
    RoomName_Script RoomName_Script;
    RoomNumber_Script RoomNumber_Script;

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
        while (true) {

            //I add all the rooms buttons (apart from the button of the current room)

            j++;
            string valueRead = ini.ReadValue("Rooms", "" + j, "" + 0);
            rooms.Add(valueRead);
       
         
            if (rooms[j - 1].Equals("0"))
            {
                rooms.Remove("0");
               break;
            }
        }

        //ini rooms output splitted with ','
        for (int z = 0; z < rooms.Count(); z++)
        {
            roomsNumberName.Add(rooms[z].Split(','));
        }

        //roomsNumberName slitted between room names or numbers
        for (int z = 0; z < rooms.Count(); z++)
        {
            number.Add(roomsNumberName[z][0]);
            names.Add(roomsNumberName[z][1]);
        }

        //Order list room names
        names.Sort();

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
        return rooms.Count;
    }

    public override void OnBindViewHolder(Holder holder, int i)
    {
        
        obj1 = GameObject.Find("RNumber");
        RoomNumber_Script = obj1.GetComponent<RoomNumber_Script>();

        obj2 = GameObject.Find("RName");
        RoomName_Script = obj2.GetComponent<RoomName_Script>();

        //check if Name Button is clicked
        if (RoomName_Script.activeName)
        {
            
            holder.text.text = names[i];
        }
        //check if Number Button is clicked
        if (RoomNumber_Script.activeNumber)
        {
            holder.text.text = number[i];
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
        //public Button button;

        public Holder(GameObject itemView) : base(itemView)
        {
            text = itemView.transform.Find("textRow").GetComponent<Text>();
            //button = itemView.transform.Find("buttonRow").GetComponent<Button>();
        }
    }

    public void Update()
    {        
    }
}


