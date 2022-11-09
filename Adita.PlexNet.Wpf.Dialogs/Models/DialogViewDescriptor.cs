using System;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog view descriptor.
    /// </summary>
    public class DialogViewDescriptor : DependencyObject
    {
        private DependencyObject _attachedObject;

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogViewDescriptor"/> using specified <paramref name="attachedObject"/> and <paramref name="dataTemplate"/>.
        /// </summary>
        /// <param name="attachedObject">A <see cref="DependencyObject"/> where the view was attached.</param>
        /// <param name="dataTemplate">A <see cref="DataTemplate"/> to use for the view.</param>
        public DialogViewDescriptor(DependencyObject attachedObject, DataTemplate dataTemplate)
        {
            _attachedObject = attachedObject;
            ViewTemplate = dataTemplate;
        }
        #endregion Constructors

        #region Dependency properties
        /// <summary>
        /// Identifies the <see cref="ViewTemplate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ViewTemplateProperty =
            DependencyProperty.Register(nameof(ViewTemplate), typeof(DataTemplate), typeof(DialogViewDescriptor), new FrameworkPropertyMetadata(new DataTemplate()));
        #endregion Dependency properties

        #region Public properties
        /// <summary>
        /// Gets the target <see cref="Type"/> of current <see cref="DialogViewDescriptor"/>.
        /// </summary>
        public Type TargetType
        {
            get { return (Type)ViewTemplate.DataType; }
        }
        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> of the dialog view.
        /// </summary>
        public DataTemplate ViewTemplate
        {
            get { return (DataTemplate)GetValue(ViewTemplateProperty); }
            set { SetValue(ViewTemplateProperty, value); }
        }
        #endregion Public properties

        #region Public methods
        /// <summary>
        /// Gets the <see cref="DependencyObject"/> that attached to current <see cref="DialogViewDescriptor"/>.
        /// </summary>
        /// <returns>The attached <see cref="DependencyObject"/>.</returns>
        public DependencyObject GetAttachedObject()
        {
            return _attachedObject;
        }
        /// <summary>
        /// Gets the <see cref="Window"/> that owns current <see cref="DialogViewDescriptor"/>.
        /// </summary>
        /// <returns>The <see cref="Window"/> that owns current <see cref="DialogViewDescriptor"/>.</returns>
        public Window GetOwner()
        {
            return Window.GetWindow(_attachedObject);
        }
        #endregion Public methods
    }
}
