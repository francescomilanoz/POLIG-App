using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtworkCommentManager : MonoBehaviour
{

    //comment 1 vars: 
    public Text Comment1Name;
    public Text Comment1Decription;
    public Image Comment1Background;
    public Image Comment1Reload;
    public Button Comment1AudioComment;
    Vector3 Comment1BackgroundPosition;
    Vector3 Comment1DecriptionPosition;
    Vector3 Comment1NamePosition;
    Vector3 Comment1ReloadPosition;
    Vector3 Comment1AudioCommentPosition;

    //comment 2 vars: 
    public Text Comment2Name;
    public Text Comment2Decription;
    public Image Comment2Background;
    public Image Comment2Reload;
    public Button Comment2AudioComment;
    Vector3 Comment2BackgroundPosition;
    Vector3 Comment2DecriptionPosition;
    Vector3 Comment2NamePosition;
    Vector3 Comment2ReloadPosition;
    Vector3 Comment2AudioCommentPosition;


    //comment 3 vars: 
    public Text Comment3Name;
    public Text Comment3Decription;
    public Image Comment3Background;
    public Image Comment3Reload;
    public Button Comment3AudioComment;
    Vector3 Comment3BackgroundPosition;
    Vector3 Comment3DecriptionPosition;
    Vector3 Comment3NamePosition;
    Vector3 Comment3ReloadPosition;
    Vector3 Comment3AudioCommentPosition;


    //comment 4 vars: 
    public Text Comment4Name;
    public Text Comment4Decription;
    public Image Comment4Background;
    public Image Comment4Reload;
    public Button Comment4AudioComment;
    Vector3 Comment4BackgroundPosition;
    Vector3 Comment4DecriptionPosition;
    Vector3 Comment4NamePosition;
    Vector3 Comment4ReloadPosition;
    Vector3 Comment4AudioCommentPosition;


    //comment 5 vars: 
    public Text Comment5Name;
    public Text Comment5Decription;
    public Image Comment5Background;
    public Image Comment5Reload;
    public Button Comment5AudioComment;
    Vector3 Comment5BackgroundPosition;
    Vector3 Comment5DecriptionPosition;
    Vector3 Comment5NamePosition;
    Vector3 Comment5ReloadPosition;
    Vector3 Comment5AudioCommentPosition;

    int time = 5;

    // Update is called once per frame
    void Update()
    {
        time++;

        if (time > 4)
        {
            time = 0;

            //Comment 1 position
            Comment1BackgroundPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            Comment1DecriptionPosition = Comment1BackgroundPosition;
            Comment1DecriptionPosition.y -= 10;
            Comment1NamePosition = Comment1BackgroundPosition;
            Comment1NamePosition.y += 78;
            Comment1NamePosition.x -= 25;
            Comment1ReloadPosition = Comment1BackgroundPosition;
            Comment1ReloadPosition.y += 85;
            Comment1ReloadPosition.x += 155;
            Comment1AudioCommentPosition = Comment1DecriptionPosition;
            Comment1AudioCommentPosition.y += 30;

            //Comment 2 position
            Comment2BackgroundPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            Comment2BackgroundPosition.x += 150;
            Comment2BackgroundPosition.y += 250;
            Comment2DecriptionPosition = Comment2BackgroundPosition;
            Comment2DecriptionPosition.y -= 10;
            Comment2NamePosition = Comment2BackgroundPosition;
            Comment2NamePosition.y += 78;
            Comment2NamePosition.x -= 25;
            Comment2ReloadPosition = Comment2BackgroundPosition;
            Comment2ReloadPosition.y += 85;
            Comment2ReloadPosition.x += 155;
            Comment2AudioCommentPosition = Comment2DecriptionPosition;
            Comment2AudioCommentPosition.y += 30;


            //Comment 3 position
            Comment3BackgroundPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            Comment3BackgroundPosition.x -= 230;
            Comment3BackgroundPosition.y -= 300;
            Comment3DecriptionPosition = Comment3BackgroundPosition;
            Comment3DecriptionPosition.y -= 35;
            Comment3NamePosition = Comment3BackgroundPosition;
            Comment3NamePosition.y += 70;
            Comment3NamePosition.x -= 25;
            Comment3ReloadPosition = Comment3BackgroundPosition;
            Comment3ReloadPosition.y += 70;
            Comment3ReloadPosition.x += 125;
            Comment3AudioCommentPosition = Comment3DecriptionPosition;
            Comment3AudioCommentPosition.y += 30;

            //Comment 4 position
            Comment4BackgroundPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            Comment4BackgroundPosition.x += 250;
            Comment4BackgroundPosition.y -= 400;
            Comment4DecriptionPosition = Comment4BackgroundPosition;
            Comment4DecriptionPosition.y -= 10;
            Comment4DecriptionPosition.x += 20;
            Comment4NamePosition = Comment4BackgroundPosition;
            Comment4NamePosition.y += 80;
            Comment4NamePosition.x -= 5;
            Comment4ReloadPosition = Comment4BackgroundPosition;
            Comment4ReloadPosition.y += 85;
            Comment4ReloadPosition.x += 155;
            Comment4AudioCommentPosition = Comment4DecriptionPosition;


            //Comment 5position
            Comment5BackgroundPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            Comment5BackgroundPosition.x -= 280;
            Comment5BackgroundPosition.y += 330;
            Comment5DecriptionPosition = Comment5BackgroundPosition;
            Comment5DecriptionPosition.y -= 55;
            Comment5NamePosition = Comment5BackgroundPosition;
            Comment5NamePosition.y += 38;
            Comment5NamePosition.x -= 25;
            Comment5ReloadPosition = Comment5BackgroundPosition;
            Comment5ReloadPosition.y += 45;
            Comment5ReloadPosition.x += 155;
            Comment5AudioCommentPosition = Comment5DecriptionPosition;
            Comment5AudioCommentPosition.y += 30;


            if (Comment1Background.transform.position.x - Comment1BackgroundPosition.x > 20 || Comment1Background.transform.position.x - Comment1BackgroundPosition.x < -20 || Comment1Background.transform.position.y - Comment1BackgroundPosition.y > 20 || Comment1Background.transform.position.y - Comment1BackgroundPosition.y < -20 || Comment1Background.transform.position.z - Comment1BackgroundPosition.z > 20 || Comment1Background.transform.position.z - Comment1BackgroundPosition.z < -20)
            {

                //Comment 1 set position
                Comment1Decription.transform.position = Comment1DecriptionPosition;
                Comment1Name.transform.position = Comment1NamePosition;
                Comment1Background.transform.position = Comment1BackgroundPosition;
                Comment1Reload.transform.position = Comment1ReloadPosition;
                Comment1AudioComment.transform.position = Comment1AudioCommentPosition;

                //Comment 2 set position
                Comment2Decription.transform.position = Comment2DecriptionPosition;
                Comment2Name.transform.position = Comment2NamePosition;
                Comment2Background.transform.position = Comment2BackgroundPosition;
                Comment2Reload.transform.position = Comment2ReloadPosition;
                Comment2AudioComment.transform.position = Comment2AudioCommentPosition;

                //Comment 3 set position
                Comment3Decription.transform.position = Comment3DecriptionPosition;
                Comment3Name.transform.position = Comment3NamePosition;
                Comment3Background.transform.position = Comment3BackgroundPosition;
                Comment3Reload.transform.position = Comment3ReloadPosition;
                Comment3AudioComment.transform.position = Comment3AudioCommentPosition;

                //Comment 4 set position
                Comment4Decription.transform.position = Comment4DecriptionPosition;
                Comment4Name.transform.position = Comment4NamePosition;
                Comment4Background.transform.position = Comment4BackgroundPosition;
                Comment4Reload.transform.position = Comment4ReloadPosition;
                Comment4AudioComment.transform.position = Comment4AudioCommentPosition;

                //Comment 5 set position
                Comment5Decription.transform.position = Comment5DecriptionPosition;
                Comment5Name.transform.position = Comment5NamePosition;
                Comment5Background.transform.position = Comment5BackgroundPosition;
                Comment5Reload.transform.position = Comment5ReloadPosition;
                Comment5AudioComment.transform.position = Comment5AudioCommentPosition;
            }
        }



    }
}
