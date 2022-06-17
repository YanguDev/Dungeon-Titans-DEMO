using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using Items;

namespace DungeonTitans
{
    [InitializeOnLoad]
    public static class ItemsDatabaseHandler
    {
        private const string itemsDatabasePath = "Assets/Databases/ItemsDatabase.asset";
        private static ItemsDatabase itemsDatabase;
        private static bool initialized = false;

        static ItemsDatabaseHandler()
        {
            if(!initialized) Initialize();
        }

        private static void Initialize()
        {
            itemsDatabase = AssetDatabase.LoadAssetAtPath<ItemsDatabase>(itemsDatabasePath);

            if(itemsDatabase == null)
            {
                ItemsDatabase newItemsDatabase = ScriptableObject.CreateInstance<ItemsDatabase>();
                AssetDatabase.CreateAsset(newItemsDatabase, itemsDatabasePath);

                itemsDatabase = AssetDatabase.LoadAssetAtPath<ItemsDatabase>(itemsDatabasePath);
            }

            initialized = true;
            EditorApplication.playModeStateChanged += (PlayModeStateChange state) => RefreshAllItems();

            RefreshAllItems();
        }

        public static void RefreshAllItems()
        {
            if(!initialized) Initialize();

            List<Item> items = AssetDatabaseWrapper.FindAndLoadAssets<Item>();
            itemsDatabase.items = items;
        }
    }
}
