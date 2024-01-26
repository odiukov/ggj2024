namespace Minigames
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    public class ConnectLine : MonoBehaviour
    {
        [SerializeField] private LineColor LineColor;

        [SerializeField] private Transform endTransform;

        [SerializeField] private LineRenderer LineRenderer;


        [SerializeField] private LayerMask TVLayerMask;

        private Vector2 defaultPosition;
        private Vector2 startDragPosition;
        private bool returnToStartPosition;


        private Vector3 startPoint;

        private static ConnectEndPoint endPoint;


        void Start()
        {
            LineRenderer.transform.SetParent(null);
            LineRenderer.transform.position = Vector3.zero;
        }

        private void Update()
        {
            LineRenderer.SetPosition(0, transform.position);
            LineRenderer.SetPosition(1, endTransform.position);

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                    Single.PositiveInfinity, TVLayerMask);
                endPoint = hit.collider != null ? hit.transform.GetComponent<ConnectEndPoint>() : null;

                OnMouseDown();
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnMouseUp();
            }

            if (Input.GetMouseButton(0))
            {
                OnMouseDrag();
            }
        }


        private void OnMouseDown()
        {
            // defaultPosition = transform.position;
            //
            // Vector2 mousePosition = Input.mousePosition;
            // mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //
            // var localPosition = transform.localPosition;
            // startDragPosition.x = mousePosition.x - localPosition.x;
            // startDragPosition.y = mousePosition.y - localPosition.y;
        }

        private void OnMouseUp()
        {
        }

        private void OnMouseDrag()
        {
            if(endPoint == null)
                return;
            
            if (endPoint != null && endPoint.transform != endTransform)
            {
                return;
            }

            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            endTransform.position =
                new Vector3(mousePosition.x, mousePosition.y, 0);
        }

        public void SetEnd(Transform endPoint)
        {
            endTransform.position = endPoint.position;
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