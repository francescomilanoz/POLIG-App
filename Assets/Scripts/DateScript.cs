using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DateScript : MonoBehaviour
{
    public bool activeDate = false;
    GameObject obj;
    
    ArtistScript artistScript;
    ColorScript colorScript;

    // Start is called before the first frame update
    void Start()
    {
        //Button selected at start
        activeDate = false;
        gameObject.GetComponent<Button>().onClick.AddListener(changeStatus);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activeDate = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activeDate = false;
    }

    private void changeStatus()
    {
        //if click on this button -> set false the others
        obj = GameObject.Find("Artist");
        artistScript = obj.GetComponent<ArtistScript>();
        artistScript.activeArtist = false;

        obj = GameObject.Find("Color");
        colorScript = obj.GetComponent<ColorScript>();
        colorScript.activeColor = false;

        activeDate = true;

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

        obj = GameObject.Find("Color");
        colorScript = obj.GetComponent<ColorScript>();

        if (artistScript.activeArtist || colorScript.activeColor)
        {
            activeDate = false;
        }
    }
}