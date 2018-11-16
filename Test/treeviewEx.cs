using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public  class TreeViewEx: TreeView
    {
        public TreeViewEx()
        {
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw
            //    | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint
            //    | ControlStyles.OptimizedDoubleBuffer, true);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint
                | ControlStyles.OptimizedDoubleBuffer, true);

            UpdateStyles();


            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);

            string text = e.Node.Text;


            e.Graphics.DrawString(text, this.Font, new System.Drawing.SolidBrush( System.Drawing.Color.Black ),  e.Bounds.X +2 , e.Bounds.Y );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
