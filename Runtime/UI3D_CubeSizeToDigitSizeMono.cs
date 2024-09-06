using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3D_CubeSizeToDigitSizeMono : MonoBehaviour
{

    public Transform m_toAffect;
    public float m_digitHeightSize = 0.018f;
    public float m_digitWidthSize = 0.012f;
    public float m_digitDepthSize = 0.001f;


    private void Reset()
    {
        m_toAffect = transform;
    }
    void Start()
    {

        RefreshAsLocalScale();
    }
    private void OnValidate()
    {
        RefreshAsLocalScale();
    }

    [ContextMenu("Refresh Size")]
    public void RefreshAsLocalScale()
    {
        if(m_toAffect != null)
        m_toAffect.localScale = new Vector3(m_digitWidthSize, m_digitHeightSize, m_digitDepthSize);
    }
    
}
