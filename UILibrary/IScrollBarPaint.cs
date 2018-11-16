namespace UILibrary
{
    using System;
    using TCEventArgs;

    public interface IScrollBarPaint
    {
        void OnPaintScrollBarArrow(PaintScrollBarArrowEventArgs e);
        void OnPaintScrollBarThumb(PaintScrollBarThumbEventArgs e);
        void OnPaintScrollBarTrack(PaintScrollBarTrackEventArgs e);
    }
}

