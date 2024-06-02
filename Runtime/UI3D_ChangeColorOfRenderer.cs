using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3D_ChangeColorOfRenderer : MonoBehaviour
{

    public Renderer[] m_renderColor;

    public void SetColor(Color color) {

        foreach (var item in m_renderColor)
        {
            item.material.color = color;
        }
    }

    private void Reset()
    {
        m_renderColor = gameObject.GetComponentsInChildren<Renderer>(true);
    }
}
