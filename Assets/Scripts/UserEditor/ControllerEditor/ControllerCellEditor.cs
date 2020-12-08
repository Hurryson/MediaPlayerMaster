using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UserEditor.MediaEditor;

namespace UserEditor
{
    namespace ControllerEditor
    {
        public class ControllerCellEditor : MonoBehaviour
        {
            public Button recordKeyboardBtn;

            private bool isRecord = false;

            public Text anyKeyText;

            public MediaCell mediaCell;

            public void Init(MediaCell cell)
            {
                recordKeyboardBtn.onClick.AddListener(OnRecordKeyboardBegin);
                mediaCell = cell;
            }

            private void OnRecordKeyboardBegin()
            {
                isRecord = true;
                if(AppInit.isEditorMode)
                    StartCoroutine(RecordKeybaordUpdate());
            }

            private IEnumerator RecordKeybaordUpdate()
            {
                while (isRecord)
                {
                    //检测键盘按键
                    if (Input.anyKeyDown)
                    {
                        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
                        {
                            if (Input.GetKeyDown(keyCode))
                            {
                                Debug.Log("注册按键 : " + keyCode.ToString());
                                OnRecordKeyboardEnd(keyCode);
                            }
                        }
                    } 
                    yield return null;
                }
            }

            private void OnRecordKeyboardEnd(KeyCode key)
            {
                mediaCell.control.controller.keyCodes.Add(key);
                isRecord = false;
            }
        }
    }
}