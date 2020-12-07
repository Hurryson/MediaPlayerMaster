using DG.Tweening;
using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UserEditor
{
    namespace MediaEditor
    {
        public class MediaCellEditor : MonoBehaviour
        {
            public static MediaCellEditor _instance;

            private CanvasGroup canvasGroup;

            public Text pathText;

            public Dropdown mediaTypeDropdown;

            public Button playBtn;

            public Button stopBtn;

            public Slider seekSlider;

            public Button removeBtn;

            public Button closeBtn;

            public DisplayUGUI display;

            [HideInInspector]
            public MediaCell mediaCell;
            public void Init()
            {
                _instance = this;
                canvasGroup = GetComponent<CanvasGroup>();

                Close();

                mediaTypeDropdown.onValueChanged.AddListener(SetMediaType);
                playBtn.onClick.AddListener(Play);
                stopBtn.onClick.AddListener(Stop);
                removeBtn.onClick.AddListener(RemoveCell);
                closeBtn.onClick.AddListener(Close);
            }

            public void Open(MediaCell cell)
            {
                canvasGroup.DOFade(1, 0.1f);
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;

                mediaCell = cell;
                pathText.text = mediaCell.path;
                display._mediaPlayer = cell.videoPlayer;
            }

            public void Close()
            {
                canvasGroup.DOFade(0, 0.1f);
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }

            private void SetMediaType(int value)
            {
                mediaCell.mediaType = (MediaType)value;
            }

            private void Play()
            {
                mediaCell.Play();
            }

            private void Stop()
            {
                mediaCell.Stop();
            }

            private void RemoveCell()
            {
                mediaCell.Remove();
                Close();
            }
        }
    }
}