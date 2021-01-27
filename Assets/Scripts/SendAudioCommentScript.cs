using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendAudioCommentScript : MonoBehaviour
{

    //NON SERVE PUOI TOGLIERE!!!!

    bool recording;
    AudioClip myAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        recording = false;
        
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {
            if(!recording)
            {
                myAudioClip = Microphone.Start("Built-in Microphone", false, 4, 44100);
                if (myAudioClip == null)
                    Debug.Log("failed to start");
            }

            if(recording)
            {
                SavWav.Save("myfile", myAudioClip);

                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = myAudioClip;
                audio.Play();
                
            }

            recording = !recording;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
