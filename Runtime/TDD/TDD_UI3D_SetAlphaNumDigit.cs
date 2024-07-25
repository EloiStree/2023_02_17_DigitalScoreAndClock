using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TDD_UI3D_SetAlphaNumDigit : MonoBehaviour
{

    public string m_charToTestInDigt= "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\"'<>+-*/, -_.?=[](){}`´";
    public int m_index = 0;
    public float m_timeBetweenChange = 1.0f;
    public UnityEvent<char> m_onCharEvent;
    public char m_charToTest = '0';
    IEnumerator Start()
    {
        while (true)
        {
            m_charToTest = m_charToTestInDigt[m_index];
            m_onCharEvent.Invoke(m_charToTest);
            m_index++;
            if (m_index >= m_charToTestInDigt.Length)
            {
                m_index = 0;
            }
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_timeBetweenChange);
           
        } 
    }
    private void OnValidate()
    {
        if (m_onCharEvent != null)
        {
            m_onCharEvent.Invoke(m_charToTest);
        }
    }

}
