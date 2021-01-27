using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SculptureScript : MonoBehaviour
{
    public bool activeSculpture = false;
    GameObject obj;
    PaintingScript paintingScript;
    OtherScript otherScript;

    // Start is called before the first frame update
    void Start()
    {
        //Button not selected at start
        activeSculpture = false;

        gameObject.GetComponent<Button>().onClick.AddListener(changeStatus);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activeSculpture = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activeSculpture = false;
    }

    private void changeStatus()
    {
        //if click on this button -> set false the others
        obj = GameObject.Find("Painting");
        paintingScript = obj.GetComponent<PaintingScript>();
        paintingScript.activePainting = false;

        obj = GameObject.Find("Other");
        otherScript = obj.GetComponent<OtherScript>();
        otherScript.activeOther = false;

        activeSculpture = true;

        //Update Recycler View list
        GameObject roomListObj = GameObject.Find("ArtworksList");
        ArtworksList roomList = roomListObj.GetComponent<ArtworksList>();
        roomList.NotifyDatasetChanged();

    }

    // Update is called once per frame
    void Update()
    {
    }
}