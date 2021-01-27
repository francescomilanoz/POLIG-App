using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    GameObject obj;
    Next nextScript;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Next");
        nextScript = obj.GetComponent<Next>();

        GetComponent<Button>().onClick.AddListener(back);

    }

    private void back()
    {
        
        if(0 < nextScript.count && nextScript.count <= 5)
        {
            if (nextScript.count == 1)
            {
                GameObject.Find("SafeZone").GetComponent<Canvas>().enabled = false;
                GameObject.Find("BottomBar").GetComponent<Canvas>().enabled = false;

                GameObject.Find("Tutorial").GetComponent<Canvas>().enabled = true;
                GameObject.Find("HowUse").GetComponent<Canvas>().enabled = true;
            }
            if (nextScript.count == 2)
            {
                GameObject.Find("SafeZone").GetComponent<Canvas>().enabled = true;
                GameObject.Find("BottomBar").GetComponent<Canvas>().enabled = true;

                GameObject.Find("QRCode").GetComponent<Canvas>().enabled = false;
            }
            if (nextScript.count == 3)
            {
                GameObject.Find("QRCode").GetComponent<Canvas>().enabled = true;

                GameObject.Find("roombar").GetComponent<Canvas>().enabled = false;
                GameObject.Find("Arrow").GetComponent<Canvas>().enabled = false;
            }
            if (nextScript.count == 4)
            {
                GameObject.Find("roombar").GetComponent<Canvas>().enabled = true;
                GameObject.Find("Arrow").GetComponent<Canvas>().enabled = true;

                GameObject.Find("Artwork").GetComponent<Canvas>().enabled = false;
            }
            if (nextScript.count == 5)
            {
                GameObject.Find("Artwork").GetComponent<Canvas>().enabled = true;

                GameObject.Find("Wait").GetComponent<Canvas>().enabled = false;
                GameObject.Find("WaitingUI").GetComponent<Canvas>().enabled = false;
            }
            nextScript.count--;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
