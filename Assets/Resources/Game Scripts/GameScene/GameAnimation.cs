using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameAnimation : MonoBehaviour
{
    private const string ANIMATION_PATH = @"Assets\Sprites\Animations\";
    private Sprite[] sprites;
    public string path;

    public GameAnimation(string path, int lenght)
    {
        Load(path, lenght);
    }

    private void Load(string path, int lenght)
    {
        if (lenght < 0)
            return;

        sprites = new Sprite[lenght];

        string[] spritePaths = Directory.GetFiles(Path.GetFullPath(ANIMATION_PATH + path), "*.png");

        for (int i = 0; i < lenght; i++)
            sprites[i] = Resources.Load(spritePaths[i]) as Sprite;

    }

    public Sprite getSprite(int count)
    {
        return sprites[count];
    }

}
