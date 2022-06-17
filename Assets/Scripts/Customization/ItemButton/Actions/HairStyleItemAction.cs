using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using Character;

namespace Customization
{
    public class HairStyleItemAction : MonoBehaviour, IItemButtonAction
    {
        public void Execute(Item item, CharacterModel characterModel)
        {
            MeshItem meshItem = item as MeshItem;
            if(meshItem == null) return;
            
            characterModel.HairStyle = meshItem;
        }
    }
}