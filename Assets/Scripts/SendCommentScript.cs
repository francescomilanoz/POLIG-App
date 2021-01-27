using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendCommentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("CommentPosted").GetComponent<Image>().enabled = false;
        GameObject.Find("CommentPostedText").GetComponent<Text>().enabled = false;
        GameObject.Find("AudioCommentRecordedBackground").GetComponent<Canvas>().enabled = false;

        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () {

            InputField comment = GameObject.Find("InputComment").GetComponent<InputField>();
            InputField name = GameObject.Find("InputName").GetComponent<InputField>();
            Text commentText = GameObject.Find("InputCommentText").GetComponent<Text>();
            Text nameText = GameObject.Find("InputNameText").GetComponent<Text>();


            if (commentText.text.Length > 0 && nameText.text.Length > 0)
            {
                //Everything is correct! I save the comment in the ini (as last), and I show it

                GameObject obj = GameObject.Find("CommentsManager");
                LoadCommentsManager script = obj.GetComponent<LoadCommentsManager>();

                script.saveComment(nameText.text, commentText.text, "false");

                //GameObject.Find("InputComment").SetActive(false);
                //GameObject.Find("InputName").SetActive(false);
                //GameObject.Find("SendComment").SetActive(false);
                //GameObject.Find("RecordAudioComment").SetActive(false);
                GameObject.Find("SendCommentCanvas").GetComponent<Canvas>().enabled = false;
                GameObject.Find("NewCommentCanvas").GetComponent<Canvas>().enabled = false;
                GameObject.Find("RecordAudioCommentCanvas").GetComponent<Canvas>().enabled = false;

                GameObject.Find("CommentPosted").GetComponent<Image>().enabled = true;
                GameObject.Find("CommentPostedText").GetComponent<Text>().enabled = true;

            }
            else
            {
                //Something is missing!
                if(commentText.text.Length == 0 && nameText.text.Length > 0)
                {
                    StartCoroutine(shake(comment));

                } else if(commentText.text.Length > 0 && nameText.text.Length == 0)
                {
                    StartCoroutine(shake(name));
                }
                else if (commentText.text.Length == 0 && nameText.text.Length == 0)
                {
                    StartCoroutine(shake(name));
                    StartCoroutine(shake(comment));
                }
            }

        });
    }

    IEnumerator shake(InputField comment)
    {
        comment.transform.position = new Vector3(comment.transform.position.x + 8, comment.transform.position.y + 8, comment.transform.position.z + 8);
        yield return new WaitForSeconds(0.01f);
        comment.transform.position = new Vector3(comment.transform.position.x - 8, comment.transform.position.y - 8, comment.transform.position.z - 8);
        yield return new WaitForSeconds(0.01f);
        comment.transform.position = new Vector3(comment.transform.position.x + 8, comment.transform.position.y + 8, comment.transform.position.z + 8);
        yield return new WaitForSeconds(0.01f);
        comment.transform.position = new Vector3(comment.transform.position.x - 8, comment.transform.position.y - 8, comment.transform.position.z - 8);
        yield return new WaitForSeconds(0.01f);
        comment.transform.position = new Vector3(comment.transform.position.x + 8, comment.transform.position.y + 8, comment.transform.position.z + 8);
        yield return new WaitForSeconds(0.01f);
        comment.transform.position = new Vector3(comment.transform.position.x - 8, comment.transform.position.y - 8, comment.transform.position.z - 8);
        yield return new WaitForSeconds(0.01f);
        comment.transform.position = new Vector3(comment.transform.position.x, comment.transform.position.y, comment.transform.position.z);
        yield return new WaitForSeconds(0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        Text commentText = GameObject.Find("InputCommentText").GetComponent<Text>();
        Text nameText = GameObject.Find("InputNameText").GetComponent<Text>();
        InputField comment = GameObject.Find("InputComment").GetComponent<InputField>();
        InputField name = GameObject.Find("InputName").GetComponent<InputField>();


        Button b = gameObject.GetComponent<Button>();

        Debug.Log(commentText.text + " " + nameText.text);

    }
}
