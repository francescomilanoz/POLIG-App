using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseReachARoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(closeUI);
    }


    private void closeUI()
    {
        Debug.Log("Eseguitoooo");
        GameObject.Find("NavigationUI").GetComponent<Canvas>().enabled = true;
        GameObject.Find("ReachARoomUI").GetComponent<Canvas>().enabled = false;
        GameObject.Find("ReachAnArtworkUI").GetComponent<Canvas>().enabled = false;


    }


        // Update is called once per frame
        void Update()
    {
        
    }
}
