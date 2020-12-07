using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 媒体类型
/// </summary>
public enum MediaType
{
    Video,
    Texture
}

/// <summary>
/// 媒体类
/// </summary>
public class Media
{
    public MediaPlayer mediaPlayer;

    public Sprite sprite;
}

/// <summary>
/// 媒体显示类
/// </summary>
public class MediaDisplay
{
    public DisplayUGUI displayUGUI;

    public Image image;
}