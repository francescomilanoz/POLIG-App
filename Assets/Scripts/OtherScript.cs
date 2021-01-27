using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OtherScript : MonoBehaviour
{
    public bool activeOther = false;
    GameObject obj;
    SculptureScript sculptureScript;
    PaintingScript paintingScript;

    // Start is called before the first frame update
    void Start()
    {
        //Button not selected at start
        activeOther = false;
        gameObject.GetComponent<Button>().onClick.AddListener(changeStatus);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activeOther = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activeOther = false;
    }

    private void changeStatus()
    {
        //if click on this button -> set false the others
        obj = GameObject.Find("Sculpture");
        sculptureScript = obj.GetComponent<SculptureScript>();
        sculptureScript.activeSculpture = false;

        obj = GameObject.Find("Painting");
        paintingScript = obj.GetComponent<PaintingScript>();
        paintingScript.activePainting = false;

        activeOther = true;

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
