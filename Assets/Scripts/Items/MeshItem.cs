using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Mesh", menuName = "Items/Mesh")]
    public class MeshItem : Item
    {
        public Mesh mesh;
    }
}