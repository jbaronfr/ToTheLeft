namespace ToTheLeft
{
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Utilities;

    [Export(typeof(IMouseProcessorProvider))]
    [Name("ToTheLeft")]
    [ContentType("text")]             
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class ToTheLeftFactory : IMouseProcessorProvider
    {
        IMouseProcessor IMouseProcessorProvider.GetAssociatedProcessor(IWpfTextView textView)
        {
            return AlignOnScroll.Create(textView);
        }
    }
}
