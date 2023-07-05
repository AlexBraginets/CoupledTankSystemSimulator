using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Views.Common
{
    public class HeldButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public event Action OnButtonDown;
        public event Action OnButtonUp;

        public void OnPointerUp(PointerEventData eventData)
        {
            OnButtonUp?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnButtonDown?.Invoke();
        }
    }
}