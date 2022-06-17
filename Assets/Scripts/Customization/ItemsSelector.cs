using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;
using Character;

namespace Customization
{
    public class ItemsSelector : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] private CharacterModel characterModel;
        [SerializeField] private ItemsContainer itemsContainer;
        [SerializeField] private List<ItemsCategory> itemsCategories;
        [SerializeField] private GameObject selectionIndicator;

        private Dictionary<ItemsCategory, ItemButton> m_selection = new Dictionary<ItemsCategory, ItemButton>();

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            selectionIndicator = Instantiate(selectionIndicator, transform);
            selectionIndicator.SetActive(false);

            itemsContainer.onCategoryChanged += ShowCategorySelection;

            SelectDefaultItems();
        }

        private void SelectDefaultItems()
        {
            foreach(ItemsCategory itemsCategory in itemsCategories)
            {
                if(itemsCategory.Items.Count > 0)
                {
                    SelectItem(itemsCategory.Items[0], itemsCategory);
                }
            }
        }

        public void SelectRandomItems()
        {
            foreach(ItemsCategory itemsCategory in itemsCategories)
            {
                if(itemsCategory.Items.Count > 0)
                {
                    int id = Random.Range(0, itemsCategory.Items.Count);
                    SelectItem(itemsCategory.Items[id], itemsCategory);
                }
            }
        }

        public void SetupItemButton(ItemButton itemButton, ItemsCategory itemsCategory)
        {   
            Button button = itemButton.GetComponent<Button>();

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => SelectItem(itemButton.Item, itemsCategory));
        }

        public void SelectItem(Item item, ItemsCategory itemsCategory)
        {
            int index = itemsCategory.Items.IndexOf(item);
            ItemButton itemButton = itemsContainer.ItemButtons[index];

            itemsCategory.Action.Execute(item, characterModel);

            if(m_selection.ContainsKey(itemsCategory))
                m_selection[itemsCategory] = itemButton;
            else
                m_selection.Add(itemsCategory, itemButton);

            if(itemsContainer.CurrentCategory == itemsCategory)
                ShowSelection(itemButton);
        }

        public void ShowSelection(ItemButton itemButton)
        {
            if(!selectionIndicator.activeSelf)
                selectionIndicator.SetActive(true);

            selectionIndicator.transform.SetParent(itemButton.transform, false);
        }

        private void ShowCategorySelection(ItemsCategory itemsCategory)
        {
            if(!m_selection.ContainsKey(itemsCategory)) return;

            ShowSelection(m_selection[itemsCategory]);
        }
    }
}
