using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Items;

namespace Customization
{
    public class ItemButton : MonoBehaviour
    {
        private Image m_image;
        private TextMeshProUGUI m_label;

        public Image Image { get { return m_image; } }
        public TextMeshProUGUI Label { get { return m_label; } }
        public Item Item { get; set; }

        private void Awake()
        {
            m_image = GetComponent<Image>();
            m_label = GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}

