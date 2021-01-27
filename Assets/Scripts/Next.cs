using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject howUse;
    public GameObject safeZone;
    public GameObject bottonBar;

    public GameObject roomBar;
    public GameObject qrCode;

    public GameObject artwork;

    public GameObject wait;
    public GameObject waitingUI;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        Button b = GetComponent<Button>();
        b.onClick.AddListener(obscure);

    }

    private void obscure()
    {
        if(count >= 0 && count <= 5)
        {
            if (count == 0)
            {
                tutorial.GetComponent<Canvas>().enabled = false;
                howUse.GetComponent<Canvas>().enabled = false;
                safeZone.GetComponent<Canvas>().enabled = true;
                bottonBar.GetComponent<Canvas>().enabled = true;
            }


            if (count == 1)
            {
                safeZone.GetComponent<Canvas>().enabled = false;
                bottonBar.GetComponent<Canvas>().enabled = false;

                qrCode.GetComponent<Canvas>().enabled = true;

            }

            if (count == 2)
            {
                qrCode.GetComponent<Canvas>().enabled = false;

                roomBar.GetComponent<Canvas>().enabled = true;
                GameObject.Find("Arrow").GetComponent<Canvas>().enabled = true;

            }

            if (count == 3)
            {
                roomBar.GetComponent<Canvas>().enabled = false;
                GameObject.Find("Arrow").GetComponent<Canvas>().enabled = false;

                artwork.GetComponent<Canvas>().enabled = true;

            }

            if (count == 4)
            {
                artwork.GetComponent<Canvas>().enabled = false;

                wait.GetComponent<Canvas>().enabled = true;
                waitingUI.GetComponent<Canvas>().enabled = true;

            }

            if (count == 5)
            {
                SceneManager.LoadScene("01waitinline");
            }

            count++;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
