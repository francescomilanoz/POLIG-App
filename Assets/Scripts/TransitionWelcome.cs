using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionWelcome : MonoBehaviour
{
    public bool yetDone;
    public float sec = 5f;
    // Start is called before the first frame update
    void Start()
    {
        yetDone = false;
    }
    IEnumerator FadeImage()
    {
        // fade from transparent to opaque
        // loop over 1 second
        for (float i = 0; i <= 10; i += Time.deltaTime)
        {
            // set color with i as alpha
            GetComponent<Text>().color = new Color(1, 1, 1, i);
            yield return null;
        }

    }


    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);



        if (!yetDone)
        {

            yetDone = true;


            INIParser skipTutorial = new INIParser();
            skipTutorial.Open(Application.persistentDataPath + "firstTime.txt");

            string isFirstTime = skipTutorial.ReadValue("FirstTime", "first", "false");

            if (isFirstTime.Equals("false"))
            {
                skipTutorial.WriteValue("FirstTime", "first", "true");
                skipTutorial.Close();
            }
            else
            {
                skipTutorial.Close();
                gameObject.GetComponent<Text>().enabled = false;
                GameObject.Find("Welcome").GetComponent<Canvas>().enabled = false;
                SceneManager.LoadScene("01waitinline");
            }
        }


        gameObject.GetComponent<Text>().enabled = false;
        GameObject.Find("Welcome").GetComponent<Canvas>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Logo").GetComponent<Image>().enabled)
        {
            StartCoroutine(FadeImage());

            if (!gameObject.activeInHierarchy)
                gameObject.SetActive(true);

            StartCoroutine(LateCall());
        }
    }
}
