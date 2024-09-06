using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FacadeMatchMono_GlobalSetter : MonoBehaviour
{
    
    public static FacadeMatchMono_GlobalSetter InstanceInScene;

    public bool m_useValidateToRefresh;

    private void Awake()
    {
        InstanceInScene = this;


        ResetAllToDefault();
    }

    private void ResetAllToDefault()
    {
        SetTimeLeftInSet(0);
        SetTimeSinceSetStarted(0);
        SetTimeSinceMatchStarted(0);
        SetCurrentMatchScoreBlue(0);
        SetCurrentMatchScoreRed(0);
        SetCurrentMatchSetBlue(0);
        SetCurrentMatchSetRed(0);
        SetTimeNowUTC();
    }

    private void OnValidate()
    {
        if(!Application.isPlaying)
            if (m_useValidateToRefresh)
                RefreshAll();
    }

    public void RefreshAll() { 
    
        SetTeamBlueAvatar(m_teamBlueAvatar);
        SetTeamRedAvatar(m_teamRedAvatar);
        SetTimeLeftInSet(m_setTimeLeftInSet);
        SetTimeSinceSetStarted(m_setTimeSinceSetStarted);
        SetTimeSinceMatchStarted(m_setTimeSinceMatchStarted);
        SetCurrentMatchScoreBlue(m_pointScoreBlue);
        SetCurrentMatchScoreRed(m_pointScoreRed);
        SetCurrentMatchSetBlue(m_setScoreBlue);
        SetCurrentMatchSetRed(m_setScoreRed);
    }

    #region SET TEAM IMAGE

    public Texture2D m_teamRedAvatar;
    public Texture2D m_teamBlueAvatar;
    public UnityEvent<Texture2D> m_onTeamRedAvatar;
    public UnityEvent<Texture2D> m_onTeamBlueAvatar;
    public void SetTeamBlueAvatar(Texture2D texture)
    {
        m_teamBlueAvatar = texture;
        m_onTeamBlueAvatar.Invoke(texture);
    }
    public void SetTeamRedAvatar(Texture2D texture)
    {
        m_teamRedAvatar = texture;
        m_onTeamRedAvatar.Invoke(texture);
    }

    #endregion

    #region SET TIME

    public DateTime m_timeNow;
    public UnityEvent<DateTime> m_onTimeNow;

    public void SetTimeNow(DateTime time) { m_timeNow = time; m_onTimeNow.Invoke(time); }
    public void SetTimeNow() { SetTimeNow(DateTime.Now); }
    public void SetTimeNowUTC() { SetTimeNow(DateTime.UtcNow); }


    public float m_setTimeLeftInSet;
    public float m_setTimeSinceSetStarted;
    public float m_setTimeSinceMatchStarted;
    public UnityEvent<float> m_onSetTimeLeftInSet;
    public UnityEvent<float> m_onSetTimeSinceSetStarted;
    public UnityEvent<float> m_onSetTimeSinceMatchStarted;

    public void SetTimeLeftInSet(float time) { m_setTimeLeftInSet = time; m_onSetTimeLeftInSet.Invoke(time); }
    public void SetTimeSinceSetStarted(float time) { m_setTimeSinceSetStarted = time; m_onSetTimeSinceSetStarted.Invoke(time); }
    public void SetTimeSinceMatchStarted(float time) { m_setTimeSinceMatchStarted = time; m_onSetTimeSinceMatchStarted.Invoke(time); }

    #endregion


    #region SET POINT

    public int m_pointScoreRed;
    public UnityEvent<int> m_onPointScoreRed;

    public int m_pointScoreBlue;
    public UnityEvent<int> m_onPointScoreBlue;

    public int m_setScoreRed;
    public UnityEvent<int> m_onSetScoreRed;

    public int m_setScoreBlue;
    public UnityEvent<int> m_onSetScoreBlue;

    public void SetCurrentMatchScoreBlue(int score) { m_pointScoreBlue = score; m_onPointScoreBlue.Invoke(score); }
    public void SetCurrentMatchScoreRed(int score) { m_pointScoreRed = score; m_onPointScoreRed.Invoke(score); }
    public void SetCurrentMatchSetBlue(int score) { m_setScoreBlue = score; m_onSetScoreBlue.Invoke(score); }
    public void SetCurrentMatchSetRed(int score) { m_setScoreRed = score; m_onSetScoreRed.Invoke(score); }

    public void AddPointScoreBlue(int score) { SetCurrentMatchScoreBlue(m_pointScoreBlue + 1); }
    public void AddPointScoreRed(int score) { SetCurrentMatchScoreRed(m_pointScoreRed + 1); }
    public void AddSetScoreBlue(int score) { SetCurrentMatchSetBlue(m_setScoreBlue + 1); }
    public void AddSetScoreRed(int score) { SetCurrentMatchSetRed(m_setScoreRed + 1); }

    [ContextMenu("ResetMatchScore")]
    public void ResetMatchScore() { SetCurrentMatchScoreBlue(0); SetCurrentMatchScoreRed(0); }
    [ContextMenu("ResetMatchSet")]
    public void ResetMatchSet() { SetCurrentMatchSetBlue(0); SetCurrentMatchSetRed(0); }
    [ContextMenu("ResetMatch")]
    public void ResetMatch() { ResetMatchScore(); ResetMatchSet(); }

    [ContextMenu("IncrementScoreBlue")]
    public void IncrementScoreBlue() { AddPointScoreBlue(1); }
    [ContextMenu("IncrementScoreRed")]
    public void IncrementScoreRed() { AddPointScoreRed(1); }
    [ContextMenu("IncrementSetBlue")]
    public void IncrementSetBlue() { AddSetScoreBlue(1); }
    [ContextMenu("IncrementSetRed")]
    public void IncrementSetRed() { AddSetScoreRed(1); } 
    #endregion


}
