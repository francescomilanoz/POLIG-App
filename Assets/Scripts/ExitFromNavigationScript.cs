using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitFromNavigationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

       

        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {

            GameObject navigationStatusKeeper = GameObject.Find("NavigationStatusKeeper");
            NavigationStatusKeeper navScript = navigationStatusKeeper.GetComponent<NavigationStatusKeeper>();
            navScript.targetRoomName = "None";

            Debug.Log(navScript.targetRoomName);
        });

        // Update is called once per frame
        void Update()
        {

        }
    }

}
