using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class ScanImages : MonoBehaviour
{
    public string QRCordeScannedName;
    public string ArtworkScannedName;
    public String imgScanned;
    public string ArtworkScannedNameJe;
    public string WaitingScanned;

    public String artworkS;


    GameObject obj;
    GameObject obj1;
    ScanImages scanImages;
    RoomsList roomsList;
    string startRoomName;
    string targetRoomName;
    string targetRoomNName;
    List<string> recordSteps = new List<string>();


    public string whatIsTracking;

    // Start is called before the first frame update
    void Start()
    {

        /*GameObject.Find("byroom").GetComponent<Image>().enabled = false;
        GameObject.Find("byart").GetComponent<Image>().enabled = false;
        GameObject.Find("Compare").GetComponent<Image>().enabled = false;
        GameObject.Find("leave comment").GetComponent<Image>().enabled = false;
        GameObject.Find("learn more").GetComponent<Image>().enabled = false;
        GameObject.Find("CompareText").GetComponent<Text>().enabled = false;
        GameObject.Find("CommentText").GetComponent<Text>().enabled = false;
        GameObject.Find("LearnMoreText").GetComponent<Text>().enabled = false;
       
        GameObject.Find("LearnMoreText").GetComponent<Text>().enabled = false; */
        GameObject.Find("WaitingUI").GetComponent<Canvas>().enabled = false;
        GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = false;
        GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = false;
        GameObject.Find("CompareUI").GetComponent<Canvas>().enabled = false;
        GameObject.Find("ImageToCompare").GetComponent<Canvas>().enabled = false;

        whatIsTracking = "None";

        recordSteps = new List<string>();
    }

    private void Update()
    {
        
          
    }




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


    void updateUI (ARTrackedImage img)
    {

        imgScanned = img.referenceImage.name;

        Debug.Log("Nome: " + img.referenceImage.name);        

        if (img.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited || img.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.None)
        {

            ArtworkScannedName = img.referenceImage.name;

            if (whatIsTracking.Equals(img.referenceImage.name))
            { 

                if (img.referenceImage.name.Contains("A"))
                {
                    GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = false;
                 

                    GameObject.Find("WaitingUI").GetComponent<Canvas>().enabled = false;

                    GameObject.Find("CompareUI").GetComponent<Canvas>().enabled = false;

                    GameObject.Find("ImageToCompare").GetComponent<Canvas>().enabled = false;

                }
            if (img.referenceImage.name.Contains("r"))
            {
                /*
                GameObject.Find("byart").GetComponent<Image>().enabled = false;
                GameObject.Find("byroom").GetComponent<Image>().enabled = false;
                */

                GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = false;
                GameObject.Find("ReachAnArtworkUI").GetComponent<Canvas>().enabled = false;
                GameObject.Find("ReachARoomUI").GetComponent<Canvas>().enabled = false;

            }


                if (img.referenceImage.name.Contains("L"))
                {

                    //For wait in line feature, no action in UI is required. 

                }


                    whatIsTracking = "None";
                artworkS = "None";


        }
        }
        else {

            artworkS = img.referenceImage.name;
            whatIsTracking = img.referenceImage.name;

            Debug.Log("STO TRACCIANDO: " + whatIsTracking);

            if (img.referenceImage.name.Contains("A"))
            {
                ArtworkScannedNameJe = img.referenceImage.name;

                //Open Ini file
                INIParser ini = new INIParser();
                ini.Open(Application.persistentDataPath + "waitingList.txt");

                int valueRead = ini.ReadValue("ActiveUsers", img.referenceImage.name, 0);
                if (valueRead >= 3)
                {
                    if(GameObject.Find("WaitingUI") != null)
                    {
                        GameObject.Find("WaitingUI").GetComponent<Canvas>().enabled = true;
                    }                   
                }
                else
                {
                    GameObject PrefabToTrackedImagesManager = GameObject.Find("PrefabToTrackedImagesManager");
                    PrefabToTrackedImagesManagerScript script = PrefabToTrackedImagesManager.GetComponent<PrefabToTrackedImagesManagerScript>();
                   

                    if (GameObject.Find("ArtworkUI") != null && script.m_SpawnedOnePrefab.active == false && script.m_SpawnedThreePrefab.active == false && GameObject.Find("CompareUI").GetComponent<Canvas>().enabled == false && GameObject.Find("ImageToCompare").GetComponent<Canvas>().enabled == false)
                    {
                        GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = true;
                    }                    
                }

                ini.Close();

            }
            if (img.referenceImage.name.Contains("r"))
            {

                QRCordeScannedName = img.referenceImage.name;

                /*
                GameObject.Find("byart").GetComponent<Image>().enabled = true;
                GameObject.Find("byroom").GetComponent<Image>().enabled = true;
                */

                GameObject PrefabToTrackedImagesManager = GameObject.Find("PrefabToTrackedImagesManager");
                PrefabToTrackedImagesManagerScript script = PrefabToTrackedImagesManager.GetComponent<PrefabToTrackedImagesManagerScript>();

                GameObject statusKeeper = GameObject.Find("NavigationStatusKeeper");
                NavigationStatusKeeper navScript = statusKeeper.GetComponent<NavigationStatusKeeper>();

                Image roomReachedNot = GameObject.Find("RoomReachedNotification").GetComponent<Image>();

                //In this case I'm not in a navigation
                if (navScript.targetRoomName.Equals("None") && GameObject.Find("ReachARoomUI").GetComponent<Canvas>().enabled == false && GameObject.Find("ReachAnArtworkUI").GetComponent<Canvas>().enabled == false && script.m_SpawnedTwoPrefab.active == false && roomReachedNot.enabled == false)
                    GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = true;

                //In this case, I'm already in a navigation
                if(!navScript.targetRoomName.Equals("None") && GameObject.Find("ReachARoomUI").GetComponent<Canvas>().enabled == false && GameObject.Find("ReachAnArtworkUI").GetComponent<Canvas>().enabled == false && script.m_SpawnedTwoPrefab.active == false && roomReachedNot.enabled == false)
                {

                    obj = GameObject.Find("AR Session Origin");
                    scanImages = obj.GetComponent<ScanImages>();

                    QRCordeScannedName = img.referenceImage.name;
                    startRoomName = scanImages.QRCordeScannedName;

                    obj1 = GameObject.Find("RoomsList");
                    roomsList = obj1.GetComponent<RoomsList>();

                    targetRoomNName = navScript.targetRoomName;

                    Debug.Log("start: " + startRoomName + "target: " + targetRoomName);


                    //search for the room number associated with the room name
                    for (int i = 0; i < roomsList.rooms.Count(); i++)
                    {
                        if (roomsList.rooms[i].Contains(targetRoomNName))
                        {
                            targetRoomName = roomsList.number[i];
                        }
                    }

                    //If you are in the same room
                    if (targetRoomName.Equals(startRoomName))
                    {
                        GameObject.Find("RoomReachedNotification").GetComponent<Image>().enabled = true;
                        GameObject.Find("RoomReachedText").GetComponent<Text>().enabled = true;

                        GameObject navigationStatusKeeper3 = GameObject.Find("NavigationStatusKeeper");
                        NavigationStatusKeeper navScript3 = navigationStatusKeeper3.GetComponent<NavigationStatusKeeper>();
                        navScript3.targetRoomName = "None";


                        Text notificationText = GameObject.Find("RoomReachedText").GetComponent<Text>();



                        INIParser ini2 = new INIParser();
                        ini2.Open(Application.persistentDataPath + "map.txt");
                        ;
                        string[] roomNumberAndName = new string[2];

                        int count = 1;
                        while (true)
                        {
                            string tmp = ini2.ReadValue("Rooms", count + "", "null");
                            if (tmp.Equals("null"))
                                break;

                            string[] associationTmp = new string[2];

                            associationTmp = tmp.Split(',');

                            if (associationTmp[0].Equals(targetRoomName))
                            {
                                roomNumberAndName[0] = associationTmp[0];
                                roomNumberAndName[1] = associationTmp[1];
                                break;
                            }

                            count++;

                        }



                        notificationText.text = "You have reached " + targetRoomName + " (" + roomNumberAndName[1] + ")!";


                        Debug.Log("disabling reacharoomUI");

                        GameObject.Find("ReachARoomUI").GetComponent<Canvas>().enabled = false;
                        GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = false;
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

                        Debug.Log("Start room: " + startRoomName + " Target room: " + targetRoomName + " Total rooms: " + totalRooms);
                        for (int i = 0; i < relations.Count; i++)
                            Debug.Log("Relation [" + i + "]: " + relations[i]);

                        

                        for (int j = 0; j < recordSteps.Count; j++)
                            Debug.Log("RecordSteps [" + j + "]: " + recordSteps[j]);

                        
                        recordSteps.Clear();
                        getCorrectDoor(startRoomName, targetRoomName, relations, new List<string>(), totalRooms);

                        Debug.Log("Stanze percorse: " + recordSteps.Count);
                        for (int f = 0; f < recordSteps.Count; f++)
                        {
                            Debug.Log(recordSteps[f] + "");
                        }


                        int gradi = ini.ReadValue("Degrees", startRoomName + "," + recordSteps[0], -1);


                        //ini.WriteValue("ArrowSettings", "color", "green");
                        //ini.Close();

                        //Set as visible the 3D arrow
                        GameObject prefabToTrackedImagesManager = GameObject.Find("PrefabToTrackedImagesManager");
                        PrefabToTrackedImagesManagerScript arrowScript = prefabToTrackedImagesManager.GetComponent<PrefabToTrackedImagesManagerScript>();
                        arrowScript.m_SpawnedTwoPrefab.SetActive(true);
                        arrowScript.doorDegree = gradi;

                        //Now, a navigation is active --> at next scan I'll continue with this navigation, until you reach the final room
                        GameObject navigationStatusKeeper2 = GameObject.Find("NavigationStatusKeeper");
                        NavigationStatusKeeper navScript2 = navigationStatusKeeper2.GetComponent<NavigationStatusKeeper>();
                        navScript2.targetRoomName = targetRoomName;

                        Debug.Log("GRADI TROVATI: " + gradi);


                        Debug.Log("disabling reacharoomUI");

                        GameObject.Find("ReachARoomUI").GetComponent<Canvas>().enabled = false;
                        GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = false;

                    }


                }

                //GameObject vars = GameObject.Find("PublicVariables");
                //PublicVariablesScript script = vars.GetComponent<PublicVariablesScript>();
                //script.roomCodeScanned = true;
            }




            if (img.referenceImage.name.Contains("L"))
            {

                WaitingScanned = img.referenceImage.name;
                Debug.Log("Waiting for: " + WaitingScanned);

            }


        }
    }

    [SerializeField]
        ARTrackedImageManager m_TrackedImageManager;

        void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

        void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

        void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {


        foreach (var newImage in eventArgs.added)
            {

            updateUI(newImage);
        }

            foreach (var updatedImage in eventArgs.updated)
            {            

            // Handle updated event
            updateUI(updatedImage);

        }

            foreach (var removedImage in eventArgs.removed)
            {

            // Handle removed event
            updateUI(removedImage);
        }
        }


}
