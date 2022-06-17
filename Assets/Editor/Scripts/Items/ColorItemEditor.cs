using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Items;

[CustomEditor(typeof(ColorItem))]
public class ColorItemEditor : Editor
{
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        ColorItem item = (ColorItem)target;

        Color targetColor = item.color;
        Texture2D texture = new Texture2D(width, height);

        Color[] pixels = texture.GetPixels();
        for(int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = targetColor;
        }
        texture.SetPixels(pixels);
        texture.Apply();

        return texture;
    }
}
