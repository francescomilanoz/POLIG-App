using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorScript : MonoBehaviour
{
    public bool activeColor = false;
    GameObject obj;
    
    DateScript dateScript;
    ArtistScript artistScript;

    // Start is called before the first frame update
    void Start()
    {
        //Button selected at start
        activeColor = false;
        gameObject.GetComponent<Button>().onClick.AddListener(changeStatus);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activeColor = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activeColor = false;
    }

    private void changeStatus()
    {
        //if click on this button -> set false the others
        obj = GameObject.Find("Date");
        dateScript = obj.GetComponent<DateScript>();
        dateScript.activeDate = false;

        obj = GameObject.Find("Artist");
        artistScript = obj.GetComponent<ArtistScript>();
        artistScript.activeArtist = false;

        activeColor = true;

        //Update Recycler View list
        GameObject roomListObj = GameObject.Find("CompareList");
        CompareList roomList = roomListObj.GetComponent<CompareList>();
        roomList.NotifyDatasetChanged();

    }

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.Find("Artist");
        artistScript = obj.GetComponent<ArtistScript>();

        obj = GameObject.Find("Date");
        dateScript = obj.GetComponent<DateScript>();

        if (artistScript.activeArtist || dateScript.activeDate)
        {
            activeColor = false;
        }
    }
}