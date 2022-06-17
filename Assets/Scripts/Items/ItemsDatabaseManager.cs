using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemsDatabaseManager : MonoBehaviour
    {
        [SerializeField] private ItemsDatabase itemsDatabase;
        private static Dictionary<string, Item> m_items;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetItemsDictionary();
        }

        private void SetItemsDictionary()
        {
            m_items = new Dictionary<string, Item>();

            foreach(Item item in itemsDatabase.items)
            {
                if(m_items.ContainsKey(item.id))
                {
                    Debug.LogWarning(string.Format("Item with id <b>{0}</b> already exists. Please check item: {1}", item.id, item.name), item);
                    continue;
                }
                m_items.Add(item.id, item);
            }
        }

        public T GetItem<T>(string id) where T : Item
        {
            if(!m_items.ContainsKey(id))
            {
                Debug.LogWarning(string.Format("Item with id <br>{0}</br> doesn't exist.", id));
            }

            T item = m_items[id] as T;

            return item;
        }
    }
}
