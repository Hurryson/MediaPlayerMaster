using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace UITools
{
    public class ScaleAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public float scale = 1.1f;

        public float duration = 0.2f;

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(scale, duration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(1, duration);
        }
    }
}