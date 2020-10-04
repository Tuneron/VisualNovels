using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PictureChooseButton : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource buttonSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonSound.Play();
    }

    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }
}
