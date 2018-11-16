using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SkinForm
{
    /* 作者：Starts_2000
     * 日期：2009-09-20
     * 网站：http://www.csharpwin.com CS 程序员之窗。
     * 你可以免费使用或修改以下代码，但请保留版权信息。
     * 具体请查看 CS程序员之窗开源协议（http://www.csharpwin.com/csol.html）。
     */

    internal class ControlBoxManager : IDisposable
    {
        private SkinForm _owner;
        private bool _mouseDown;
        private ControlBoxState _closBoxState;
        private ControlBoxState _minimizeBoxState;
        private ControlBoxState _maximizeBoxState;
        private ControlBoxState _sysBottomState;

        public ControlBoxManager(SkinForm owner)
        {
            _owner = owner;
        }

        public bool CloseBoxVisibale
        {
            get { return _owner.ControlBox; }
        }

        public bool MaximizeBoxVisibale
        {
            get { return _owner.ControlBox && _owner.MaximizeBox; }
        }

        public bool MinimizeBoxVisibale
        {
            get { return _owner.ControlBox && _owner.MinimizeBox; }
        }

        public bool SysBottomVisibale
        {
            get 
            {
                SkinPictureForm f = _owner as SkinPictureForm;
                if( f==null ) return false;
                return f.SysBottomVisibale; 
            }
        }

        public Rectangle CloseBoxRect
        {
            get
            {
                if (CloseBoxVisibale)
                {
                    Point offset = ControlBoxOffset;
                    Size size = _owner.CloseBoxSize;
                    return new Rectangle(
                        _owner.Width - offset.X - size.Width,
                        offset.Y,
                        size.Width,
                        size.Height);
                }
                return Rectangle.Empty;
            }
        }

        public Rectangle MaximizeBoxRect
        {
            get
            {
                if (MaximizeBoxVisibale)
                {
                    Point offset = ControlBoxOffset;
                    Size size = _owner.MaximizeBoxSize;
                    return new Rectangle(
                        CloseBoxRect.X - ControlBoxSpace - size.Width,
                        offset.Y,
                        size.Width,
                        size.Height);
                }
                return Rectangle.Empty;
            }
        }

        public Rectangle MinimizeBoxRect
        {
            get
            {
                if (MinimizeBoxVisibale)
                {
                    Point offset = ControlBoxOffset;
                    Size size = _owner.MinimizeBoxSize;
                    int x = MaximizeBoxVisibale ?
                        MaximizeBoxRect.X - ControlBoxSpace -  size.Width:
                        CloseBoxRect.X - ControlBoxSpace - size.Width;
                    return new Rectangle(
                        x,
                        offset.Y,
                        size.Width,
                        size.Height);
                }
                return Rectangle.Empty;
            }
        }

        public Rectangle SysBottomRect
        {
            get
            {
                if (this.SysBottomVisibale)
                {
                    Point controlBoxOffset = this.ControlBoxOffset;
                    Size sysBottomSize = ((SkinPictureForm) this._owner).SysBottomSize;
                    return new Rectangle(this.MinimizeBoxVisibale ? ((this.MinimizeBoxRect.X - this.ControlBoxSpace) - sysBottomSize.Width) : (this.MaximizeBoxVisibale ? ((this.MaximizeBoxRect.X - this.ControlBoxSpace) - sysBottomSize.Width) : ((this.CloseBoxRect.X - this.ControlBoxSpace) - sysBottomSize.Width)), controlBoxOffset.Y, sysBottomSize.Width, sysBottomSize.Height);
                }
                return Rectangle.Empty;
            }
        }

        public ControlBoxState CloseBoxState
        {
            get { return _closBoxState; }
            protected set
            {
                if (_closBoxState != value)
                {
                    _closBoxState = value;
                    if (_owner != null)
                    {
                        Invalidate(CloseBoxRect);
                    }
                }
            }
        }

        public ControlBoxState MinimizeBoxState
        {
            get { return _minimizeBoxState; }
            protected set
            {
                if (_minimizeBoxState != value)
                {
                    _minimizeBoxState = value;
                    if (_owner != null)
                    {
                        Invalidate(MinimizeBoxRect);
                    }
                }
            }
        }

        public ControlBoxState MaximizeBoxState
        {
            get { return _maximizeBoxState; }
            protected set
            {
                if (_maximizeBoxState != value)
                {
                    _maximizeBoxState = value;
                    if (_owner != null)
                    {
                        Invalidate(MaximizeBoxRect);
                    }
                }
            }
        }

        public ControlBoxState SysBottomState
        {
            get
            {
                return this._sysBottomState;
            }
            protected set
            {
                if (this._sysBottomState != value)
                {
                    this._sysBottomState = value;
                    if (this._owner != null)
                    {
                        this.Invalidate(this.SysBottomRect);
                    }
                }
            }
        }

        internal Point ControlBoxOffset
        {
            get { return _owner.ControlBoxOffset; }
        }

        internal int ControlBoxSpace
        {
            get { return _owner.ControlBoxSpace; }
        }

        public void ProcessMouseOperate(
            Point mousePoint, MouseOperate operate)
        {
            if (!_owner.ControlBox)
            {
                return;
            }

            Rectangle closeBoxRect = CloseBoxRect;
            Rectangle minimizeBoxRect = MinimizeBoxRect;
            Rectangle maximizeBoxRect = MaximizeBoxRect;
            Rectangle sysBottomRect = SysBottomRect;

            bool closeBoxVisibale = CloseBoxVisibale;
            bool minimizeBoxVisibale = MinimizeBoxVisibale;
            bool maximizeBoxVisibale = MaximizeBoxVisibale;
            bool sysBottmVisibale = SysBottomVisibale;

            switch (operate)
            {
                case MouseOperate.Move:
                    ProcessMouseMove(
                        mousePoint,
                        closeBoxRect,
                        minimizeBoxRect,
                        maximizeBoxRect,
                        sysBottomRect,
                        closeBoxVisibale,
                        minimizeBoxVisibale,
                        maximizeBoxVisibale,
                        sysBottmVisibale);
                    break;
                case MouseOperate.Down:
                    ProcessMouseDown(
                        mousePoint,
                        closeBoxRect,
                        minimizeBoxRect,
                        maximizeBoxRect,
                        sysBottomRect,
                        closeBoxVisibale,                        
                        minimizeBoxVisibale,
                        maximizeBoxVisibale,
                        sysBottmVisibale);
                    break;
                case MouseOperate.Up:
                    ProcessMouseUP(
                        mousePoint,
                        closeBoxRect,
                        minimizeBoxRect,
                        maximizeBoxRect,
                        sysBottomRect,
                        closeBoxVisibale,
                        minimizeBoxVisibale,
                        maximizeBoxVisibale,
                        sysBottmVisibale);
                    break;
                case MouseOperate.Leave:
                    ProcessMouseLeave(
                        closeBoxVisibale,
                        minimizeBoxVisibale,
                        maximizeBoxVisibale,
                        sysBottmVisibale);
                    break;
                case MouseOperate.Hover:
                    break;
            }
        }

        private void ProcessMouseMove(
            Point mousePoint,
            Rectangle closeBoxRect,
            Rectangle minimizeBoxRect,
            Rectangle maximizeBoxRect,
            Rectangle sysBottomRect,
            bool closeBoxVisibale,
            bool minimizeBoxVisibale,
            bool maximizeBoxVisibale,
            bool sysBottmVisibale)
        {
            string toolTip = string.Empty;
            bool hide = true;
            if (closeBoxVisibale)
            {
                if (closeBoxRect.Contains(mousePoint))
                {
                    hide = false;
                    if (!_mouseDown)
                    {
                        if (CloseBoxState != ControlBoxState.Hover)
                        {
                            toolTip = "关闭";
                        }
                        CloseBoxState = ControlBoxState.Hover;
                    }
                    else
                    {
                        if (CloseBoxState == ControlBoxState.PressedLeave)
                        {
                            CloseBoxState = ControlBoxState.Pressed;
                        }
                    }
                }
                else
                {
                    if (!_mouseDown)
                    {
                        CloseBoxState = ControlBoxState.Normal;
                    }
                    else
                    {
                        if (CloseBoxState == ControlBoxState.Pressed)
                        {
                            CloseBoxState = ControlBoxState.PressedLeave;
                        }
                    }
                }
            }

            if (minimizeBoxVisibale)
            {
                if (minimizeBoxRect.Contains(mousePoint))
                {
                    hide = false;
                    if (!_mouseDown)
                    {
                        if (MinimizeBoxState != ControlBoxState.Hover)
                        {
                            toolTip = "最小化";
                        }
                        MinimizeBoxState = ControlBoxState.Hover;
                    }
                    else
                    {
                        if (MinimizeBoxState == ControlBoxState.PressedLeave)
                        {
                            MinimizeBoxState = ControlBoxState.Pressed;
                        }
                    }
                }
                else
                {
                    if (!_mouseDown)
                    {
                        MinimizeBoxState = ControlBoxState.Normal;
                    }
                    else
                    {
                        if (MinimizeBoxState == ControlBoxState.Pressed)
                        {
                            MinimizeBoxState = ControlBoxState.PressedLeave;
                        }
                    }
                }
            }

            if (maximizeBoxVisibale)
            {
                if (maximizeBoxRect.Contains(mousePoint))
                {
                    hide = false;
                    if (!_mouseDown)
                    {
                        if (MaximizeBoxState != ControlBoxState.Hover)
                        {
                            bool maximize = 
                                _owner.WindowState == FormWindowState.Maximized;
                            toolTip = maximize ? "还原" : "最大化";
                        }
                        MaximizeBoxState = ControlBoxState.Hover;
                    }
                    else
                    {
                        if (MaximizeBoxState == ControlBoxState.PressedLeave)
                        {
                            MaximizeBoxState = ControlBoxState.Pressed;
                        }
                    }
                }
                else
                {
                    if (!_mouseDown)
                    {
                        MaximizeBoxState = ControlBoxState.Normal;
                    }
                    else
                    {
                        if (MaximizeBoxState == ControlBoxState.Pressed)
                        {
                            MaximizeBoxState = ControlBoxState.PressedLeave;
                        }
                    }
                }
            }
            if (SysBottomVisibale)
            {
                if (sysBottomRect.Contains(mousePoint))
                {
                    hide = false;
                    if (!this._mouseDown)
                    {
                        if (this.SysBottomState != ControlBoxState.Hover)
                        {
                            toolTip = ((SkinPictureForm) this._owner).SysBottomToolTip;
                        }
                        this.SysBottomState = ControlBoxState.Hover;
                    }
                    else if (this.SysBottomState == ControlBoxState.PressedLeave)
                    {
                        this.SysBottomState = ControlBoxState.Pressed;
                    }
                }
                else if (!this._mouseDown)
                {
                    this.SysBottomState = ControlBoxState.Normal;
                }
                else if (this.SysBottomState == ControlBoxState.Pressed)
                {
                    this.SysBottomState = ControlBoxState.PressedLeave;
                }
            }

            if (toolTip != string.Empty)
            {
                HideToolTip();
                ShowTooTip(toolTip);
            }

            if (hide)
            {
                HideToolTip();
            }
        }

        private void ProcessMouseDown(
            Point mousePoint,
            Rectangle closeBoxRect,
            Rectangle minimizeBoxRect,
            Rectangle maximizeBoxRect,
            Rectangle sysBottomRect,
            bool closeBoxVisibale,
            bool minimizeBoxVisibale,
            bool maximizeBoxVisibale,
            bool sysBottomVisibale)
        {
            _mouseDown = true;

            if (closeBoxVisibale)
            {
                if (closeBoxRect.Contains(mousePoint))
                {
                    CloseBoxState = ControlBoxState.Pressed;
                    return;
                }
            }

            if (minimizeBoxVisibale)
            {
                if (minimizeBoxRect.Contains(mousePoint))
                {
                    MinimizeBoxState = ControlBoxState.Pressed;
                    return;
                }
            }

            if (maximizeBoxVisibale)
            {
                if (maximizeBoxRect.Contains(mousePoint))
                {
                    MaximizeBoxState = ControlBoxState.Pressed;
                    return;
                }
            }

            if (sysBottomVisibale)
            {
                if (sysBottomRect.Contains(mousePoint))
                {
                    SysBottomState = ControlBoxState.Pressed;
                    return;
                }
            }
        }

        private void ProcessMouseUP(
            Point mousePoint, 
            Rectangle closeBoxRect,
            Rectangle minimizeBoxRect,
            Rectangle maximizeBoxRect, 
            Rectangle sysBottomRect,
            bool closeBoxVisibale, 
            bool minimizeBoxVisibale, 
            bool maximizeBoxVisibale,
            bool sysBottmVisibale )
        {
            _mouseDown = false;

            if (closeBoxVisibale)
            {
                if (closeBoxRect.Contains(mousePoint))
                {
                    if (CloseBoxState == ControlBoxState.Pressed)
                    {
                        _owner.Close();
                        CloseBoxState = ControlBoxState.Normal;
                        return;
                    }
                }
                CloseBoxState = ControlBoxState.Normal;
            }

            if (minimizeBoxVisibale)
            {
                if (minimizeBoxRect.Contains(mousePoint))
                {
                    if (MinimizeBoxState == ControlBoxState.Pressed)
                    {
                        _owner.WindowState = FormWindowState.Minimized;
                        MinimizeBoxState = ControlBoxState.Normal;
                        return;
                    }
                }
                MinimizeBoxState = ControlBoxState.Normal;
            }

            if (maximizeBoxVisibale)
            {
                if (maximizeBoxRect.Contains(mousePoint))
                {
                    if (MaximizeBoxState == ControlBoxState.Pressed)
                    {
                        bool maximize =
                            _owner.WindowState == FormWindowState.Maximized;
                        if (maximize)
                        {
                            _owner.WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            _owner.WindowState = FormWindowState.Maximized;
                        }

                        MaximizeBoxState = ControlBoxState.Normal;
                        return;
                    }
                }
                MaximizeBoxState = ControlBoxState.Normal;
            }

            if (sysBottmVisibale)
            {
                if (sysBottomRect.Contains(mousePoint) && (this.SysBottomState == ControlBoxState.Pressed))
                {
                    ((SkinPictureForm)this._owner).SysbottomAv(this._owner);
                    this.SysBottomState = ControlBoxState.Normal;
                    return;
                }
                this.SysBottomState = ControlBoxState.Normal;
            }
        }

        private void ProcessMouseLeave(
            bool closeBoxVisibale,
            bool minimizeBoxVisibale,
            bool maximizeBoxVisibale,
            bool sysBottomVisibale )
        {
            if (closeBoxVisibale)
            {
                if (CloseBoxState == ControlBoxState.Pressed)
                {
                    CloseBoxState = ControlBoxState.PressedLeave;
                }
                else
                {
                    CloseBoxState = ControlBoxState.Normal;
                }
            }

            if (minimizeBoxVisibale)
            {
                if (MinimizeBoxState == ControlBoxState.Pressed)
                {
                    MinimizeBoxState = ControlBoxState.PressedLeave;
                }
                else
                {
                    MinimizeBoxState = ControlBoxState.Normal;
                }
            }

            if (maximizeBoxVisibale)
            {
                if (MaximizeBoxState == ControlBoxState.Pressed)
                {
                    MaximizeBoxState = ControlBoxState.PressedLeave;
                }
                else
                {
                    MaximizeBoxState = ControlBoxState.Normal;
                }
            }

            if (sysBottomVisibale)
            {
                if (this.SysBottomState == ControlBoxState.Pressed)
                {
                    this.SysBottomState = ControlBoxState.PressedLeave;
                }
                else
                {
                    this.SysBottomState = ControlBoxState.Normal;
                }
            }

            HideToolTip();
        }

        private void Invalidate(Rectangle rect)
        {
            _owner.Invalidate(rect);
        }

        private void ShowTooTip(string toolTipText)
        {
            if (_owner != null)
            {
                _owner.ToolTip.Active = true;
                _owner.ToolTip.SetToolTip(_owner, toolTipText);
            }
        }

        private void HideToolTip()
        {
            if (_owner != null)
            {
                _owner.ToolTip.Active = false;
            }
        }

        #region IDisposable 成员

        public void Dispose()
        {
            _owner = null;
        }

        #endregion
    }
}
