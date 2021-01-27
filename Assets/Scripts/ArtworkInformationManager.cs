
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtworkInformationManager : MonoBehaviour
{

    public Text ArtworkName;
    public Text ArtworkDescription;
    public Image Background;
    public Image CloseButton;
    Vector3 BackgroundPosition;
    Vector3 DescriptionPosition;
    Vector3 NamePosition;
    Vector3 CloseButtonPosition;

    int time = 5;

    // Update is called once per frame
    void Update()
    {
        time++;

        if (time > 4)
        {
            time = 0;
            BackgroundPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            DescriptionPosition = BackgroundPosition;
            DescriptionPosition.y -= 100;
            NamePosition = BackgroundPosition;
            NamePosition.y += 630;
            CloseButtonPosition = BackgroundPosition;
            CloseButtonPosition.y += 630;
            CloseButtonPosition.x += 382;


            if (Background.transform.position.x - BackgroundPosition.x > 20 || Background.transform.position.x - BackgroundPosition.x < -20 || Background.transform.position.y - BackgroundPosition.y > 20 || Background.transform.position.y - BackgroundPosition.y < -20 || Background.transform.position.z - BackgroundPosition.z > 20 || Background.transform.position.z - BackgroundPosition.z < -20)
            {
                ArtworkDescription.transform.position = DescriptionPosition;
                ArtworkName.transform.position = NamePosition;
                Background.transform.position = BackgroundPosition;
                CloseButton.transform.position = CloseButtonPosition;
            }
        }


    }
}
