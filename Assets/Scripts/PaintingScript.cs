using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaintingScript : MonoBehaviour
{
    public bool activePainting = true;
    GameObject obj;
    SculptureScript sculptureScript;
    OtherScript otherScript;

    // Start is called before the first frame update
    void Start()
    {
        //Button selected at start
        activePainting = true;
        gameObject.GetComponent<Button>().onClick.AddListener(changeStatus);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activePainting = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activePainting = false;
    }

    private void changeStatus()
    {
        //if click on this button -> set false the others
        obj = GameObject.Find("Sculpture");
        sculptureScript = obj.GetComponent<SculptureScript>();
        sculptureScript.activeSculpture = false;

        obj = GameObject.Find("Other");
        otherScript = obj.GetComponent<OtherScript>();
        otherScript.activeOther = false;

        activePainting = true;

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
