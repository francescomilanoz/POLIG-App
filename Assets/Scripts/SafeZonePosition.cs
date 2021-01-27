using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZonePosition : MonoBehaviour { 

    // Start is called before the first frame update
    void Start() {  
        
        GameObject arCameraObject = GameObject.Find("AR Camera").GetComponent<GameObject>();
        Vector3 v3;
        v3.x = arCameraObject.transform.position.x + 50;
        v3.y = arCameraObject.transform.position.y + 50;
        v3.z = arCameraObject.transform.position.z - 50;
        Quaternion q = GetComponent<GameObject>().transform.rotation;
        
        GetComponent<GameObject>().transform.SetPositionAndRotation(v3, q);
}
      
      

    // Update is called once per frame
    void Update()
    {
        
    }
}
