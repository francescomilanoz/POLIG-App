using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SafeZoneManagerScript: MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public GameObject safeZonePrefab;
    public GameObject safeZone;

    private void Start()
    {
        safeZone.SetActive(false);
        safeZonePrefab.SetActive(false);
    }

    void Update()
    {

        GameObject safeZoneButton = GameObject.Find("SafeZoneButton");
        SafeZoneButtonScript script = safeZoneButton.GetComponent<SafeZoneButtonScript>();

            Vector3 v3 = new Vector3(Camera.current.transform.position.x, (float)(-3), Camera.current.transform.position.z);
            if (safeZone == null)
                safeZone = Instantiate(safeZonePrefab, v3, Quaternion.identity);
            
        
        if (script.active)
            {
            safeZone.SetActive(true);
            safeZonePrefab.SetActive(true);
                safeZonePrefab.transform.SetPositionAndRotation(v3, Quaternion.identity);
                safeZone.transform.SetPositionAndRotation(v3, Quaternion.identity);
            } else if (!script.active)
        {
            safeZone.SetActive(false);
            safeZonePrefab.SetActive(false);
        }

    }
}
