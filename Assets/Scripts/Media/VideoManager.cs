using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;
using Sirenix.OdinInspector;
using UserEditor.MediaEditor;
using DG.Tweening;

public class VideoManager : MonoBehaviour
{
    [BoxGroup("Generate")]
    public Transform videoDisplayPrefab;
    [BoxGroup("Generate")]
    public Transform videoDisplayGroup;

    public MediaManager mediaManager;

    public List<DisplayUGUI> videoDisplays = new List<DisplayUGUI>();

    public void GenerateDisplay()
    {
        foreach (var item in videoDisplays)
        {
            Destroy(item.gameObject);
        }
        videoDisplays.Clear();
        MediaCell cell;
        for (int i = 0; i < mediaManager.mediaCells.Count; i++)
        {
            cell = mediaManager.mediaCells[i];
            if (cell.mediaType == MediaType.Video)
            {
                GenerateDisplay(cell);
            }
        }
    }

    private void GenerateDisplay(MediaCell cell)
    {
        //生成视频播放载体
        Transform tf = Instantiate(videoDisplayPrefab, videoDisplayGroup);
        tf.name = cell.path;
        DisplayUGUI display = tf.GetComponent<DisplayUGUI>();
        display._mediaPlayer = cell.videoPlayer;
        cell.videoDisplay = display;
        videoDisplays.Add(display);
    }
}