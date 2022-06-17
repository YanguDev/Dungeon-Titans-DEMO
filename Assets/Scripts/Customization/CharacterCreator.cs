using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Character;

namespace Customization
{
    public class CharacterCreator : MonoBehaviour
    {
        [SerializeField] private CharacterModel characterModel;
        [SerializeField] private TMP_InputField nameInputField;

        public void CreateCharacter()
        {
            string name = nameInputField.text;
            if(name.Length == 0)
            {
                Debug.LogWarning("Name input field cannot be empty");
                return;
            }

            CharacterData character = new CharacterData(name, characterModel.CharacterModelData);
        }
    }
}
