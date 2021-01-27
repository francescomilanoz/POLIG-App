using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioCommentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {

            GameObject record = GameObject.Find("RecordAudioComment");
            SingleMicrophoneCapture script = record.GetComponent<SingleMicrophoneCapture>();

            script.goAudioSource.Play();

        });

    }
        

    // Update is called once per frame
        void Update()
    {
        
    }
}
