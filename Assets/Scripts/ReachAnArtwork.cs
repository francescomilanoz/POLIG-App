using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReachAnArtwork : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("ReachAnArtworkUI").GetComponent<Canvas>().enabled = false;
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () {

            //If I click the button I need to enable the "ReachAnArtworkUI" but disable the "NavigationUI"
            GameObject.Find("ReachAnArtworkUI").GetComponent<Canvas>().enabled = true;

            //Set Painting button as active
            GameObject obj1 = GameObject.Find("Painting");
            PaintingScript paintingScript = obj1.GetComponent<PaintingScript>();
            paintingScript.GetComponent<Button>().Select();
            paintingScript.activePainting = true;

            //Set Sculpture button as no active
            GameObject obj2 = GameObject.Find("Sculpture");
            SculptureScript sculptureScript = obj2.GetComponent<SculptureScript>();
            sculptureScript.activeSculpture = false;

            //Set Other button as no active
            GameObject obj3 = GameObject.Find("Other");
            OtherScript otherScript = obj3.GetComponent<OtherScript>();
            otherScript.activeOther = false;

            //update data
            GameObject artworksListObj = GameObject.Find("ArtworksList");
            ArtworksList artworksList = artworksListObj.GetComponent<ArtworksList>();
            artworksList.NotifyDatasetChanged();

            GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = false;

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
