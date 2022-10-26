using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog host.
    /// </summary>
    public static class DialogHost
    {
        #region Private fields
        private static readonly DialogViewCollection DialogViews = new();
        #endregion Private fields

        #region Dependency properties
        /// <summary>
        /// Identifies the DialogView attached property.
        /// </summary>
        public static readonly DependencyProperty DialogViewsProperty =
              DependencyProperty.RegisterAttached("DialogViews", typeof(IEnumerable<DialogViewDescriptor>), typeof(DialogHost), new FrameworkPropertyMetadata(OnDialogViewsChanged));
        #endregion Dependency properties

        #region Dependency property accessors
        /// <summary>
        /// Gets the value of DialogViews attached property from specified <paramref name="dependencyObject"/>.
        /// </summary>
        /// <param name="dependencyObject">A <see cref="DependencyObject"/> to retrieve the attached property value from.</param>
        /// <returns>A <see cref="DialogViewCollection"/> that contains <see cref="DialogViewDescriptor"/> which describes the view of the dialogs.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dependencyObject"/> is <c>null</c>.</exception>
        public static DialogViewCollection GetDialogViews(DependencyObject dependencyObject)
        {
            if (dependencyObject is null)
            {
                throw new ArgumentNullException(nameof(dependencyObject));
            }

            return (DialogViewCollection)dependencyObject.GetValue(DialogViewsProperty);
        }
        /// <summary>
        /// Sets the value of DialogViews attached property to specified <paramref name="dependencyObject"/>.
        /// </summary>
        /// <param name="dependencyObject">A <see cref="DependencyObject"/> to set the attached property value to.</param>
        /// <param name="dialogViews">A <see cref="DialogViewCollection"/> that contains <see cref="DialogViewDescriptor"/> which describes the view of the dialogs.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dependencyObject"/> or <paramref name="dialogViews"/> is <c>null</c>.</exception>
        public static void SetDialogViews(DependencyObject dependencyObject, DialogViewCollection dialogViews)
        {
            if (dependencyObject is null)
            {
                throw new ArgumentNullException(nameof(dependencyObject));
            }

            if (dialogViews is null)
            {
                throw new ArgumentNullException(nameof(dialogViews));
            }

            dependencyObject.SetValue(DialogViewsProperty, dialogViews);
        }
        #endregion Dependency property accessors

        #region internal methods
        internal static DialogViewDescriptor? GetDialogView<TDialog>()
        {
            foreach (var dialogView in DialogViews)
            {
                if ((Type)dialogView.ViewTemplate.DataType == typeof(TDialog))
                {
                    return dialogView;
                }
            }

            return default;
        }
        #endregion internal methods

        #region Dependency property changed event handler
        private static void OnDialogViewsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is null)
            {
                throw new ArgumentNullException(nameof(dependencyObject));
            }

            if (args.OldValue is IEnumerable<DialogViewDescriptor> oldDialogViews)
            {
                DialogViews.RemoveRange(oldDialogViews);
            }

            if (args.NewValue is IEnumerable<DialogViewDescriptor> newDialogViews)
            {
                IEnumerable<DialogViewDescriptor> dialogViews = newDialogViews.Select(o => { o.SetAttachedObject(dependencyObject); return o; });
                DialogViews.AddRange(dialogViews);
            }
        }
        #endregion Dependency property changed event handler
    }
}
