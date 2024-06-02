using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI3D_SetLedColorOfDigit : MonoBehaviour
{
    public Color m_colorChoosed= Color.red;
    public UnityEvent<Color> m_onColorChanged;
    public void SetColorOfDigit(Color newColor) {

        m_onColorChanged.Invoke(newColor);
    }
    [ContextMenu("SetRed")]
    public void SetRed() => SetColorOfDigit( new Color(1,0,0,1));
    [ContextMenu("SetGreen")]
    public void SetGreen() => SetColorOfDigit(new Color(0, 1, 0, 1));
    [ContextMenu("SetYellow")]
    public void SetYellow() => SetColorOfDigit(new Color(1, 1, 0, 1));
    [ContextMenu("SetRandomColor")]
    public void SetRandomColor() => SetColorOfDigit(GetRandomColor());

  
    public static Color GetRandomColor(float alhaPercent = 1)
    {
        return new Color(Random.value, Random.value, Random.value, alhaPercent);
    }
}
