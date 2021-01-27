using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Load3dArrowArt : MonoBehaviour
{
    GameObject obj;
    GameObject obj1;
    ScanImages scanImages;
    ArtworksList artworksList;
    string startRoomName;
    string targetRoomName;
    string targetArtworkName;
    List<string> recordSteps = new List<string>();


    public void getCorrectDoor(string currentRoom, string targetRoomName, List<string> relations, List<string> currentSteps, int totalRooms)
    {
        //Base case
        if (currentSteps.Count > totalRooms)
        {
            return;
        }

        if (relations.Contains(currentRoom + "," + targetRoomName) || relations.Contains(targetRoomName + "," + currentRoom))
        {
            if (currentSteps.Count < recordSteps.Count || recordSteps.Count == 0)
            {

                //I also add the last step
                for (int s = 0; s < relations.Count; s++)
                {
                    if (relations[s].Equals(currentRoom + "," + targetRoomName) || relations[s].Equals(targetRoomName + "," + currentRoom))
                    {
                        currentSteps.Add("door" + (s + 1));
                    }

                }

                recordSteps.Clear();

                currentSteps.ForEach((item) =>
                {
                    recordSteps.Add((string)item.Clone());
                });

                return;
            }
            else
            {
                return;
            }

        }

        for (int j = 0; j < relations.Count; j++)
        {
            if (relations[j].Contains(currentRoom))
            {
                currentSteps.Add("door" + (j + 1));
                string newCurrent = relations[j];
                newCurrent = newCurrent.Replace(currentRoom, "");
                newCurrent = newCurrent.Replace(",", "");

                getCorrectDoor(newCurrent, targetRoomName, relations, currentSteps, totalRooms);
                currentSteps.Remove("door" + (j + 1));
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();

        b.onClick.AddListener(delegate () {

            obj = GameObject.Find("AR Session Origin");
            scanImages = obj.GetComponent<ScanImages>();
            startRoomName = scanImages.QRCordeScannedName;

            obj1 = GameObject.Find("ArtworksList");
            artworksList = obj1.GetComponent<ArtworksList>();

            targetArtworkName = GetComponent<Button>().GetComponentInChildren<Text>().text;

            //search for the room name associated with artwork name
            for (int i = 0; i < artworksList.artworksNameRoom.Count(); i++)
            {
                if (artworksList.artworksNameRoom[i][0].Contains(targetArtworkName))
                {
                    targetRoomName = artworksList.artworksNameRoom[i][6];
                }
            }

            Debug.Log("Start: " + startRoomName + "Target: " + targetRoomName);

            if (targetRoomName.Equals(startRoomName))
            {
                GetComponent<Button>().GetComponentInChildren<Text>().text = "you are already here!";
            }

            else
            {
                INIParser ini = new INIParser();


                ini.Open(Application.persistentDataPath + "map.txt");

                int k = 1;
                List<string> relations = new List<string>();
                bool check = true;
                while (check)
                {
                    relations.Add(ini.ReadValue("Doors", "door" + k, "null"));
                    if (relations[k - 1].Equals("null"))
                    {
                        relations.Remove("null");
                        check = false;
                    }
                    k++;
                }

                check = true;
                int totalRooms = 0;
                while (check)
                {
                    string tmpLetto = ini.ReadValue("Rooms", "" + (totalRooms + 1), "null");
                    if (!tmpLetto.Equals("null"))
                    {
                        totalRooms++;
                    }
                    else
                    {
                        check = false;
                    }
                }

                getCorrectDoor(startRoomName, targetRoomName, relations, new List<string>(), totalRooms);

                Debug.Log("Stanze percorse: " + recordSteps.Count);
                for (int f = 0; f < recordSteps.Count; f++)
                {
                    Debug.Log(recordSteps[f] + "");
                }


                int gradi = ini.ReadValue("Degrees", startRoomName + "," + recordSteps[0], -1);

                ini.WriteValue("ArrowSettings", "color", "green");
                ini.Close();

                //Set as visible the 3D arrow
                GameObject PrefabToTrackedImagesManager = GameObject.Find("PrefabToTrackedImagesManager");
                PrefabToTrackedImagesManagerScript script = PrefabToTrackedImagesManager.GetComponent<PrefabToTrackedImagesManagerScript>();
                script.m_SpawnedTwoPrefab.SetActive(true);
                script.doorDegree = gradi;

                Debug.Log("GRADI TROVATI: " + gradi);


                //Now, a navigation is active --> at next scan I'll continue with this navigation, until you reach the final room
                GameObject navigationStatusKeeper = GameObject.Find("NavigationStatusKeeper");
                NavigationStatusKeeper navScript = navigationStatusKeeper.GetComponent<NavigationStatusKeeper>();
                navScript.targetRoomName = targetRoomName;


                Debug.Log(gradi);

                GameObject.Find("ReachAnArtworkUI").GetComponent<Canvas>().enabled = false;
                GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = false;

            }
        });

    }


    // Update is called once per frame
    void Update()
    {

    }
}

