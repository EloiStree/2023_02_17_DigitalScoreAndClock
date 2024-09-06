using System;
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
        DownBorderRightSide,
        LeftBorderTopSide,
        LeftBorderDownSide,
        RightBorderTopSide,
        RightBorderDownSide,
        Dot

    }

     AlphaNumDigit16Seg[] m_all = new AlphaNumDigit16Seg[] {
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
    AlphaNumDigit16Seg.DownBorderRightSide,
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


    public bool m_parseToUpper;
    public bool m_parseToLower;

    public void SetWithChar(string digit)
    {
        if (digit.Length > 0)
        {
            SetWithChar(digit[0]);
        }
        else SetWithChar(' ');
    }
    public void SetWithChar(char digit)
    {
        m_value = digit;
        if (m_parseToUpper)
            digit = digit.ToString().ToUpper()[0];
        if (m_parseToLower)
            digit = digit.ToString().ToLower()[0];

        switch (digit)
        {
            case '0': FullDisable(); AllBorders(true); break;
            case '1': FullDisable(); BorderRight(true); break;
            case '2': FullDisable(); HorizontalMiddle(true); AllBorders(true);
                SetAsActive(false, AlphaNumDigit16Seg.LeftBorderTopSide, AlphaNumDigit16Seg.RightBorderDownSide); break;
            case '3': FullDisable(); AllBorders(true); BorderLeft(false); SetAsActive(true, AlphaNumDigit16Seg.Right); break;
            case '4': FullDisable(); BorderRight(true); BorderLeft(true); Disable(AlphaNumDigit16Seg.LeftBorderDownSide); HorizontalMiddle(true); break;
            case '5': FullDisable(); BorderTop(true); BorderDown(true); SetAsActive(true, AlphaNumDigit16Seg.LeftBorderTopSide, AlphaNumDigit16Seg.Left, AlphaNumDigit16Seg.DiagonalDownRight); break;
            case '6': FullDisable(); Eight(true); SetAsActive(false, AlphaNumDigit16Seg.RightBorderTopSide); break;
            case '7': FullDisable(); BorderRight(true); BorderTop(true); break;
            case '8': FullDisable(); Eight(true); break;
            case '9': FullDisable(); AllBorders(); HorizontalMiddle(); SetAsActive(false, AlphaNumDigit16Seg.LeftBorderDownSide); break;
            case '$': FullDisable(); Cross();CornerTopLeft(); CornerDownRight();
                SetAsActive(true, AlphaNumDigit16Seg.DownBorderLeftSide, AlphaNumDigit16Seg.TopBorderRightSide);  break;
            case '*': FullDisable(); MultipleStar(); break;
            case '+': FullDisable(); Cross(); break;
            case '`': FullDisable(); SetAsActive(true, AlphaNumDigit16Seg.DiagonalTopLeft); break;
            case '´': FullDisable(); SetAsActive(true, AlphaNumDigit16Seg.DiagonalTopRight); break;
            case '{': FullDisable(); VerticalMiddle(); SetAsActive(true, AlphaNumDigit16Seg.TopBorderRightSide, AlphaNumDigit16Seg.DownBorderRightSide, AlphaNumDigit16Seg.Left); break;
            case '}': FullDisable(); VerticalMiddle(); SetAsActive(true, AlphaNumDigit16Seg.TopBorderLeftSide, AlphaNumDigit16Seg.DownBorderLeftSide, AlphaNumDigit16Seg.Right); break;
            case '(': case '[': FullDisable(); VerticalMiddle(); SetAsActive(true, AlphaNumDigit16Seg.TopBorderRightSide, AlphaNumDigit16Seg.DownBorderRightSide); break;
            case ')': case ']': FullDisable(); VerticalMiddle(); SetAsActive(true, AlphaNumDigit16Seg.TopBorderLeftSide, AlphaNumDigit16Seg.DownBorderLeftSide); break;
            case '-': FullDisable(); HorizontalMiddle(); break;
            case '^': FullDisable(); Enable(AlphaNumDigit16Seg.LeftBorderTopSide, AlphaNumDigit16Seg.DiagonalTopLeft); break;
            case '.': FullDisable(); SetAsActive(true, AlphaNumDigit16Seg.Dot); break;
            case ',': FullDisable(); SetAsActive(true, AlphaNumDigit16Seg.DiagonalDownLeft); break;
            case '/': FullDisable(); Slash(); break;
            case '\\': FullDisable(); Backslash(); break;
            case '?': FullDisable(); BorderTop(); Enable(AlphaNumDigit16Seg.RightBorderTopSide, AlphaNumDigit16Seg.Down, AlphaNumDigit16Seg.Right, AlphaNumDigit16Seg.Dot);  break;
            case '_': FullDisable(); BorderDown(); break;
            case '¯': FullDisable(); BorderTop(); break;
            case '=': FullDisable(); HorizontalMiddle(); BorderDown();break;
            case '!': FullDisable(); BorderRight(); SetAsActive(true, AlphaNumDigit16Seg.Dot); break;
            case '<': FullDisable(); SetAsActive(true, AlphaNumDigit16Seg.DiagonalTopRight, AlphaNumDigit16Seg.DiagonalDownRight); break;
            case '>': FullDisable(); SetAsActive(true, AlphaNumDigit16Seg.DiagonalTopLeft, AlphaNumDigit16Seg.DiagonalDownLeft); break;
            case '&': FullDisable(); Backslash(); CircleTopLeft(); CornerDownLeft(); Enable(AlphaNumDigit16Seg.DownBorderRightSide);
                Enable(AlphaNumDigit16Seg.DiagonalDownRight); Disable(AlphaNumDigit16Seg.LeftBorderTopSide); break;
            case '%': FullDisable(); Slash(); CircleTopLeft(); CircleDownRight(); break;
            case '\'': FullDisable(); SetAsActive(true, AlphaNumDigit16Seg.Up); break;
            case '"': FullDisable(); SetAsActive(true, AlphaNumDigit16Seg.Up, AlphaNumDigit16Seg.RightBorderTopSide); break;
            case '@': FullDisable(); Zero(); Disable(AlphaNumDigit16Seg.RightBorderDownSide); CircleTopRight();break;
            case 'A':
                        // Code for case A
                        FullDisable(); Eight(); BorderDown(false); break;
                    case 'B':
                        // Code for case B
                        FullDisable(); Eight(); Cross(); Disable(AlphaNumDigit16Seg.LeftBorderTopSide, AlphaNumDigit16Seg.LeftBorderDownSide, AlphaNumDigit16Seg.Left); break;
                    case 'C':
                        // Code for case C
                        FullDisable(); BorderLeft(); BorderDown(); BorderTop(); break;
                    case 'D':
                        // Code for case D
                        FullDisable(); BorderTop(); BorderDown(); VerticalMiddle(); BorderRight(); break;
                    case 'E':
                        // Code for case E
                        FullDisable(); Eight(); Cross();VerticalMiddle(false); Disable(AlphaNumDigit16Seg.RightBorderTopSide, AlphaNumDigit16Seg.RightBorderDownSide, AlphaNumDigit16Seg.Right); break;
                    case 'F':
                        // Code for case F
                        FullDisable(); BorderTop(); BorderLeft(); SetAsActive(true,AlphaNumDigit16Seg.Left); break;
                    case 'G':
                        // Code for case G
                        FullDisable(); Zero(true); SetAsActive(false, AlphaNumDigit16Seg.RightBorderTopSide); SetAsActive(true, AlphaNumDigit16Seg.Right); break;
                    case 'H':
                        // Code for case H
                        FullDisable(); Eight(true); BorderTop(false); BorderDown(false); break;
                    case 'I' :
                        // Code for case I
                        FullDisable(); BorderTop(true); BorderDown(true); VerticalMiddle(true) ;break;
                    case 'J':
                        // Code for case J
                        FullDisable(); BorderDown(); BorderRight(); SetAsActive(true, AlphaNumDigit16Seg.LeftBorderDownSide); break;
                    case 'K':
                        // Code for case K
                        FullDisable(); BorderLeft(); SetAsActive(true, AlphaNumDigit16Seg.Left, AlphaNumDigit16Seg.DiagonalTopRight, AlphaNumDigit16Seg.DiagonalDownRight); break;
                    case 'L':
                        // Code for case L
                        FullDisable(); BorderLeft(); BorderDown(); break;
                    case 'M':
                        // Code for case M
                        FullDisable(); BorderRight(); BorderLeft(); SetAsActive(true, AlphaNumDigit16Seg.DiagonalTopLeft, AlphaNumDigit16Seg.DiagonalTopRight); break;
                    case 'N':
                        // Code for case N
                        FullDisable(); BorderLeft(); BorderRight(); Backslash(); break;
                    case 'O':
                        // Code for case O
                        FullDisable(); Zero();break;
                    case 'P':
                        // Code for case P
                        FullDisable(); Eight(); BorderDown(false); SetAsActive(false,AlphaNumDigit16Seg.RightBorderDownSide); break;
                    case 'Q':
                        // Code for case Q
                        FullDisable(); Zero(); SetAsActive(true, AlphaNumDigit16Seg.DiagonalDownRight);  break;
                    case 'R':
                        // Code for case R
                        FullDisable(); BorderTop(); BorderLeft(); HorizontalMiddle();Enable(AlphaNumDigit16Seg.RightBorderTopSide, AlphaNumDigit16Seg.DiagonalDownRight); break;
                    case 'S':
                        // Code for case S
                        FullDisable(); Eight(); SetAsActive(false, AlphaNumDigit16Seg.RightBorderTopSide, AlphaNumDigit16Seg.LeftBorderDownSide); break;
                    case 'T':
                        // Code for case T
                        FullDisable(); BorderTop(); VerticalMiddle(); break;
                    case 'U':
                        // Code for case U
                        FullDisable(); Zero(); BorderTop(false); break;
                    case 'V':
                        // Code for case V
                        FullDisable(); BorderLeft(); Slash(); break;
                    case 'W':
                        // Code for case W
                        FullDisable(); BorderLeft(); BorderRight(); SetAsActive(true, AlphaNumDigit16Seg.DiagonalDownLeft, AlphaNumDigit16Seg.DiagonalDownRight); break;
                    case 'X':
                        // Code for case X
                        FullDisable(); MultipleX(); break;
                    case 'Y':
                        // Code for case Y
                        FullDisable(); Eight();SetAsActive(false, AlphaNumDigit16Seg.TopBorderLeftSide, AlphaNumDigit16Seg.TopBorderRightSide, AlphaNumDigit16Seg.LeftBorderDownSide); break;
                    case 'Z':
                        // Code for case Z
                        FullDisable(); BorderTop(); BorderDown(); Slash(); break;
        
                    case 'a': FullDisable(); CircleDownLeft();SetAsActive(true, AlphaNumDigit16Seg.DownBorderRightSide); break;
                    case 'b':FullDisable(); CircleDownLeft(); SetAsActive(true, AlphaNumDigit16Seg.LeftBorderTopSide); break;
                    case 'c':FullDisable(); CircleDownLeft(); SetAsActive(false, AlphaNumDigit16Seg.Down); break;
                    case 'd':FullDisable(); CircleDownRight(); SetAsActive(true, AlphaNumDigit16Seg.RightBorderTopSide); break;
                    case 'e':FullDisable(); CircleDownLeft(); Enable( AlphaNumDigit16Seg.DiagonalDownLeft); Disable(AlphaNumDigit16Seg.Down); break;
                    case 'f':FullDisable(); Cross(); Enable(AlphaNumDigit16Seg.TopBorderRightSide); break;
                    case 'g':FullDisable(); CircleTopLeft(); Enable(AlphaNumDigit16Seg.Down, AlphaNumDigit16Seg.DownBorderLeftSide); break;
                    case 'h':FullDisable(); BorderLeft(); Enable(AlphaNumDigit16Seg.Left, AlphaNumDigit16Seg.Down);  break;
                    case 'i':FullDisable(); Enable(AlphaNumDigit16Seg.Down); break;
                    case 'j':FullDisable(); VerticalMiddle();CornerDownLeft();  break;
                    case 'k':FullDisable(); VerticalMiddle(); Enable(AlphaNumDigit16Seg.DiagonalTopRight, AlphaNumDigit16Seg.DiagonalDownRight);  break;
                    case 'l':FullDisable(); BorderLeft();  break;
                    case 'm':FullDisable(); HorizontalMiddle();Enable(AlphaNumDigit16Seg.LeftBorderDownSide, AlphaNumDigit16Seg.RightBorderDownSide, AlphaNumDigit16Seg.Down);  break;
                    case 'n':FullDisable(); CircleDownLeft(); Disable(AlphaNumDigit16Seg.DownBorderLeftSide); break;
                    case 'o':FullDisable(); CircleDownLeft(); break;
                    case 'p':FullDisable(); CircleTopLeft(); BorderLeft(); break;
                    case 'q':FullDisable(); CircleTopLeft(); Enable(AlphaNumDigit16Seg.Down); break;
                    case 'r':FullDisable(); Enable(AlphaNumDigit16Seg.LeftBorderDownSide, AlphaNumDigit16Seg.Left); break;
                    case 's':FullDisable(); CornerTopLeft();CircleDownLeft(); Disable(AlphaNumDigit16Seg.LeftBorderDownSide); break;
                    case 't':FullDisable(); CircleDownLeft(); Enable(AlphaNumDigit16Seg.LeftBorderTopSide); Disable(AlphaNumDigit16Seg.Down); break;
                    case 'u':FullDisable(); CircleDownLeft(); Disable(AlphaNumDigit16Seg.Left);  break;
                    case 'v':FullDisable(); Enable(AlphaNumDigit16Seg.LeftBorderDownSide, AlphaNumDigit16Seg.DiagonalDownLeft); break;
                    case 'w':FullDisable(); Enable(AlphaNumDigit16Seg.LeftBorderDownSide, AlphaNumDigit16Seg.DiagonalDownLeft, AlphaNumDigit16Seg.DiagonalDownRight, AlphaNumDigit16Seg.RightBorderDownSide); break;
                    case 'x':FullDisable(); MultipleX();  break;
                    case 'y':FullDisable(); CircleTopRight(); CornerDownRight(); Disable(AlphaNumDigit16Seg.TopBorderRightSide); break;
                    case 'z': FullDisable(); Enable(AlphaNumDigit16Seg.DownBorderLeftSide, AlphaNumDigit16Seg.DiagonalDownLeft, AlphaNumDigit16Seg.Left); break;
                    case '|': FullDisable(); VerticalMiddle(); break;
                    case '≠': FullDisable(); HorizontalMiddle();Slash(); break;





            default:
                FullDisable();
                break;
        }


    }

    private void CircleDownLeft(bool v = true)
    { CornerDownLeft(v); SetAsActive(v, AlphaNumDigit16Seg.Left, AlphaNumDigit16Seg.Down); }
    private void CircleDownRight(bool v = true)
    { CornerDownRight(v); SetAsActive(v, AlphaNumDigit16Seg.Right, AlphaNumDigit16Seg.Down); }
    private void CircleTopLeft(bool v = true)
    { CornerTopLeft(v); SetAsActive(v, AlphaNumDigit16Seg.Left, AlphaNumDigit16Seg.Up); }
    private void CircleTopRight(bool v = true)
    { CornerTopRight(v); SetAsActive(v, AlphaNumDigit16Seg.Right, AlphaNumDigit16Seg.Up); }

    private void Zero(bool v=true)
    {
        AllBorders(v);
    }

    private void CornerDownRight(bool v = true)
        => SetAsActive(v, AlphaNumDigit16Seg.DownBorderRightSide, AlphaNumDigit16Seg.RightBorderDownSide);
    private void CornerDownLeft(bool v = true)
        => SetAsActive(v, AlphaNumDigit16Seg.DownBorderLeftSide, AlphaNumDigit16Seg.LeftBorderDownSide);
    private void CornerTopRight(bool v = true)
        => SetAsActive(v, AlphaNumDigit16Seg.TopBorderRightSide, AlphaNumDigit16Seg.RightBorderTopSide);
    private void CornerTopLeft(bool v = true)
        => SetAsActive(v, AlphaNumDigit16Seg.TopBorderLeftSide, AlphaNumDigit16Seg.LeftBorderTopSide);


    private void Eight(bool v = true)
    {
        AllBorders(v);
        HorizontalMiddle(v);
    }

    private void HorizontalMiddle(bool v=true)
    {
        SetAsActive(v,AlphaNumDigit16Seg.Left, AlphaNumDigit16Seg.Right);
    }

    private void Backslash(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.DiagonalTopLeft, AlphaNumDigit16Seg.DiagonalDownRight);
    }

    private void Slash(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.DiagonalDownLeft, AlphaNumDigit16Seg.DiagonalTopRight);
    }

    private void VerticalMiddle(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.Up, AlphaNumDigit16Seg.Down);

    }


    public void AllBorders(bool v = true)
    {
        BorderDown(v);
        BorderTop(v);
        BorderRight(v);
        BorderLeft(v);
    }
    private void BorderDown(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.DownBorderLeftSide, AlphaNumDigit16Seg.DownBorderRightSide);

    }

    private void BorderTop(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.TopBorderLeftSide, AlphaNumDigit16Seg.TopBorderRightSide);

    }

    private void BorderRight(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.RightBorderTopSide, AlphaNumDigit16Seg.RightBorderDownSide);
    }

    private void BorderLeft(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.LeftBorderTopSide, AlphaNumDigit16Seg.LeftBorderDownSide);
    }

    private void MultipleX(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.DiagonalTopLeft, AlphaNumDigit16Seg.DiagonalDownRight, AlphaNumDigit16Seg.DiagonalTopRight, AlphaNumDigit16Seg.DiagonalDownLeft);
    }

    private void MultipleStar(bool v = true)
    {
        MultipleX(v);
        Cross(v);
    }

    private void Cross(bool v = true)
    {
        SetAsActive(v, AlphaNumDigit16Seg.Up, AlphaNumDigit16Seg.Down, AlphaNumDigit16Seg.Left, AlphaNumDigit16Seg.Right);
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
    private void SetAsActive( bool isActiveparams,params  AlphaNumDigit16Seg[] toActivate)
    {
        foreach (var item in toActivate)
        {
            SetAsActive(item, isActiveparams);
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
            case AlphaNumDigit16Seg.DownBorderRightSide: m_downBorderRightSide.Invoke(isActive); break;
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
