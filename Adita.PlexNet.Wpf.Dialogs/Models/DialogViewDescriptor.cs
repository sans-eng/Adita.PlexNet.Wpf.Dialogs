using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog view descriptor.
    /// </summary>
    public class DialogViewDescriptor : DependencyObject
    {
        #region Private fields
        private DependencyObject? _attachedObject;
        #endregion Private fields

        #region Constructors
        /// <summary>
        /// Initialize a new instance of <see cref="DialogViewDescriptor"/>.
        /// </summary>
        public DialogViewDescriptor() { }
        /// <summary>
        /// Initialize a new instance of <see cref="DialogViewDescriptor"/> which attached on specified <paramref name="attachedObject"/>.
        /// </summary>
        /// <param name="attachedObject">A <see cref="DependencyObject"/> where the <see cref="DialogViewDescriptor"/> is attached to.</param>
        public DialogViewDescriptor(Window attachedObject)
        {
            _attachedObject = attachedObject;
        }
        #endregion Constructors

        #region Dependency properties
        /// <summary>
        /// Identifies the <see cref="ViewTemplate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ViewTemplateProperty =
            DependencyProperty.Register(nameof(ViewTemplate), typeof(DataTemplate), typeof(DialogViewDescriptor), new FrameworkPropertyMetadata(new DataTemplate(), OnViewTemplateChanged));

        /// <summary>
        /// Identifies the <see cref="ContainerStyle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DialogStyleProperty =
            DependencyProperty.Register(nameof(ContainerStyle), typeof(Style), typeof(DialogViewDescriptor), new FrameworkPropertyMetadata(new Style(typeof(Window)), OnContainerStyleChanged));
        #endregion Dependency properties

        #region Public properties
        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> of the dialog view.
        /// </summary>
        public DataTemplate ViewTemplate
        {
            get { return (DataTemplate)GetValue(ViewTemplateProperty); }
            set { SetValue(ViewTemplateProperty, value); }
        }
        /// <summary>
        /// Gets or sets the <see cref="Style"/> of the dialog container.
        /// </summary>
        public Style ContainerStyle
        {
            get { return (Style)GetValue(DialogStyleProperty); }
            set { SetValue(DialogStyleProperty, value); }
        }
        #endregion Public properties

        #region public methods
        /// <summary>
        /// Sets the attached <see cref="DependencyObject"/> of current <see cref="DialogViewDescriptor"/>. 
        /// </summary>
        /// <param name="dependencyObject">The <see cref="DependencyObject"/> where current <see cref="DialogViewDescriptor"/> is attached to.</param>
        public void SetAttachedObject(DependencyObject dependencyObject)
        {
            _attachedObject = dependencyObject;
        }
        /// <summary>
        /// Gets the <see cref="Window"/> that owns the dialog.
        /// </summary>
        /// <returns>The <see cref="Window"/> that owns the dialog.</returns>
        public Window GetOwner()
        {
            return _attachedObject is Window window ? window : Window.GetWindow(_attachedObject);
        }
        #endregion public methods

        #region Dependency property changed handlers
        private static void OnViewTemplateChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is null)
            {
                throw new ArgumentNullException(nameof(dependencyObject));
            }

            if (args.NewValue is not DataTemplate viewTemplate)
            {
                throw new ArgumentException($"The {nameof(ViewTemplate)} is null.");
            }
        }
        private static void OnContainerStyleChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is null)
            {
                throw new ArgumentNullException(nameof(dependencyObject));
            }

            if(args.NewValue is not Style containerStyle)
            {
                throw new ArgumentException($"The {nameof(ContainerStyle)} is null.");
            }

            if(containerStyle.TargetType != typeof(Window))
            {
                throw new ArgumentException($"The {nameof(Style.TargetType)} of {nameof(ContainerStyle)} is not {nameof(Window)}");
            }
        }
        #endregion Dependency property changed handlers
    }
}
