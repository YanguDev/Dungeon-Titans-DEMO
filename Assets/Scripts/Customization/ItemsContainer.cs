using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;
using Character;

namespace Customization
{
    public class ItemsContainer : MonoBehaviour
    {
        #region Variables

        [Header("Objects")]
        [SerializeField] private Transform buttonsParent;

        [Header("Categories")]
        [SerializeField] private ItemsCategory defaultItemCategory;
        [SerializeField] private ItemsSelector itemsSelector;
        
        [Header("Item Buttons")]
        [SerializeField] private ItemButton defaultItemButton;
        [SerializeField] private int createdButtonsAmount;

        private Color m_defaultItemButtonColor;
        private List<ItemButton> m_itemButtons;

        public List<ItemButton> ItemButtons { get { return m_itemButtons; } }
        public ItemsCategory CurrentCategory { get; private set; }

        public Action<ItemsCategory> onCategoryChanged;

        #endregion

        private void Awake()
        {
            CreateButtons();
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            m_defaultItemButtonColor = defaultItemButton.Image.color;

            if(defaultItemCategory != null)
                ShowCategory(defaultItemCategory);
            else
                HideButtons();
        }

        #region Buttons Handling

        private void CreateButtons()
        {
            m_itemButtons = new List<ItemButton>();
            m_itemButtons.Add(defaultItemButton);

            for(int i = 1; i < createdButtonsAmount; i++){
                ItemButton newItemButton = Instantiate(defaultItemButton, Vector3.zero, Quaternion.identity, buttonsParent);
                m_itemButtons.Add(newItemButton);
            }
        }

        private void HideButtons()
        {
            foreach(ItemButton itemButton in m_itemButtons)
            {
                if(!itemButton.gameObject.activeSelf) break;

                itemButton.gameObject.SetActive(false);
            }
        }

        #endregion

        public void ShowCategory(ItemsCategory itemsCategory)
        {
            HideButtons();

            List<Item> itemsToShow = itemsCategory.Items;
            for(int i = 0; i < itemsToShow.Count; i++)
            {
                Item item = itemsToShow[i];
                ItemButton itemButton = m_itemButtons[i];

                itemButton.gameObject.SetActive(true);
                itemButton.Item = item;
                itemButton.Image.color = m_defaultItemButtonColor;

                itemsCategory.Appearance.SetButton(item, itemButton);
                itemsSelector.SetupItemButton(itemButton, itemsCategory);

                CurrentCategory = itemsCategory;
            }

            onCategoryChanged?.Invoke(itemsCategory);
        }
    }
}

