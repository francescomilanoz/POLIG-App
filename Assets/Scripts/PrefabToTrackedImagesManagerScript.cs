using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PrefabToTrackedImagesManagerScript : MonoBehaviour
{

    public int doorDegree = 0;
    string artTracked = "None";
    string waitingTracked = "None";

    [SerializeField]
    [Tooltip("Image manager on the AR Session Origin")]
    ARTrackedImageManager m_ImageManager;

    /// <summary>
    /// Get the <c>ARTrackedImageManager</c>
    /// </summary>
    public ARTrackedImageManager ImageManager
    {
        get => m_ImageManager;
        set => m_ImageManager = value;
    }

    [SerializeField]
    [Tooltip("Reference Image Library")]
    XRReferenceImageLibrary m_ImageLibrary;

    /// <summary>
    /// Get the <c>XRReferenceImageLibrary</c>
    /// </summary>
    public XRReferenceImageLibrary ImageLibrary
    {
        get => m_ImageLibrary;
        set => m_ImageLibrary = value;
    }

    [SerializeField]
    [Tooltip("Prefab for tracked 1 image")]
    public GameObject m_OnePrefab;

    /// <summary>
    /// Get the one prefab
    /// </summary>
    public GameObject onePrefab
    {
        get => m_OnePrefab;
        set => m_OnePrefab = value;
    }

    public GameObject m_SpawnedOnePrefab;

    /// <summary>
    /// get the spawned one prefab
    /// </summary>
    public GameObject spawnedOnePrefab
    {
        get => m_SpawnedOnePrefab;
        set => m_SpawnedOnePrefab = value;
    }

    [SerializeField]
    [Tooltip("Prefab for tracked 2 image")]
    public GameObject m_TwoPrefab;

    /// <summary>
    /// get the two prefab
    /// </summary>
    public GameObject twoPrefab
    {
        get => m_TwoPrefab;
        set => m_TwoPrefab = value;
    }

    public GameObject m_SpawnedTwoPrefab;

    /// <summary>
    /// get the spawned two prefab
    /// </summary>
    public GameObject spawnedTwoPrefab
    {
        get => m_SpawnedTwoPrefab;
        set => m_SpawnedTwoPrefab = value;
    }


    [SerializeField]
    [Tooltip("Prefab for tracked 3 image")]
    public GameObject m_ThreePrefab;

    /// <summary>
    /// get the three prefab
    /// </summary>
    public GameObject threePrefab
    {
        get => m_ThreePrefab;
        set => m_ThreePrefab = value;
    }

    public GameObject m_SpawnedThreePrefab;

    /// <summary>
    /// get the spawned three prefab
    /// </summary>
    public GameObject spawnedThreePrefab
    {
        get => m_SpawnedThreePrefab;
        set => m_SpawnedThreePrefab = value;
    }



    [SerializeField]
    [Tooltip("Prefab for tracked 4 image")]
    public GameObject m_FourPrefab;

    /// <summary>
    /// get the four prefab
    /// </summary>
    public GameObject fourPrefab
    {
        get => m_FourPrefab;
        set => m_FourPrefab = value;
    }

    public GameObject m_SpawnedFourPrefab;

    /// <summary>
    /// get the spawned four prefab
    /// </summary>
    public GameObject spawnedFourPrefab
    {
        get => m_SpawnedFourPrefab;
        set => m_SpawnedFourPrefab = value;
    }




    int m_NumberOfTrackedImages;

    //GameObject m_OneNumberManager;
    //GameObject m_TwoNumberManager;

    void OnEnable()
    {
        m_ImageManager.trackedImagesChanged += ImageManagerOnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_ImageManager.trackedImagesChanged -= ImageManagerOnTrackedImagesChanged;
    }

    void ImageManagerOnTrackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
    {


        // added, spawn prefab
        foreach (ARTrackedImage image in obj.added)
        {

            Debug.Log("ADDED: " + image.referenceImage.name);

            if (image.referenceImage.name.Contains("A"))
            {
                if (m_SpawnedOnePrefab == null)
                    m_SpawnedOnePrefab = Instantiate(m_OnePrefab, image.transform.position, image.transform.rotation);
                m_SpawnedOnePrefab.SetActive(false);

                if (m_SpawnedThreePrefab == null)
                    m_SpawnedThreePrefab = Instantiate(m_ThreePrefab, image.transform.position, image.transform.rotation);
                m_SpawnedThreePrefab.SetActive(false);
            }
            else if (image.referenceImage.name.Contains("r"))
            {
                Debug.Log("INSTANTIATED");
                if(m_SpawnedTwoPrefab == null)
                    m_SpawnedTwoPrefab = Instantiate(m_TwoPrefab, image.transform.position, image.transform.rotation * Quaternion.Euler(Vector3.up * doorDegree));
                m_SpawnedTwoPrefab.SetActive(false);
            }
            else if(image.referenceImage.name.Contains("L"))
            {
                if (m_SpawnedFourPrefab == null)
                    m_SpawnedFourPrefab = Instantiate(m_FourPrefab, image.transform.position, image.transform.rotation);
                m_SpawnedFourPrefab.SetActive(true);
            }
        }

        bool atLeastOneQRTracked = false;
        bool atLeastOneWaitingTracked = false;

        // updated, set prefab position and rotation
        foreach (ARTrackedImage image in obj.updated)
        {

           

            // image is tracking or tracking with limited state, show visuals and update it's position and rotation
            if (image.trackingState == TrackingState.Tracking)
            { 
                
                //Debug.Log("UPDATED (tracking): " + image.referenceImage.name);


                if (image.referenceImage.name.Contains("A"))
                {
                    artTracked = image.referenceImage.name;
                    m_SpawnedOnePrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                    m_SpawnedThreePrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                    
                }
                else if (image.referenceImage.name.Contains("r"))
                {
                   m_SpawnedTwoPrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation * Quaternion.Euler(Vector3.up * doorDegree));

                    atLeastOneQRTracked = true;
                } else if(image.referenceImage.name.Contains("L"))
                {
                    if(m_SpawnedFourPrefab.active == false && !m_SpawnedFourPrefab.GetComponentInChildren<WaitingInLineManager>().checkInfoLoaded.Equals("None"))
                        m_SpawnedFourPrefab.SetActive(true);

                    m_SpawnedFourPrefab.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
                    atLeastOneWaitingTracked = true;
                    waitingTracked = image.referenceImage.name;
                }
            }
            // image is no longer tracking, disable visuals TrackingState.Limited TrackingState.None
            else
            {

                // && image.referenceImage.name.Equals(artTracked)

                if (image.referenceImage.name.Contains("A") && image.referenceImage.name.Equals(artTracked))
                {
                    m_SpawnedOnePrefab.SetActive(false);
                    m_SpawnedThreePrefab.SetActive(false);

                  

                }
                else if (image.referenceImage.name.Contains("r"))
                {
                    if(m_SpawnedTwoPrefab != null)
                    {

                    }
                        
                } else if(image.referenceImage.name.Contains("L") && image.referenceImage.name.Equals(waitingTracked))
                {
                    m_SpawnedFourPrefab.SetActive(false);
                }


                //Debug.Log("UPDATED (limited): " + image.referenceImage.name);

                

            }
        }

        Debug.Log(atLeastOneWaitingTracked + ""); 
        
        


        if(atLeastOneQRTracked == false)
            m_SpawnedTwoPrefab.SetActive(false);
           

        if (atLeastOneWaitingTracked == false)
        {
            m_SpawnedFourPrefab.SetActive(false);
        }
           

        // removed, destroy spawned instance
        foreach (ARTrackedImage image in obj.removed)
        {

            Debug.Log("REMOVED: " + image.referenceImage.name);

            if (image.referenceImage.name.Contains("A"))
            {
                Destroy(m_SpawnedOnePrefab);
                Destroy(m_SpawnedThreePrefab);
            }
            else if (image.referenceImage.name.Contains("r"))
            {
                Debug.Log("DESTROYED");
                Destroy(m_SpawnedTwoPrefab);
            } else if (image.referenceImage.name.Contains("L"))
            {
                Destroy(m_SpawnedFourPrefab);
            }
        }
    }

    public int NumberOfTrackedImages()
    {
        m_NumberOfTrackedImages = 0;
        foreach (ARTrackedImage image in m_ImageManager.trackables)
        {
            if (image.trackingState == TrackingState.Tracking)
            {
                m_NumberOfTrackedImages++;
            }
        }
        return m_NumberOfTrackedImages;
    }
}
