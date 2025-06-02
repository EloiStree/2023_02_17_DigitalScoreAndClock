using UnityEngine;

public class UI3D_SetTextDigit :MonoBehaviour{

    public string m_text;
    public bool m_useUpperCase = true;
    public bool m_useLowerCase = false;
    public UI3D_SetAlphaNumDigit[] m_digitsLeftToRight;

    public void SetWithText(string text)
    {

        m_text = text;

        RefreshUI();
    }
    public void SetWithText(char text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(int text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(float text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(double text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(long text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(uint text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(ulong text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(short text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(ushort text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(byte text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(sbyte text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(bool text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
    public void SetWithText(object text)
    {
        m_text = text.ToString();
        RefreshUI();
    }
   
    public void SetUseOfUpperCase(bool useUpperCase)
    {
        m_useUpperCase = useUpperCase;
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
        if (m_useLowerCase)
            t = t.ToLower();
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
