using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Color", menuName = "Items/Color")]
    public class ColorItem : Item
    {
        public Color color = new Color(1, 1, 1, 1);
    }
}