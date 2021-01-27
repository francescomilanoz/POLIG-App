using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentPostedNotification : MonoBehaviour
{

    public int wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
        Image notification = GameObject.Find("CommentPosted").GetComponent<Image>();
        Text notificationText = GameObject.Find("CommentPostedText").GetComponent<Text>();

        if (notification.enabled == true)
        {

          
            if(wait > 0)
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
                    Vector3 showRecordButton = new Vector3(1, 1, 1);
                    Button b = GameObject.Find("RecordAudioComment").GetComponent<Button>();
                    b.transform.localScale = showRecordButton;
                    GameObject.Find("SendCommentCanvas").GetComponent<Canvas>().enabled = true;
                    GameObject.Find("NewCommentCanvas").GetComponent<Canvas>().enabled = true;
                    GameObject.Find("RecordAudioCommentCanvas").GetComponent<Canvas>().enabled = true;

                    InputField commentText = GameObject.Find("InputComment").GetComponent<InputField>();
                    InputField nameText = GameObject.Find("InputName").GetComponent<InputField>();
                    commentText.text = "";
                    nameText.text = "";


                    Color colorMax = notification.color;
                    colorMax.a = 1f;
                    notification.color = colorMax;

                    Color color2Max = notificationText.color;
                    color2Max.a = 1f;
                    notificationText.color = color2Max;

                    wait = 60;

                    notificationText.enabled = false;
                    notification.enabled = false;
                    
                }
            }
        }
    }
}

