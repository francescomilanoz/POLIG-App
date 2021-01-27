using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class PlayAudioCommentInBubbleScript : MonoBehaviour
{

    private AudioSource auSource;
    public AudioClip clip;

    public string whatAudioFile;

    [System.Obsolete]
    void Start()
    {



        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate ()
        {

        auSource = GetComponent<AudioSource>();

        string tempPath = Path.Combine(Application.persistentDataPath, whatAudioFile);
        Debug.Log(tempPath);
        
        StartCoroutine(loadAudio(tempPath));

        });
    }

    [System.Obsolete]
    IEnumerator loadAudio(string path)
    {
        path = "file://" + path;

        //Load Audio
        WWW audioLoader = new WWW(path);
        yield return audioLoader;

        //Convert it to AudioClip
        clip = audioLoader.GetAudioClip(false, false, AudioType.WAV);

            auSource.clip = clip;
            auSource.Play();
    }


}


