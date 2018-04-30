namespace ToTheLeft
{
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Formatting;
    using System;
    using System.Linq;
    using System.Windows.Input;

    class AlignOnScroll : MouseProcessorBase
    {
        public static IMouseProcessor Create(IWpfTextView view)
        {
            return view.Properties.GetOrCreateSingletonProperty(delegate ()
            {
                return new AlignOnScroll(view);
            });
        }

        private IWpfTextView _view;

        private AlignOnScroll(IWpfTextView view)
        {
            _view = view;
        }

        public override void PostprocessMouseWheel(MouseWheelEventArgs e)
        {
            if ((!_view.IsClosed) && _view.VisualElement.IsVisible)
            {
                double minindent = double.MaxValue;
                foreach (var line in _view.TextViewLines.Where(l => l.VisibilityState == VisibilityState.FullyVisible))
                {
                    string txtline = line.Extent.GetText();

                    if (!string.IsNullOrWhiteSpace(txtline))
                    {

                        int nWhite = txtline.TakeWhile(Char.IsWhiteSpace).Count();

                        var widthwhite = nWhite * line.Width / txtline.Length;

                        if (minindent > widthwhite)
                        {
                            minindent = widthwhite;
                        }

                    }

                }
                double scrollpx = minindent - _view.ViewportLeft;
                _view.ViewScroller.ScrollViewportHorizontallyByPixels(scrollpx);

            }
        }
    }
}
