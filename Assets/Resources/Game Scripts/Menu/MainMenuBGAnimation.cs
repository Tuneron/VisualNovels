using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenuBGAnimation : MonoBehaviour
{
    public Image background;
    private float xVector;
    private float yVector;
    public Text deb;

    // Update is called once per frame
    void Update()
    {
        //deb.text = "Video X : " + background.transform.position.x + " Y : " + background.transform.position.y + "\n" +
        //"MOUSE X : " + Input.mousePosition.x + " Y : " + Input.mousePosition.y;

        background.transform.position = new Vector3((Input.mousePosition.x - 960) / 3000, (Input.mousePosition.y - 540) / 3000, 0);
    }
}
