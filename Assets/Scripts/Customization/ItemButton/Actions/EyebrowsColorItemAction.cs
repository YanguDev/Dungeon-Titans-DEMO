using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Character;

namespace Customization
{
    public class EyebrowsColorItemAction : MonoBehaviour, IItemButtonAction
    {
        public void Execute(Item item, CharacterModel characterModel)
        {
            ColorItem colorItem = item as ColorItem;
            if(colorItem == null) return;

            characterModel.EyebrowsColor = colorItem;
        }
    }
}
