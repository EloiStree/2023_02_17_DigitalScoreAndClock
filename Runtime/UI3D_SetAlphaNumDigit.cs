using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;

public class UI3D_SetAlphaNumDigit : MonoBehaviour
{
    public char m_value;
    public BoolEvent m_left;
    public BoolEvent m_right;
    public BoolEvent m_down;
    public BoolEvent m_up;

    public BoolEvent m_diagonalTopLeft;
    public BoolEvent m_diagonalTopRight;
    public BoolEvent m_diagonalDownLeft;
    public BoolEvent m_diagonalDownRight;


    public BoolEvent m_topBorderLeftSide;
    public BoolEvent m_topBorderRightSide;
    public BoolEvent m_downBorderLeftSide;
    public BoolEvent m_downBorderRightSide;

    public BoolEvent m_leftBorderTopSide;
    public BoolEvent m_leftBorderDownSide;
    public BoolEvent m_rightBorderTopSide;
    public BoolEvent m_rightBorderDownSide;

    public BoolEvent m_dot;


    public enum AlphaNumDigit16Seg {
        Down,
        Left,
        Up,
        Right,
        DiagonalTopLeft,
        DiagonalTopRight,
        DiagonalDownLeft,
        DiagonalDownRight,
        TopBorderLeftSide,
        TopBorderRightSide,
        DownBorderLeftSide,
        DownBorderrightSide,
        LeftBorderTopSide,
        LeftBorderDownSide,
        RightBorderTopSide,
        RightBorderDownSide,
        Dot

    }

    public AlphaNumDigit16Seg[] m_all = new AlphaNumDigit16Seg[] {
    AlphaNumDigit16Seg.Dot,
    AlphaNumDigit16Seg.Down,
    AlphaNumDigit16Seg.Left,
    AlphaNumDigit16Seg.Up,
    AlphaNumDigit16Seg.Right,
    AlphaNumDigit16Seg.DiagonalTopLeft,
    AlphaNumDigit16Seg.DiagonalTopRight,
    AlphaNumDigit16Seg.DiagonalDownLeft,
    AlphaNumDigit16Seg.DiagonalDownRight,
    AlphaNumDigit16Seg.TopBorderLeftSide,
    AlphaNumDigit16Seg.TopBorderRightSide,
    AlphaNumDigit16Seg.DownBorderLeftSide,
    AlphaNumDigit16Seg.DownBorderrightSide,
    AlphaNumDigit16Seg.LeftBorderTopSide,
    AlphaNumDigit16Seg.LeftBorderDownSide,
    AlphaNumDigit16Seg.RightBorderTopSide,
    AlphaNumDigit16Seg.RightBorderDownSide




    };


    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void OnValidate()
    {
        SetWithChar(m_value);
    }



    public void SetWithChar(char digit)
    {
        digit = digit.ToString().ToUpper()[0];

        switch (digit)
        {
            case '0': FullEnable(); Disable(AlphaNumDigit16Seg.Dot, AlphaNumDigit16Seg.Up, AlphaNumDigit16Seg.Down,AlphaNumDigit16Seg.Left, AlphaNumDigit16Seg.Right, AlphaNumDigit16Seg.DiagonalTopLeft, AlphaNumDigit16Seg.DiagonalDownRight); break;
            case '1': FullDisable(); Enable(AlphaNumDigit16Seg.RightBorderTopSide, AlphaNumDigit16Seg.RightBorderDownSide, AlphaNumDigit16Seg.DiagonalTopRight);break;
            case '2': FullDisable(); Enable(); break;
            case '3': FullDisable(); Enable(); break;
            case '4': FullDisable(); Enable(); break;
            case '5': FullDisable(); Enable(); break;
            case '6': FullDisable(); Enable(); break;
            case '7': FullDisable(); Enable(); break;
            case '8': FullDisable(); Enable(); break;
            case '9': FullDisable(); Enable(); break;
            case '$': FullDisable(); Enable(); break;
            case '*': FullDisable(); Enable(); break;
            case '+': FullDisable(); Enable(); break;
            case '`': FullDisable(); Enable(); break;
            case '´': FullDisable(); Enable(); break;
            case '{': FullDisable(); Enable(); break;
            case '}': FullDisable(); Enable(); break;
            case '[': FullDisable(); Enable(); break;
            case ']': FullDisable(); Enable(); break;
            case '-': FullDisable(); Enable(); break;
            case '.': FullDisable(); Enable(); break;
            case '/': FullDisable(); Enable(); break;
            case '\\': FullDisable(); Enable(); break;
            case '?': FullDisable(); Enable(); break;
            case '_': FullDisable(); Enable(); break;
            case '¯': FullDisable(); Enable(); break;


                    case 'A':
                        // Code for case A
                        FullDisable(); Enable();break;
                    case 'B':
                        // Code for case B
                        FullDisable(); Enable();break;
                    case 'C':
                        // Code for case C
                        FullDisable(); Enable();break;
                    case 'D':
                        // Code for case D
                        FullDisable(); Enable();break;
                    case 'E':
                        // Code for case E
                        FullDisable(); Enable();break;
                    case 'F':
                        // Code for case F
                        FullDisable(); Enable();break;
                    case 'G':
                        // Code for case G
                        FullDisable(); Enable();break;
                    case 'H':
                        // Code for case H
                        FullDisable(); Enable();break;
                    case 'I':
                        // Code for case I
                        FullDisable(); Enable();break;
                    case 'J':
                        // Code for case J
                        FullDisable(); Enable();break;
                    case 'K':
                        // Code for case K
                        FullDisable(); Enable();break;
                    case 'L':
                        // Code for case L
                        FullDisable(); Enable();break;
                    case 'M':
                        // Code for case M
                        FullDisable(); Enable();break;
                    case 'N':
                        // Code for case N
                        FullDisable(); Enable();break;
                    case 'O':
                        // Code for case O
                        FullDisable(); Enable();break;
                    case 'P':
                        // Code for case P
                        FullDisable(); Enable();break;
                    case 'Q':
                        // Code for case Q
                        FullDisable(); Enable();break;
                    case 'R':
                        // Code for case R
                        FullDisable(); Enable();break;
                    case 'S':
                        // Code for case S
                        FullDisable(); Enable();break;
                    case 'T':
                        // Code for case T
                        FullDisable(); Enable();break;
                    case 'U':
                        // Code for case U
                        FullDisable(); Enable();break;
                    case 'V':
                        // Code for case V
                        FullDisable(); Enable();break;
                    case 'W':
                        // Code for case W
                        FullDisable(); Enable();break;
                    case 'X':
                        // Code for case X
                        FullDisable(); Enable();break;
                    case 'Y':
                        // Code for case Y
                        FullDisable(); Enable();break;
                    case 'Z':
                        // Code for case Z
                        FullDisable(); Enable();break;


            default:
                break;
        }


    }

