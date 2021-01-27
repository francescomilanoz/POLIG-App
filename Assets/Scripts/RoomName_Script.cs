using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomName_Script : MonoBehaviour
{

    public bool activeName = true;
    GameObject obj;
    RoomNumber_Script roomNumber;

    // Start is called before the first frame update
    void Start()
    {
        activeName = true;
        gameObject.GetComponent<Button>().onClick.AddListener(changeStatus);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activeName = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activeName = false;
    }

    private void changeStatus()
    {

        obj = GameObject.Find("RNumber");
        roomNumber = obj.GetComponent<RoomNumber_Script>();
        roomNumber.activeNumber = false;

        activeName = true;

        GameObject roomListObj = GameObject.Find("RoomsList");
        RoomsList roomList = roomListObj.GetComponent<RoomsList>();
        roomList.NotifyDatasetChanged();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
