using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReachARoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("ReachARoomUI").GetComponent<Canvas>().enabled = false;

        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () {

            Debug.Log("pressed");

            GameObject.Find("ReachARoomUI").GetComponent<Canvas>().enabled = true;
            
            //Set RName button as active
            GameObject obj1 = GameObject.Find("RName");
            RoomName_Script roomScript = obj1.GetComponent<RoomName_Script>();
            roomScript.GetComponent<Button>().Select();
            roomScript.activeName = true;

            //Set RNumber button as no active
            GameObject obj2 = GameObject.Find("RNumber");
            RoomNumber_Script roomNScript = obj2.GetComponent<RoomNumber_Script>();
            roomNScript.activeNumber = false;

            //update data
            GameObject roomListObj = GameObject.Find("RoomsList");
            RoomsList roomList = roomListObj.GetComponent<RoomsList>();
            roomList.NotifyDatasetChanged();

            GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = false;

        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
