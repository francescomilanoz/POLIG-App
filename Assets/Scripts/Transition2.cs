using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class Transition2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                    
    }


    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Logo").activeInHierarchy)
        {
            GetComponent<Button>().enabled = true;
        }

    }
}
