namespace Minigames
{
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class ConnectLine : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private LineColor LineColor;
        
        [SerializeField] private RectTransform rectTransform;

        [SerializeField] private LineRenderer LineRenderer;
        
        private Vector3 startPoint;
        
        // private RectTransform rectTransform;
        private Canvas canvas;
        // private CanvasGroup canvasGroup;

        private bool isDragging = false;

        void Start()
        {
            // rectTransform = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
        }

        private void Update()
        {
            LineRenderer.SetPosition(0, startPoint);
            LineRenderer.SetPosition(1, Camera.main.ScreenToViewportPoint(rectTransform.transform.position));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Set the element as being dragged
            isDragging = true;
        
            // Make the UI element appear on top of other UI elements
            rectTransform.SetAsLastSibling();

            // Disable the Raycast Target to allow interaction with other UI elements
            // canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isDragging)
            {
                // Move the UI element based on the pointer's position
                rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // Set the element as no longer being dragged
            isDragging = false;

            // Enable the Raycast Target to allow normal interaction with other UI elements
            // canvasGroup.blocksRaycasts = true;
        }
    }

    public enum LineColor
    {
        Red,
        Green,
        Blue,
        Yellow,
    }
}