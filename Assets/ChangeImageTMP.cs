using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageTMP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sprite texture = Resources.Load<Sprite>("WaitInLineImages/dali");
        gameObject.GetComponent<Image>().sprite = texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
