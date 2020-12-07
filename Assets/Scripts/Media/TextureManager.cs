using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserEditor.MediaEditor;

public class TextureManager : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("texture play");
    }

    public void Pause()
    {

    }

    public void Stop()
    {

    }

    public void Generate(MediaCell cell)
    {
        //Transform tf = Instantiate(mediaPlayerPrefab, videoGroup);
        //tf.name = cell.path;
    }

    public void Display(MediaDisplay display)
    {
        //display.image.sprite = media.sprite;
    }
}