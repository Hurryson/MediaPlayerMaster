using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

            [BoxGroup("Generate Cell")]
            public Button generateBtn;
            [BoxGroup("Generate Cell")]
            public Button generateAllVideoBtn;
            [BoxGroup("Generate Cell")]
            public Button clearAllVideoBtn;
            [BoxGroup("Generate Cell")]
            public Transform videoItemPrefab;
            [BoxGroup("Generate Cell")]
            public Transform videoGroup;

            private List<MediaCell> mediaCells = new List<MediaCell>();

            public void Init()
            {
                videoFolderPathBtn.onClick.AddListener(SelectVideoFolder);

                generateBtn.onClick.AddListener(GenerateCell);

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
            /// 生成单个配置
            /// </summary>
            private void GenerateCell()
            {
                Spawner("");
            }

            /// <summary>
            /// 生成文件夹下所有视频配置信息
            /// </summary>
            private void GenerateAllVideos()
            {
                List<string> videoNames = GetFiles(videoFolder);
                for (int i = 0; i < videoNames.Count; i++)
                {
                    Spawner(videoNames[i]);
                }
            }

            private MediaCell Spawner(string path)
            {
                Transform tf = Instantiate(videoItemPrefab, videoGroup);
                MediaCell cell = tf.GetComponent<MediaCell>();
                cell.Init(videoFolder,path,this);
                mediaCells.Add(cell);
                GenerateRule();
                return cell;
            }

            public void RemoveCell(MediaCell cell)
            {
                Destroy(cell.gameObject);
                mediaCells.Remove(cell);

                GenerateRule();
            }

            /// <summary>
            /// 清除所有视频配置信息
            /// </summary>
            private void ClearAllVideos()
            {
                for (int i = 0; i < mediaCells.Count; i++)
                {
                    Destroy(mediaCells[i].gameObject);
                }
                mediaCells.Clear();

                GenerateRule();
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

            /// <summary>
            /// 生成配置规则
            /// </summary>
            private void GenerateRule()
            {
                MediaManager mediaManager = FindObjectOfType<MediaManager>();
                for (int i = 0; i < mediaCells.Count; i++)
                {
                    mediaCells[i].id = i;
                    mediaCells[i].Rename();
                }
                mediaManager.Init(videoFolder, mediaCells);
                mediaManager.Generate();
            }
        }
    }
}