    private void Disable(params AlphaNumDigit16Seg[] toDisable)
    {
        foreach (var item in toDisable)
        {
            SetAsActive(item, false);
        }
    }
    private void Enable(params AlphaNumDigit16Seg[] toDisable)
    {
        foreach (var item in toDisable)
        {
            SetAsActive(item, true);
        }
    }
    private void SetAsActive( AlphaNumDigit16Seg toDisable, bool isActive)
    {
        switch (toDisable)
        {
            case AlphaNumDigit16Seg.Down: m_down.Invoke(isActive); break;
            case AlphaNumDigit16Seg.Left: m_left.Invoke(isActive); break;
            case AlphaNumDigit16Seg.Up: m_up.Invoke(isActive); break;
            case AlphaNumDigit16Seg.Right: m_right.Invoke(isActive); break;
            case AlphaNumDigit16Seg.DiagonalTopLeft: m_diagonalTopLeft.Invoke(isActive); break;
            case AlphaNumDigit16Seg.DiagonalTopRight: m_diagonalTopRight.Invoke(isActive); break;
            case AlphaNumDigit16Seg.DiagonalDownLeft: m_diagonalDownLeft.Invoke(isActive); break;
            case AlphaNumDigit16Seg.DiagonalDownRight: m_diagonalDownRight.Invoke(isActive); break;
            case AlphaNumDigit16Seg.TopBorderLeftSide: m_topBorderLeftSide.Invoke(isActive); break;
            case AlphaNumDigit16Seg.TopBorderRightSide: m_topBorderRightSide.Invoke(isActive); break;
            case AlphaNumDigit16Seg.DownBorderLeftSide: m_downBorderLeftSide.Invoke(isActive); break;
            case AlphaNumDigit16Seg.DownBorderrightSide: m_downBorderRightSide.Invoke(isActive); break;
            case AlphaNumDigit16Seg.LeftBorderTopSide: m_leftBorderTopSide.Invoke(isActive); break;
            case AlphaNumDigit16Seg.LeftBorderDownSide: m_leftBorderDownSide.Invoke(isActive); break;
            case AlphaNumDigit16Seg.RightBorderTopSide: m_rightBorderTopSide.Invoke(isActive); break;
            case AlphaNumDigit16Seg.RightBorderDownSide: m_rightBorderDownSide.Invoke(isActive); break;
            case AlphaNumDigit16Seg.Dot: m_dot.Invoke(isActive); break;
            default:
                break;
        }
    }

    public void FullEnable()
    {
        foreach (var item in m_all)
        {
            SetAsActive(item, true);
        }
    }

    public void FullDisable()
    {
        foreach (var item in m_all)
        {
            SetAsActive(item, false);
        }
    }

    public void SetWithInt(int digit)
    {
        int d = digit % 10;
        string t = d.ToString();
        SetWithChar(t[0]);
    }


}
