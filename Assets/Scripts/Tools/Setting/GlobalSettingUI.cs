using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettingUI : MonoBehaviour
{
    public Init init;

    public Canvas MediaCanvas;

    public DisplayUGUI mediaDisplay;

    public void Init()
    {
        Vector2 reslotion = init.windowSetting.GetResolution();
        //mediaDisplay.rectTransform.sizeDelta = reslotion;
    }
}
