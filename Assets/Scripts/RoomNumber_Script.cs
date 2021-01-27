using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomNumber_Script : MonoBehaviour
{
    public bool activeNumber;
    GameObject obj;
    RoomName_Script roomName;

    void Start()
    {
        activeNumber = false;
        gameObject.GetComponent<Button>().onClick.AddListener(changeStatus);


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activeNumber = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activeNumber = false;
    }

    private void changeStatus()
    {

        obj = GameObject.Find("RName");
        roomName = obj.GetComponent<RoomName_Script>();
        roomName.activeName = false;

        activeNumber = true;

        GameObject roomListObj = GameObject.Find("RoomsList");
        RoomsList roomList = roomListObj.GetComponent<RoomsList>();
        roomList.NotifyDatasetChanged();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (activeNumber)
        {
            Button b = GetComponent<Button>();
            ColorBlock cb = b.colors;
            cb.normalColor = new Color(248, 157, 74);
            b.colors = cb;

        }
        else
        {
            Button b = GetComponent<Button>();
            ColorBlock cb = b.colors;
            cb.normalColor = Color.white;
            b.colors = cb;
        }*/
    }
}
