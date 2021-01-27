using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCommentsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentCommentRead;

    public List<string> comments = new List<string>();

    public string artwork;

    public void readCommentsFromIni(string artwork)
    {
        INIParser ini = new INIParser();
        ini.Open(Application.persistentDataPath + "comments.txt");

        //Load every comment relative to the scanned artwork
        string tmpRead = "tmp";
        int count = 0;

        while (!tmpRead.Equals("null|null"))
        {
            tmpRead = ini.ReadValue(artwork, count + "", "null|null");
            if (!tmpRead.Equals("null|null"))
            {
                comments.Add(tmpRead);
            }
            count++;
        }

        ini.Close();

    }

    public void disableBubble(int num)
    {
        GameObject.Find("Comment" + num + "Name").GetComponent<Text>().enabled = false;
        GameObject.Find("Comment" + num + "Description").GetComponent<Text>().enabled = false;
        GameObject.Find("Comment" + num + "Background").GetComponent<Image>().enabled = false;
        GameObject.Find("Comment" + num + "Reload").GetComponent<Image>().enabled = false;
        Vector3 invisible = new Vector3(0, 0, 0);
        GameObject.Find("Comment" + num + "AudioComment").GetComponent<Button>().transform.localScale = invisible;

    }

    public void enableBubble(int num)
    {
        GameObject.Find("Comment" + num + "Name").GetComponent<Text>().enabled = true;
        GameObject.Find("Comment" + num + "Description").GetComponent<Text>().enabled = true;
        GameObject.Find("Comment" + num + "Background").GetComponent<Image>().enabled = true;
        GameObject.Find("Comment" + num + "Reload").GetComponent<Image>().enabled = true;
        Vector3 visible = new Vector3(1, 1, 1);
        GameObject.Find("Comment" + num + "AudioComment").GetComponent<Button>().transform.localScale = visible;
    }


    public void writeCommentsInBubbles(List<string> comments)
    {
        //I disable non-needed bubbles
        int toDisable = 0;
        if (comments.Count < 5)
            toDisable = 5 - comments.Count;

        for(int i = 0; i < toDisable; i++)
        {
            disableBubble(5 - i);
        }

        //I load from the most recent comment, and I put it in the bubble
        int howManyToLoad = 5;
        if (toDisable != 0)
            howManyToLoad = 5 - toDisable;

        currentCommentRead = comments.Count - 1; //I start reading from the last one
        for(int j = 0; j < howManyToLoad; j++)
        {
            string[] commentSplit = new string[3];
            commentSplit = comments[currentCommentRead].Split('|');

            if (commentSplit[2].Equals("false")) //Text comment
            {
                GameObject.Find("Comment" + (j + 1) + "Name").GetComponent<Text>().text = commentSplit[0];
                GameObject.Find("Comment" + (j + 1) + "Description").GetComponent<Text>().text = commentSplit[1];
                Vector3 invisible = new Vector3(0, 0, 0);
                GameObject.Find("Comment" + (j + 1) + "AudioComment").GetComponent<Button>().transform.localScale = invisible;

            } else //Audio comment
            {
                GameObject.Find("Comment" + (j + 1) + "Name").GetComponent<Text>().text = "";
                GameObject.Find("Comment" + (j + 1) + "Description").GetComponent<Text>().text = "";
                Vector3 visible = new Vector3(1, 1, 1);
                GameObject.Find("Comment" + (j + 1) + "AudioComment").GetComponent<Button>().transform.localScale = visible;
                GameObject.Find("Comment" + (j + 1) + "AudioComment").GetComponent<PlayAudioCommentInBubbleScript>().whatAudioFile = "audioComment" + (currentCommentRead + 1) + ".wav";

            }

            currentCommentRead--;
        }
    }

    public void loadNextComment(int toWhichBubble)
    {
        string[] commentSplit = new string[3];
        commentSplit = comments[currentCommentRead].Split('|');

        if (commentSplit[2].Equals("false")) //Text comment
        {
            GameObject.Find("Comment" + (toWhichBubble) + "Name").GetComponent<Text>().text = commentSplit[0];
            GameObject.Find("Comment" + (toWhichBubble) + "Description").GetComponent<Text>().text = commentSplit[1];
            Vector3 invisible = new Vector3(0, 0, 0);
            GameObject.Find("Comment" + (toWhichBubble) + "AudioComment").GetComponent<Button>().transform.localScale = invisible;
        }
        else //Audio comment
        {
            GameObject.Find("Comment" + (toWhichBubble) + "Name").GetComponent<Text>().text = "";
            GameObject.Find("Comment" + (toWhichBubble) + "Description").GetComponent<Text>().text = "";
            Vector3 visible = new Vector3(1, 1, 1);
            GameObject.Find("Comment" + (toWhichBubble) + "AudioComment").GetComponent<Button>().transform.localScale = visible;
            GameObject.Find("Comment" + (toWhichBubble) + "AudioComment").GetComponent<PlayAudioCommentInBubbleScript>().whatAudioFile = "audioComment" + (currentCommentRead + 1) + ".wav";
        }

        if (currentCommentRead != 0)
            currentCommentRead--;
        else
            currentCommentRead = comments.Count - 1;
    }


    public void saveComment(string name, string comment, string isAudio)
    {
        INIParser ini = new INIParser();
        ini.Open(Application.persistentDataPath + "comments.txt");

      
        ini.WriteValue(artwork, comments.Count + "", name+"|"+comment+"|" +isAudio);
        comments.Add(name + "|" + comment + "|" + isAudio); 
        
        ini.Close();

        //I also show this comment instead of one of the others (se erano 5 o più):  
        string[] commentSplit = new string[3];
        commentSplit = comments[comments.Count -1].Split('|');
        if(comments.Count >= 6)
        {
            if (commentSplit[2].Equals("false")) //Text comment
            {
                GameObject.Find("Comment" + 1 + "Name").GetComponent<Text>().text = commentSplit[0];
                GameObject.Find("Comment" + 1 + "Description").GetComponent<Text>().text = commentSplit[1];
                Vector3 invisible = new Vector3(0, 0, 0);
                GameObject.Find("Comment" + 1 + "AudioComment").GetComponent<Button>().transform.localScale = invisible;
            } else //Audio comment
            {
                GameObject.Find("Comment" + 1 + "Name").GetComponent<Text>().text = "";
                GameObject.Find("Comment" + 1 + "Description").GetComponent<Text>().text = "";
                Vector3 visible = new Vector3(1, 1, 1);
                GameObject.Find("Comment" + 1 + "AudioComment").GetComponent<Button>().transform.localScale = visible;
                GameObject.Find("Comment" + 1 + "AudioComment").GetComponent<PlayAudioCommentInBubbleScript>().whatAudioFile = "audioComment" + (comments.Count) + ".wav";
            }
        } 
        else
        {
            if (commentSplit[2].Equals("false")) //Text comment
            {
                //Genero il nuovo fumetto, e aggiungo il commento in quel fumetto lì
                enableBubble(comments.Count);
                GameObject.Find("Comment" + comments.Count + "Name").GetComponent<Text>().text = commentSplit[0];
                GameObject.Find("Comment" + comments.Count + "Description").GetComponent<Text>().text = commentSplit[1];
                Vector3 invisible = new Vector3(0, 0, 0);
                GameObject.Find("Comment" + comments.Count + "AudioComment").GetComponent<Button>().transform.localScale = invisible;
            }
            else //Audio comment
            {
                enableBubble(comments.Count);
                GameObject.Find("Comment" + comments.Count + "Name").GetComponent<Text>().text = "";
                GameObject.Find("Comment" + comments.Count + "Description").GetComponent<Text>().text = "";
                Vector3 visible = new Vector3(1, 1, 1);
                GameObject.Find("Comment" + comments.Count + "AudioComment").GetComponent<Button>().transform.localScale = visible;
                GameObject.Find("Comment" + comments.Count + "AudioComment").GetComponent<PlayAudioCommentInBubbleScript>().whatAudioFile = "audioComment" + (comments.Count) + ".wav";
            }
        }


       
    }

    public bool todo;

    void Start()
    {

        todo = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(todo)
        {
            GameObject obj = GameObject.Find("AR Session Origin");
            ScanImages scanImages = obj.GetComponent<ScanImages>();
            artwork = scanImages.whatIsTracking;
            //string tracking = scanImages.whatIsTracking;
            Debug.Log("SCANSIONANDO: " + artwork);
            //Debug.Log("WHAT IS TRACKING: " + tracking);

            comments.Clear();

            for(int i = 1; i < 6; i++)
            {
                enableBubble(i);
            }

            //Load every comment relative to the scanned artwork
            readCommentsFromIni(artwork);

            //Now, I read one comment at time and assign it in order. I keep in memory how many comments I read
            writeCommentsInBubbles(comments);

            todo = false;
        }


    }
}
