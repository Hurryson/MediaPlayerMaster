﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserEditor.MediaEditor;

public class AppInit : MonoBehaviour
{
    public WindowSetting windowSetting;

    public GlobalSettingUI globalSettingUI;

    public MediaEditorManager mediaEditorManager;

    public CanvasGroup editorCanvasGroup;

    public MediaManager mediaManager;
    /// <summary>
    /// 是否处于编辑模式
    /// </summary>
    public static bool isEditorMode = true;
    private void Start()
    {
        InitWindow();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (editorCanvasGroup.alpha > 0)
            {
                editorCanvasGroup.DOFade(0, 0.1f);
                editorCanvasGroup.interactable = false;
                editorCanvasGroup.blocksRaycasts = false;
                isEditorMode = false;
            }
            else
            {
                editorCanvasGroup.DOFade(1, 0.1f);
                editorCanvasGroup.interactable = true;
                editorCanvasGroup.blocksRaycasts = true;
                isEditorMode = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (editorCanvasGroup.alpha > 0)
            {
                editorCanvasGroup.DOFade(0, 0.1f);
                editorCanvasGroup.interactable = false;
                editorCanvasGroup.blocksRaycasts = false;
                isEditorMode = false;
            }
        }
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

        //初始化播放器
        mediaManager.Init();
    }
}
