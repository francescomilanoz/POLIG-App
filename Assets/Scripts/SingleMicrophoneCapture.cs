using UnityEngine; 
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]






public class SingleMicrophoneCapture : MonoBehaviour
{
	
	public int anim = 1;
	public Vector3 defaultDim;
	public AudioClip recordedClip;


	//A boolean that flags whether there's a connected microphone
	private bool micConnected = false;

	//The maximum and minimum available recording frequencies
	private int minFreq;
	private int maxFreq;

	//A handle to the attached AudioSource
	public AudioSource goAudioSource;

	//Use this for initialization
	void Start()
	{
		//Check if there is at least one microphone connected
		if (Microphone.devices.Length <= 0)
		{
			//Throw a warning message at the console if there isn't
			Debug.LogWarning("Microphone not connected!");
		}
		else //At least one microphone is present
		{
			//Set 'micConnected' to true
			micConnected = true;

			//Get the default microphone recording capabilities
			Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

			//According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...
			if (minFreq == 0 && maxFreq == 0)
			{
				//...meaning 44100 Hz can be used as the recording sampling rate
				maxFreq = 44100;
			}

			//Get the attached AudioSource component
			goAudioSource = this.GetComponent<AudioSource>();
		}



		Button b = gameObject.GetComponent<Button>();
		defaultDim = b.transform.localScale;
		b.onClick.AddListener(delegate ()
		{

			

			if (micConnected)
            {


				if (!Microphone.IsRecording(null))
				{

					//Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource
					goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);


				}
				else //Recording is in progress
				{


					Microphone.End(null); //Stop the audio recording
					//goAudioSource.Play(); //Playback the recorded audio

					b.transform.localScale = defaultDim;

					recordedClip = goAudioSource.clip;
					anim = 1;


					GameObject.Find("SendCommentCanvas").GetComponent<Canvas>().enabled = false;
					GameObject.Find("NewCommentCanvas").GetComponent<Canvas>().enabled = false;
				


					Vector3 hideRecordButton = new Vector3(0, 0, 0);
					b.transform.localScale = hideRecordButton;
					GameObject.Find("AudioCommentRecordedBackground").GetComponent<Canvas>().enabled = true;



					//SavWav.Save("myfile", recordedClip);

				}



				}



		});



	}


	public void DiscardRecordedAudio()
    {

    }


    private void Update()
    {
		if(Microphone.IsRecording(null))
        {
			if(anim < 30)
            {
				Button b = gameObject.GetComponent<Button>();
				Vector3 dim = b.transform.localScale;
				dim.x += 0.01f;
				dim.y += 0.01f;

				b.transform.localScale = dim;

				anim++;
            } else if(anim < 59)
            {
				Button b = gameObject.GetComponent<Button>();
				Vector3 dim = b.transform.localScale;
				dim.x -= 0.01f;
				dim.y -= 0.01f;

				b.transform.localScale = dim;

				anim++;
			} else if(anim == 59)
            {
				anim = 1;
            }
        }

	}
}
