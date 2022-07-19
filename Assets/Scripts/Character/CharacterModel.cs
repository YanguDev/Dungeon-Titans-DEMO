using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

#if(UNITY_EDITOR)
    using UnityEditor;
#endif


namespace Character
{
    public class CharacterModel : MonoBehaviour
    {
        
        [SerializeField] private ItemsDatabaseManager itemsDatabaseManager;
        
        [Header("Mesh Renderers")]
        [Space]
        [SerializeField] private SkinnedMeshRenderer headRenderer;
        [SerializeField] private SkinnedMeshRenderer hairRenderer;
        [SerializeField] private SkinnedMeshRenderer bodyRenderer;

        private CharacterModelData characterModelData = new CharacterModelData();

        public CharacterModelData CharacterModelData
        {
            get { return characterModelData; }
            set
            {
                characterModelData = value;

                HairStyle = itemsDatabaseManager.GetItem<MeshItem>(characterModelData.hairStyleID);
                Body = itemsDatabaseManager.GetItem<MeshItem>(characterModelData.bodyID);
                HairColor = itemsDatabaseManager.GetItem<ColorItem>(characterModelData.hairStyleID);
                EyebrowsColor = itemsDatabaseManager.GetItem<ColorItem>(characterModelData.eyebrowsColorID);
                EyesColor = itemsDatabaseManager.GetItem<ColorItem>(characterModelData.eyesColorID);
                SkinColor = itemsDatabaseManager.GetItem<ColorItem>(characterModelData.skinColorID);
            }
        }

        public MeshItem HairStyle
        {
            // get { return characterModelData.hairStyle; }
            set
            {
                characterModelData.hairStyleID = value.id;
                hairRenderer.sharedMesh = value.mesh;
            }
        }

        public MeshItem Body
        {
            // get { return characterModelData.body; }
            set
            {
                characterModelData.bodyID = value.id;
                bodyRenderer.sharedMesh = value.mesh;
            }
        }

        public ColorItem HairColor
        {
            // get { return characterModelData.hairColor; }
            set
            {
                characterModelData.hairColorID = value.id;
                hairRenderer.material.color = value.color;
            }
        }

        public ColorItem EyebrowsColor
        {
            // get { return characterModelData.eyebrowsColor; }
            set
            {
                characterModelData.eyebrowsColorID = value.id;
                headRenderer.materials[2].color = value.color;
            }
        }

        public ColorItem EyesColor
        {
            // get { return characterModelData.eyesColor; }
            set
            {
                characterModelData.eyesColorID = value.id;
                headRenderer.materials[1].color = value.color;
            }
        }

        public ColorItem SkinColor
        {
            // get { return characterModelData.skinColor; }
            set
            {
                characterModelData.skinColorID = value.id;
                headRenderer.materials[0].color = value.color;
            }
        }

        private void Awake()
        {
            characterModelData = new CharacterModelData();
        }
    }
}