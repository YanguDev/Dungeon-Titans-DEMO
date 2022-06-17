using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace Utilities
{
    public abstract class DragHandler : MonoBehaviour
    {
        [SerializeField] private bool stopOnUI;

        public event Action<Vector2> onBeginDrag; // Returns mouse position
        public event Action<Vector2> onDrag; // Returns mouse delta
        public event Action<Vector2> onEndDrag; // Returns mouse position
        
        private bool isDragging;
        public bool IsDragging { get { return isDragging; } }

        protected Mouse mouse;
        private EventSystem eventSystem;

        private void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            mouse = Mouse.current;
            eventSystem = EventSystem.current;
        }

        private void Update()
        {
            if(mouse.leftButton.wasReleasedThisFrame) EndDrag();

            if(CanDrag() && mouse.leftButton.wasPressedThisFrame)
                if(!stopOnUI || !eventSystem.IsPointerOverGameObject())
                    BeginDrag();

            if(isDragging) Drag();
        }

        protected abstract bool CanDrag();

        private void BeginDrag()
        {
            isDragging = true;

            if(onBeginDrag != null) onBeginDrag(mouse.GetPosition());
        }

        private void Drag()
        {
            if(onDrag != null) onDrag(mouse.GetDelta());
        }

        private void EndDrag()
        {
            isDragging = false;

            if(onEndDrag != null) onEndDrag(mouse.GetPosition());
        }
    }
}
