using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserEditor.MediaEditor;

public class Init : MonoBehaviour
{
    public WindowSetting windowSetting;

    public GlobalSettingUI globalSettingUI;


    public MediaEditorManager mediaEditorManager;

    private void Start()
    {
        InitWindow();
    }

    private void InitWindow()
    {
        //初始化数据
        //初始化窗口
        windowSetting = new WindowSetting(new Vector2(1920, 1080));


        //初始化UI
        globalSettingUI.Init();

        //初始化编辑器
        mediaEditorManager.Init();
    }
}
