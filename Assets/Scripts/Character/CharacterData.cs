using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterData
    {
        public string name;
        public CharacterModelData modelData;

        public CharacterData(string _name, CharacterModelData _modelData)
        {
            name = _name;
            modelData = _modelData;
        }
    }
}
