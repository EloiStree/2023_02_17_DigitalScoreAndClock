using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI3D_SetDigitCountDownMMSS : MonoBehaviour
{
    public float m_timeLeftInSeconds=3;

    public UnityEvent m_onEndOfCountDown;
    public UnityEvent<float> m_onTimeChanged;

    public void SetTimeleftInSeconds(float timeInSeconds)
    {
        m_timeLeftInSeconds = timeInSeconds;
        m_onTimeChanged.Invoke(timeInSeconds);
    }
    

    void Update()
    {
        if (m_timeLeftInSeconds > 0f) {

            m_timeLeftInSeconds -= Time.deltaTime;
            if (m_timeLeftInSeconds <= 0f)
            {
                m_timeLeftInSeconds = 0;
                m_onTimeChanged.Invoke(0);
                m_onEndOfCountDown.Invoke();
            }
            else {
                m_onTimeChanged.Invoke(m_timeLeftInSeconds);
            } 
        }
    }
}
