using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArtistScript : MonoBehaviour
{
    public bool activeArtist = true;
    public bool clicked;
    GameObject obj;
    DateScript dateScript;
    ColorScript colorScript;

    // Start is called before the first frame update
    void Start()
    {
        //Button selected at start
        activeArtist = true;
        gameObject.GetComponent<Button>().onClick.AddListener(changeStatus);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activeArtist = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activeArtist = false;
    }

    private void changeStatus()
    {
        //if click on this button -> set false the others
        obj = GameObject.Find("Date");
        dateScript = obj.GetComponent<DateScript>();
        dateScript.activeDate = false;

        obj = GameObject.Find("Color");
        colorScript = obj.GetComponent<ColorScript>();
        colorScript.activeColor = false;

        activeArtist = true;

        //Update Recycler View list
        GameObject roomListObj = GameObject.Find("CompareList");
        CompareList roomList = roomListObj.GetComponent<CompareList>();
        roomList.NotifyDatasetChanged();

    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("Date");
        dateScript = obj.GetComponent<DateScript>();

        obj = GameObject.Find("Color");
        colorScript = obj.GetComponent<ColorScript>();

        if (dateScript.activeDate || colorScript.activeColor)
        {
            activeArtist = false;
        }
        if (activeArtist)
        {
            if (clicked)
            {
                GetComponent<Button>().onClick.Invoke();
                clicked = false;
            }            

        }
    }
}