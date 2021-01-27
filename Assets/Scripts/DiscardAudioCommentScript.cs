using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscardAudioCommentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {

            GameObject record = GameObject.Find("RecordAudioComment");
            SingleMicrophoneCapture script = record.GetComponent<SingleMicrophoneCapture>();

            GameObject.Find("RecordAudioComment").GetComponent<Button>().transform.localScale = script.defaultDim;
            GameObject.Find("SendCommentCanvas").GetComponent<Canvas>().enabled = true;
            GameObject.Find("NewCommentCanvas").GetComponent<Canvas>().enabled = true;

            GameObject.Find("AudioCommentRecordedBackground").GetComponent<Canvas>().enabled = false;

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
