using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomReachedNotification : MonoBehaviour
{

    public int wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = 60;
        GameObject.Find("RoomReachedNotification").GetComponent<Image>().enabled = false;
        GameObject.Find("RoomReachedText").GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        Image notification = GameObject.Find("RoomReachedNotification").GetComponent<Image>();
        Text notificationText = GameObject.Find("RoomReachedText").GetComponent<Text>();

        if (notification.enabled == true)
        {


            if (wait > 0)
                wait--;

            if (wait == 0)
            {
                Color color = notification.color;
                color.a -= 0.01f;
                notification.color = color;

                Color color2 = notificationText.color;
                color2.a -= 0.01f;
                notificationText.color = color2;

                if(color.a <= 0.01)
                {

                    //Reset for the next time
                    wait = 60;

                    Color maxColor = notification.color;
                    maxColor.a = 1f;
                    notification.color = maxColor;

                    Color maxColor2 = notificationText.color;
                    maxColor2.a = 1f;
                    notificationText.color = maxColor2;

                    notificationText.enabled = false;
                    notification.enabled = false;
                    
                }


            }
        }
    }
}
