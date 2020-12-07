using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Modelu.Tools;
using System.Runtime.InteropServices;
using System.IO;
using Sirenix.OdinInspector;

namespace UserEditor
{
    namespace MediaEditor
    {
        public class GlobalEditor : MonoBehaviour
        {
            [BoxGroup("Setting")]
            public string videoFolder = "Video/";
            [BoxGroup("Setting")]
            public Button videoFolderPathBtn;

            [BoxGroup("Generate")]
            public Button generateAllVideoBtn;
            [BoxGroup("Generate")]
            public Button clearAllVideoBtn;
            [BoxGroup("Generate")]
            public Transform videoItemPrefab;
            [BoxGroup("Generate")]
            public Transform videoGroup;
            private List<Transform> videoItems = new List<Transform>();
            public void Init()
            {
                videoFolderPathBtn.onClick.AddListener(SelectVideoFolder);

                generateAllVideoBtn.onClick.AddListener(GenerateAllVideos);

                clearAllVideoBtn.onClick.AddListener(ClearAllVideos);
            }

            /// <summary>
            /// 选择文件夹路径
            /// </summary>
            private void SelectVideoFolder()
            {
                
            }

            /// <summary>
            /// 生成文件夹下所有视频配置信息
            /// </summary>
            private void GenerateAllVideos()
            {
                List<string> videoNames = GetFiles(videoFolder);
                for (int i = 0; i < videoNames.Count; i++)
                {
                    Transform tf = Instantiate(videoItemPrefab, videoGroup);
                    videoItems.Add(tf);
                }
            }

            /// <summary>
            /// 清除所有视频配置信息
            /// </summary>
            private void ClearAllVideos()
            {
                for (int i = 0; i < videoItems.Count; i++)
                {
                    Destroy(videoItems[i].gameObject);
                }
                videoItems.Clear();
            }

            /// <summary>
            /// 读取文件夹下的所有视频
            /// </summary>
            /// <returns></returns>
            public List<string> GetFiles(string path)
            {
                List<string> names = new List<string>();
                if (Directory.Exists(path))
                {
                    DirectoryInfo direction = new DirectoryInfo(path);
                    FileInfo[] files = direction.GetFiles("*");
                    for (int i = 0; i < files.Length; i++)
                    {
                        //忽略关联文件
                        if (files[i].Name.EndsWith(".meta"))
                        {
                            continue;
                        }
                        Debug.Log("文件名:" + files[i].Name);
                        names.Add(files[i].Name);
                    }
                }
                return names;
            }
        }
    }
}