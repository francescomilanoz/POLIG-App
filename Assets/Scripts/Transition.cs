using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public float sec = 5f;
    void Start()
    {

        StartCoroutine(FadeImage());
        
        if (!gameObject.activeInHierarchy)
            gameObject.SetActive(true);

        StartCoroutine(LateCall());

    }

    IEnumerator FadeImage()
    {   
        // fade from transparent to opaque
        // loop over 1 second
        for (float i = 0; i <= 10; i += Time.deltaTime)
        {
            // set color with i as alpha
            GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return null;
        }
        
    }


    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);

        gameObject.GetComponent<Image>().enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
