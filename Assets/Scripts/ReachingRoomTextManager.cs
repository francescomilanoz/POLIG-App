using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReachingRoomTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject statusKeeper = GameObject.Find("NavigationStatusKeeper");
        NavigationStatusKeeper script = statusKeeper.GetComponent<NavigationStatusKeeper>();

        if (script.targetRoomName.Equals("None"))
        {
            GameObject.Find("NavigationStatusUI").GetComponent<Canvas>().enabled = false;
        }
        else
        {
            GameObject.Find("NavigationStatusUI").GetComponent<Canvas>().enabled = true;
        }

        INIParser ini = new INIParser();
        ini.Open(Application.persistentDataPath + "map.txt");
;
        string[] roomNumberAndName = new string[2];

        int count = 1;
        while(true)
        {
            string tmp = ini.ReadValue("Rooms", count + "", "null");
            if (tmp.Equals("null"))
                break;

            string[] associationTmp = new string[2];

            associationTmp = tmp.Split(',');

            if(associationTmp[0].Equals(script.targetRoomName))
            {
                roomNumberAndName[0] = associationTmp[0];
                roomNumberAndName[1] = associationTmp[1];
                break;
            }

            count++;
            
        }

        gameObject.GetComponent<Text>().text = "Reaching " + roomNumberAndName[0] + " (" + roomNumberAndName[1] + ")";

    }
}
