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

            public MediaCellEditor mediaCellEditor;

            public void Init()
            {
                globalEditor.Init();
                mediaCellEditor.Init();
            }
        }
    }
}
