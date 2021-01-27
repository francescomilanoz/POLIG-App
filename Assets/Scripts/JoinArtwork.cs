using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class JoinArtwork : MonoBehaviour
{
    GameObject obj;
    ScanImages scanImages;

    // Start is called before the first frame update
    void Start()
    {
        Button b = GetComponent<Button>();
        b.onClick.AddListener(joinWaitingList);
        
    }

    private void joinWaitingList()
    {
        //Open Ini file
        INIParser ini = new INIParser();
        ini.Open(Application.persistentDataPath + "waitingList.txt");

        obj = GameObject.Find("AR Session Origin");
        scanImages = obj.GetComponent<ScanImages>();

        //If click "Join" button, increase "waiting" users
        int waitingUsers = ini.ReadValue("WaitingUsers", scanImages.imgScanned, 0);
        waitingUsers++;
        ini.WriteValue("WaitingUsers", scanImages.imgScanned, "" + waitingUsers);

        //Increase number of Active Users for that artwork
        int valueRead = ini.ReadValue("ActiveUsers", scanImages.imgScanned, 0);
        valueRead++;
        ini.WriteValue("ActiveUsers", scanImages.imgScanned, "" + valueRead);

        ini.Close();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
