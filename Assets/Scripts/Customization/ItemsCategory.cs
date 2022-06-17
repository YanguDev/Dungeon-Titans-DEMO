using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

namespace Customization
{
    public class ItemsCategory : MonoBehaviour
    {
        [SerializeField] private List<Item> items;

        private IItemButtonAppearance m_itemButtonAppearance;
        private IItemButtonAction m_itemButtonAction;

        public List<Item> Items { get { return items; } }
        public IItemButtonAppearance Appearance { get { return m_itemButtonAppearance; } }
        public IItemButtonAction Action
        {
            get
            {
                if(m_itemButtonAction == null)
                    Initialize();
                    
                return m_itemButtonAction;
            }
            
        }

        private void Awake(){
            Initialize();
        }

        private void Initialize(){
            m_itemButtonAppearance = GetComponent<IItemButtonAppearance>();
            m_itemButtonAction = GetComponent<IItemButtonAction>();
        }
    }
}