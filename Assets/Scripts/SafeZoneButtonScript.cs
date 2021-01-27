using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeZoneButtonScript : MonoBehaviour
{
    public bool active;

    Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        active = false;

        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () {

            active = !active;

            if (active)
            {
                sprite = Resources.Load<Sprite>("Images/Group 215");
                GetComponent<Image>().sprite = sprite;
            }
            else
            {
                sprite = Resources.Load<Sprite>("Images/Group 216");
                GetComponent<Image>().sprite = sprite;
            }

        });

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
