using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModelViewer
{
    public class ViewInputReceiver : MonoBehaviour, IDragHandler, IScrollHandler
    {
        public Action<PointerEventData> OnDragEvent { get; set; }
        public Action<PointerEventData> OnScrollEvent { get; set; }

        public void OnDrag(PointerEventData eventData) => OnDragEvent?.Invoke(eventData);

        public void OnScroll(PointerEventData eventData) => OnScrollEvent?.Invoke(eventData);
    }
}
