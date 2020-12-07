using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserEditor
{
    namespace MediaEditor
    {
        public class MediaEditorManager : MonoBehaviour
        {
            public GlobalEditor globalEditor;

            public void Init()
            {
                globalEditor.Init();
            }
        }
    }
}
