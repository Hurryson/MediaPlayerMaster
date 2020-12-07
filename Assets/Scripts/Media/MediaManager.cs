using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserEditor.MediaEditor;

public class MediaManager : MonoBehaviour
{
    [BoxGroup("Manager")]
    public VideoManager videoManager;
    [BoxGroup("Manager")]
    public TextureManager textureManager;

    public string videoFolder;

    /// <summary>
    /// 存储所有的媒体信息
    /// </summary>
    public List<MediaCell> mediaCells = new List<MediaCell>();

    public int selectMediaID = 0;

    public void Init(string _videoFolder, List<MediaCell> cells)
    {
        videoFolder = _videoFolder;
        mediaCells = cells;
    }

    public void Perform()
    {
        Select(selectMediaID);
    }

    /// <summary>
    /// 生成视频和图片的媒体源和播放载体
    /// </summary>
    public void Generate()
    {
        videoManager.GenerateDisplay();
        Perform();
    }

    [Button]
    public void Select(int id)
    {
        mediaCells[selectMediaID].Hide();
        mediaCells[id].Show();
        selectMediaID = id;
    }
}