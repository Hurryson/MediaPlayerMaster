using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserEditor
{
    namespace ControllerEditor
    {
        [Serializable]
        public class Controller
        {
            public List<KeyCode> keyCodes;

            public List<string> commands;

            public Controller()
            {
                keyCodes = new List<KeyCode>();

                commands = new List<string>();
            }
        }

        [Serializable]
        public class MediaEvent
        {
            public delegate void MediaHandler(int id);

            public delegate void MediaSelectHandler(int id);

            public event MediaSelectHandler mediaSelectEvent;

            public event MediaHandler mediaPlayEvent;

            /// <summary>
            /// 执行注册的事件   暂时只支持选中并播放事件
            /// </summary>
            public void Perform(int id)
            {
                if(mediaSelectEvent != null)
                    mediaSelectEvent.Invoke(id);
                //mediaPlayEvent.Invoke(id);
            }
        }
    }
}
