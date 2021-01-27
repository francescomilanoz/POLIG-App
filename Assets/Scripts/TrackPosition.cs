using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPosition : MonoBehaviour
{
    GameObject cilindro;
    // Start is called before the first frame update
    void Start()
    {
        cilindro = GameObject.Find("AR Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cilindro.transform.position);
    }
}
