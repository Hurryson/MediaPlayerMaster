using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMediaControl
{
    void SetMedia(Media media);

    Media GetMedia();
    /// <summary>
    /// 播放
    /// </summary>
    void Play();

    /// <summary>
    /// 暂停
    /// </summary>
    void Pause();

    /// <summary>
    /// 停止
    /// </summary>
    void Stop();

    void Display(MediaDisplay display);
}