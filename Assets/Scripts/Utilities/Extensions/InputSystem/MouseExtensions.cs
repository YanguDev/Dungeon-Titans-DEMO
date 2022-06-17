using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Utilities
{
    public static class MouseExtensions
    {
        public static Vector2 GetPosition(this Mouse mouse)
        {
            float x = mouse.position.x.ReadValue();
            float y = mouse.position.y.ReadValue();

            return new Vector2(x, y);
        }

        public static Vector2 GetDelta(this Mouse mouse)
        {
            float x = mouse.delta.x.ReadValue();
            float y = mouse.delta.y.ReadValue();

            return new Vector2(x, y);
        }
    }
}
