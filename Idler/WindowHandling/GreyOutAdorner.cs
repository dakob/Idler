using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Idler.UIAdorners
{
    public class GreyOutAdorner : Adorner
    {
        public GreyOutAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            SolidColorBrush sr = new SolidColorBrush();
            sr.Color = Colors.Black;
            sr.Opacity = 0.5;
            drawingContext.DrawRectangle(sr, null, new Rect(new Point(0, 0), DesiredSize));
            base.OnRender(drawingContext);
        }

    }
}
