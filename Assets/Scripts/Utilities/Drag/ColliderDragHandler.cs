using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class ColliderDragHandler : DragHandler
    {
        [SerializeField] private Collider targetCollider;

        private Camera cam;

        protected override void Initialize()
        {
            base.Initialize();

            cam = Camera.main;
        }

        protected override bool CanDrag()
        {
            Ray ray = cam.ScreenPointToRay(mouse.position.ReadValue());

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 10))
            {
                if(hit.collider == targetCollider) return true;
            }

            return false;
        }
    }
}
