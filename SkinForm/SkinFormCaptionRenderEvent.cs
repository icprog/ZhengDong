using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SkinForm
{
    /* 作者：Starts_2000
     * 日期：2009-09-20
     * 网站：http://www.csharpwin.com CS 程序员之窗。
     * 你可以免费使用或修改以下代码，但请保留版权信息。
     * 具体请查看 CS程序员之窗开源协议（http://www.csharpwin.com/csol.html）。
     */

    public delegate void SkinFormCaptionRenderEventHandler(
        object sender,
        SkinFormCaptionRenderEventArgs e);

    public class SkinFormCaptionRenderEventArgs : PaintEventArgs
    {
        private SkinForm _skinForm;
        private bool _active;
        private Color _backColor =Color.Transparent;
        private Image _backImage = null;

        public SkinFormCaptionRenderEventArgs(
            SkinForm skinForm,
            Graphics g,
            Rectangle clipRect,
            bool active)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
            _active = active;
            _backColor = Color.Transparent;
        }

        public SkinFormCaptionRenderEventArgs(
            SkinForm skinForm,
            Graphics g,
            Rectangle clipRect,
            Color backcolor ,
            Image backImage,
            bool active)
            : base(g, clipRect)
        {
            _skinForm = skinForm;
            _active = active;
            _backColor = backcolor;
            _backImage = backImage;
        }

        public SkinForm SkinForm
        {
            get { return _skinForm; }
        }

        public bool Active
        {
            get { return _active; }
        }
        public Color BackColor
        {
            get { return _backColor; }
        }
        public Image BackImage
        {
            get { return _backImage; }
        }
    }
}
