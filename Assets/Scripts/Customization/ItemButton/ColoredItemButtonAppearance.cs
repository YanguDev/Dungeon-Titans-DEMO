using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Customization
{
    public class ColoredItemButtonAppearance : MonoBehaviour, IItemButtonAppearance
    {
        public void SetButton(Item item, ItemButton itemButton)
        {
            ColorItem colorItem = item as ColorItem;
            if(colorItem == null) return;

            itemButton.Label.text = "";
            itemButton.Image.color = colorItem.color;
        }
    }
}