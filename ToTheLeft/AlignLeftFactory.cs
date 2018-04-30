namespace ToTheLeft
{
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Utilities;

    /// <summary>
    /// Export a <see cref="IWpfTextViewMarginProvider"/>, which returns an instance of the margin for the editor to use.
    /// </summary>
    [Export(typeof(IMouseProcessorProvider))]
    [ContentType("text")]             
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    internal sealed class AlignLeftFactory : IMouseProcessorProvider
    {
        IMouseProcessor IMouseProcessorProvider.GetAssociatedProcessor(IWpfTextView textView)
        {
            return AlignOnScroll.Create(textView);
        }
    }
}
