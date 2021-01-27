
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingInLineManager : MonoBehaviour
{

    public Text ETA;
    public Text DidYouKnow;
    public Text Curiosity;
    public Text FindMore;
    public Image Background;
    public Image Artwork;
    public Image CloseButton;
    Vector3 BackgroundPosition;
    Vector3 DidYouKnowPosition;
    Vector3 ETAPosition;
    Vector3 ArtworkPosition;
    Vector3 CuriosityPosition;
    Vector3 FindMorePosition;
    Vector3 CloseButtonPosition;

    public string checkInfoLoaded;

    int time = 5;


    private void Start()
    {

        checkInfoLoaded = "Null";

    }

    // Update is called once per frame
    void Update()
    {

        GameObject sessionOrigin = GameObject.Find("AR Session Origin");
        ScanImages scanImages = sessionOrigin.GetComponent<ScanImages>();

        string whatIsScanning = scanImages.whatIsTracking;

        //Open Ini file
        INIParser ini = new INIParser();
        ini.Open(Application.persistentDataPath + "map.txt");

        Debug.Log("I'm scanning: " + whatIsScanning);

        string informations = ini.ReadValue("WaitInLine", whatIsScanning, "None|None|None");
        

        if(informations[0].Equals("None"))
        {
            GameObject.Find("UICanvas").GetComponent<Canvas>().enabled = false;
        } else if(!informations[0].Equals("None") && GameObject.Find("UICanvas").GetComponent<Canvas>().enabled == false)
        {
            GameObject.Find("UICanvas").GetComponent<Canvas>().enabled = true;
        }

        string[] informationsSplitted = new string[3];

        informationsSplitted = informations.Split('|');
        
        checkInfoLoaded = informationsSplitted[0];

        ETA.text = "Estimated time to enter: " + informationsSplitted[0] + " min.";
        Curiosity.text = informationsSplitted[2];

        Sprite texture = Resources.Load<Sprite>("WaitInLineImages/"+informationsSplitted[1]);
        Artwork.GetComponent<Image>().sprite = texture;


        time++;

        if (time > 4)
        {
            time = 0;
            BackgroundPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            DidYouKnowPosition = BackgroundPosition;
            DidYouKnowPosition.y += 420;
            ETAPosition = BackgroundPosition;
            ETAPosition.y += 630;
            ArtworkPosition = BackgroundPosition;
            ArtworkPosition.y += 50;
            CuriosityPosition = BackgroundPosition;
            CuriosityPosition.y -= 450;
            FindMorePosition = BackgroundPosition;
            FindMorePosition.y -= 660;
            CloseButtonPosition = BackgroundPosition;
            CloseButtonPosition.y += 630;
            CloseButtonPosition.x += 382;


            if (Background.transform.position.x - BackgroundPosition.x > 20 || Background.transform.position.x - BackgroundPosition.x < -20 || Background.transform.position.y - BackgroundPosition.y > 20 || Background.transform.position.y - BackgroundPosition.y < -20 || Background.transform.position.z - BackgroundPosition.z > 20 || Background.transform.position.z - BackgroundPosition.z < -20)
            {
                DidYouKnow.transform.position = DidYouKnowPosition;
                ETA.transform.position = ETAPosition;
                Background.transform.position = BackgroundPosition;
                Artwork.transform.position = ArtworkPosition;
                Curiosity.transform.position = CuriosityPosition;
                FindMore.transform.position = FindMorePosition;
                CloseButton.transform.position = CloseButtonPosition;
            }
        }


    }
}
