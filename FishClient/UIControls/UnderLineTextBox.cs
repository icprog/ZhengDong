using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FishClient.UIControls
{
   public   class UnderLineTextBox : TextBox
    {
       private int _underlineWidth = 1;
       public int UndrelineWidth
       {
           get { return _underlineWidth; }
           set
           {
               if (_underlineWidth == value) return;
               _underlineWidth = value;
               this.Invalidate();
           }
       }
       private Color _underlineColor = Color.Black;
       public Color UnderlineColor
       {
           get { return _underlineColor; }
           set
           {
               if (value == _underlineColor) return;
               _underlineColor = value; 
               this.Invalidate();
           }
       }

       public UnderLineTextBox()
       {
           this.BorderStyle = System.Windows.Forms.BorderStyle.None;           
       }

       protected override void OnPaint(PaintEventArgs e)
       {

           base.OnPaint(e);

           DrawUnderLine(e.Graphics, e.ClipRectangle);
       }

       protected void DrawUnderLine( Graphics g ,Rectangle clientRect)
       {
           using( Pen p = new Pen( _underlineColor ))
           {
               Point start =new Point( clientRect.Left ,clientRect.Bottom- _underlineWidth-5 );
               Point end = new Point(clientRect.Right , clientRect.Bottom-_underlineWidth-5 );
               g.DrawLine(p, start, end);
           }
       }
    }
}
