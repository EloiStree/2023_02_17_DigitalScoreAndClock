using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3D_SetURPRendererTexture2D : MonoBehaviour
{
    public string m_textureName = "_BaseMap";
    public Texture2D m_givenTexture2D;
    public Renderer m_targetRenderer;

    public void SetTexture(Texture2D texture)
    {
        SetAsBlackIfNull(ref texture);

        if (m_targetRenderer != null)
            m_targetRenderer.material.SetTexture(m_textureName, texture);

    }

    private static void SetAsBlackIfNull(ref Texture2D texture)
    {
        if (texture == null)
        {
            texture = new Texture2D(2, 2);
            Color[] colors = new Color[4] { Color.black, Color.black, Color.black, Color.black };
            texture.SetPixels(colors);
            texture.Apply();
        }

    }

    private void Reset()
    {
        m_targetRenderer = GetComponent<Renderer>();
    }
}
