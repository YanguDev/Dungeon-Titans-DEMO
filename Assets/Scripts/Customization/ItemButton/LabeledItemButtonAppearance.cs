using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Customization
{
    public class LabeledItemButtonAppearance : MonoBehaviour, IItemButtonAppearance
    {
        public void SetButton(Item item, ItemButton itemButton)
        {
            itemButton.Label.text = item.name;
        }
    }
}
