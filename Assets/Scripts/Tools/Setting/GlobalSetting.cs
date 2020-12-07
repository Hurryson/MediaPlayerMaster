using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetting 
{

}

#region Window Setting
public class WindowSetting
{
    private Vector2 _resolution;

    /// <summary>
    /// 适配显示器分辨率
    /// </summary>
    /// <param name="isFullWindow">默认全屏</param>
    public WindowSetting(bool isFullWindow = true)
    {
        Screen.SetResolution(Screen.width, Screen.height, isFullWindow);
        _resolution = new Vector2(Screen.width, Screen.height);
    }

    /// <summary>
    /// 自定义窗口分辨率
    /// </summary>
    /// <param name="resolution">分辨率</param>
    /// <param name="isFullWindow">默认全屏</param>
    public WindowSetting(Vector2 resolution, bool isFullWindow = true)
    {
        Screen.SetResolution((int)resolution.x, (int)resolution.y, isFullWindow);
        _resolution = resolution;
    }

    /// <summary>
    /// 获取分辨率
    /// </summary>
    /// <returns></returns>
    public Vector2 GetResolution()
    {
        return _resolution;
    }
}
#endregion