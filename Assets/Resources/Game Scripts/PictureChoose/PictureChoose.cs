using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PictureChoose : MonoBehaviour
{
    private Sprite[] sprites;
    private string GALLERY_PATH = @"Assets\Resources\Sprites\PictureChoose\Nyaumi\Chapter 1\";
    private string RESOURCE_PATH = @"Sprites\PictureChoose\Nyaumi\Chapter 1\";
    private Image[] pictures;
    private bool fullPictureMode;

    public Image fullPicture;
    public GameObject scroll;

    void Start()
    {
        pictures = GameObject.FindGameObjectWithTag("Content").GetComponentsInChildren<Image>();
        scroll.GetComponent<ScrollRect>().scrollSensitivity = 32;
        fullPictureMode = false;
        Load();
    }

    private void Update()
    {
        if(fullPictureMode && Input.anyKey)
        {
            fullPictureMode = false;
            fullPicture.transform.position = new Vector3(18,0,0);
            fullPicture.color = new Color(255, 255, 255, 0);
        }
    }

    private void Load()
    {
        sprites = new Sprite[Directory.GetFiles(Path.GetFullPath(GALLERY_PATH), "*.png").Length];

        sprites = Resources.LoadAll<Sprite>(RESOURCE_PATH);

        for(int i = 0; i < pictures.Length; i++)
        {
            pictures[i].sprite = sprites[i];
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Gallery");
    }

    public void pictureChoose(Image image)
    {
        fullPictureMode = true;
        fullPicture.sprite = image.sprite;
        fullPicture.color = new Color(255, 255, 255, 255);
        fullPicture.transform.position = new Vector3(0,0,0);
    }
}
