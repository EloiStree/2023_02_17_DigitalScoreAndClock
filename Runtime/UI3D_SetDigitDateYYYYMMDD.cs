using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3D_SetDigitDateYYYYMMDD : MonoBehaviour
{

        public UI3D_SetClockNumber m_yyyy_year;
        public UI3D_SetClockNumber m_mm_month;
        public UI3D_SetClockNumber m_dd_day;

    public bool m_setAtAwake = true;

    public void Awake()
    {
        if (m_setAtAwake)
            SetWithCurrentDateUTC();
    }

    [ContextMenu("SetWithCurrentDate")]
    public void SetWithCurrentDate()
    {
        SetWithDate(DateTime.Now);
    }
    [ContextMenu("SetWithCurrentDateUTC")]
    public void SetWithCurrentDateUTC()
    {
        SetWithDate(DateTime.UtcNow);
    }




    public void SetWithDate(DateTime date)
        {
        if(m_yyyy_year!=null)
            m_yyyy_year.SetWithNumber(date.Year);
        if (m_mm_month != null)
            m_mm_month.SetWithNumber(date.Month);
        if (m_dd_day != null)
            m_dd_day.SetWithNumber(date.Day);

        }
     
    }
