using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gallery : MonoBehaviour
{
    public static string currentCharacter = "None";
    public Image[] panels;
    public int[] positionsAlpha;

    private AudioSource source;

    public void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Choose()
    {
        currentCharacter = @"Nyaumi\";
        SceneManager.LoadScene("PictureChoose");
    }

    public void LeftChoose()
    {
        Vector3 temp = panels[0].transform.position;
        panels[0].transform.position = panels[panels.Length - 1].transform.position;
        for (int i = panels.Length - 1; i > 0; i--)
            panels[i].transform.position = panels[i - 1].transform.position;
        panels[1].transform.position = temp;
        source.Play();
    }

    public void RihtChoose()
    {
        Vector3 temp = panels[panels.Length - 1].transform.position;
        panels[panels.Length - 1].transform.position = panels[0].transform.position;
        for (int i = 0; i < panels.Length - 2; i++)
            panels[i].transform.position = panels[i + 1].transform.position;
        panels[panels.Length - 2].transform.position = temp;
        source.Play();
    }

}
