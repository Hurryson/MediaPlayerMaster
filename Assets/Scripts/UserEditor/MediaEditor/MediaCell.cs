using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;
using Sirenix.OdinInspector;
using TMPro;

namespace UserEditor
{
    namespace MediaEditor
    {
        public class MediaCell : MonoBehaviour,IPointerClickHandler
        {
            public int id;

            public string folder;

            public string path;

            public MediaType mediaType;

            public Transform videoPlayerPrefab;

            public MediaPlayer videoPlayer;

            public DisplayUGUI videoDisplay;

            private GlobalEditor globalEditor;

            public KeyCode playKey;

            [System.Serializable]
            public class Info
            {
                //自身预览的Display
                [BoxGroup("Self Display")]
                public DisplayUGUI videoDisplay;
                [BoxGroup("Self Display")]
                public RawImage textureDisplay;
            }

            public Info info;

            public void OnPointerClick(PointerEventData eventData)
            {
                MediaCellEditor._instance.Open(this);
            }

            public void Init(string _folder,string _path , GlobalEditor editor)
            {
                folder = _folder;
                path = _path;
                globalEditor = editor;
                Spawner();
            }

            public void Spawner()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        Transform tf = Instantiate(videoPlayerPrefab, transform);
                        tf.name = path;
                        videoPlayer = tf.GetComponent<MediaPlayer>();
                        if (videoPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToProjectFolder, folder + "/" + path, false))
                        {
                            info.videoDisplay.gameObject.SetActive(true);
                            info.videoDisplay._mediaPlayer = videoPlayer;
                        }

                        break;
                }
            }

            public void Remove()
            {
                globalEditor.RemoveCell(this);
            }

            public void Rename()
            {
                transform.name = id + "_" + path + "_" + mediaType;
            }

            [ButtonGroup("Control")]
            public void Show()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        videoDisplay.DOFade(1, 0.1f);
                        break;
                    case MediaType.Texture:

                        break;
                }
            }

            [ButtonGroup("Control")]
            public void Hide()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        videoDisplay.DOFade(0, 0.1f);
                        break;
                    case MediaType.Texture:

                        break;
                }
            }

            [ButtonGroup("Control")]
            public void Play()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        videoPlayer.Play();
                        break;
                    case MediaType.Texture:

                        break;
                }
            }
            [ButtonGroup("Control")]
            public void Puase()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        videoPlayer.Pause();
                        break;
                    case MediaType.Texture:

                        break;
                }
            }
            [ButtonGroup("Control")]
            public void Stop()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        videoPlayer.Stop();
                        break;
                    case MediaType.Texture:

                        break;
                }
            }
            [ButtonGroup("Control")]
            public void Rewind()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        videoPlayer.Rewind(true);
                        break;
                    case MediaType.Texture:

                        break;
                }
            }

            [ButtonGroup("Volumn")]
            public void Mute()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        videoPlayer.Control.MuteAudio(true);
                        break;
                    case MediaType.Texture:

                        break;
                }
            }
            [ButtonGroup("Volumn")]
            public void Unmute()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        videoPlayer.Control.MuteAudio(false);
                        break;
                    case MediaType.Texture:

                        break;
                }
            }
            [ButtonGroup("Volumn")]
            public void VolumnUp()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        
                        break;
                    case MediaType.Texture:

                        break;
                }
            }
            [ButtonGroup("Volumn")]
            public void VolumnDown()
            {
                switch (mediaType)
                {
                    case MediaType.Video:
                        
                        break;
                    case MediaType.Texture:

                        break;
                }
            }
        }
    }
}