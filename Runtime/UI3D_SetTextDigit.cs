using UnityEngine;

public class UI3D_SetTextDigit :MonoBehaviour{

    public string m_text;
    public bool m_useUpperCase = true;
    public UI3D_SetAlphaNumDigit[] m_digitsLeftToRight;

    public void SetWith(string text)
    {

        m_text = text;

        RefreshUI();
    }

    private void OnValidate()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        string t = m_text;
        if (m_useUpperCase)
            t = t.ToUpper();
        for (int i = 0; i < m_digitsLeftToRight.Length; i++)
        {
            if (m_digitsLeftToRight[i]!=null) { 
                if (i < t.Length)
                    m_digitsLeftToRight[i].SetWithChar(t[i]);
                else
                    m_digitsLeftToRight[i].SetWithChar(' ');
            }
        }
    }
}
