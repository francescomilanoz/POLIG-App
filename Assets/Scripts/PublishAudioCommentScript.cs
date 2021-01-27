using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PublishAudioCommentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {

            GameObject record = GameObject.Find("RecordAudioComment");
            SingleMicrophoneCapture script = record.GetComponent<SingleMicrophoneCapture>();

            GameObject commentManager = GameObject.Find("CommentsManager");
            LoadCommentsManager saveCommentScript = commentManager.GetComponent<LoadCommentsManager>();

            saveCommentScript.saveComment("", "", "true");

            SaveLoadWav save = new SaveLoadWav();

            save.Save("audioComment"+saveCommentScript.comments.Count, script.recordedClip);



            GameObject.Find("CommentPosted").GetComponent<Image>().enabled = true;
            GameObject.Find("CommentPostedText").GetComponent<Text>().enabled = true;


            GameObject.Find("AudioCommentRecordedBackground").GetComponent<Canvas>().enabled = false;

            

        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
