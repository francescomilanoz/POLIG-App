using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVideo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        //GameObject.Find("AttachedVideo").GetComponent<GameObject>().SetActive(false);
        // GameObject.Find("Video").GetComponent<GameObject>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {  
        

        /*
        GameObject vars = GameObject.Find("PublicVariables");
        PublicVariablesScript script = vars.GetComponent<PublicVariablesScript>();

        if (script.artworkScanned)
        {
        //    GameObject.Find("AttachedVideo").GetComponent<GameObject>().SetActive(true);
        }
        else
        {

            GameObject self = gameObject.GetComponent<GameObject>();
            Destroy(self);
        }

       
        if(script.scanResult.Equals("video"))
        {
            GameObject.Find("Video").GetComponent<Renderer>().enabled = true;
            GameObject.Find("Arrow").GetComponent<Renderer>().enabled = false;
        }
        else if (script.scanResult.Equals("null"))
        {
            GameObject.Find("Arrow").GetComponent<Renderer>().enabled = false;
            GameObject.Find("Video").GetComponent<Renderer>().enabled = false;
        }
        */


        
    }
}
