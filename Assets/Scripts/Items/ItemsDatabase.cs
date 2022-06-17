using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

    [CreateAssetMenu(menuName = "Databases/Items")]
    public class ItemsDatabase : ScriptableObject
    {
        public List<Item> items = new List<Item>();
    }
