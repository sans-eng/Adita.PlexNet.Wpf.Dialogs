using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static readonly DialogViewCollection _viewDescriptors = new();
        #endregion Private fields

        #region Dependency properties

        /// <summary>
        /// Identifies the ViewTemplates attached property.
        /// </summary>
        public static readonly DependencyProperty ViewTemplatesProperty =
              DependencyProperty.RegisterAttached("ViewTemplates", typeof(ViewTemplateCollection), typeof(DialogHost), new FrameworkPropertyMetadata(new ViewTemplateCollection(), OnViewTemplatesChanged));
        #endregion Dependency properties

        #region Dependency property accessors
        /// <summary>
        /// Gets the value of ViewTemplates attached property from specified <paramref name="dependencyObject"/>.
        /// </summary>
        /// <param name="dependencyObject">A <see cref="DependencyObject"/> to retrieve the attached property value from.</param>
        /// <returns>A <see cref="ViewTemplateCollection"/> for dialogs.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="dependencyObject"/> is <c>null</c>.</exception>
        public static ViewTemplateCollection GetViewTemplates(DependencyObject dependencyObject)
        {
            if (dependencyObject is null)
            {
                throw new ArgumentNullException(nameof(dependencyObject));
            }

            return (ViewTemplateCollection)dependencyObject.GetValue(ViewTemplatesProperty);
        }
        /// <summary>
        /// Sets the value of ViewTemplates attached property to specified <paramref name="dependencyObject"/>.
        /// </summary>
        /// <param name="dependencyObject">A <see cref="DependencyObject"/> to set the attached property value to.</param>
        /// <param name="viewTemplates">A <see cref="ViewTemplateCollection"/> for dialogs.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dependencyObject"/> or <paramref name="viewTemplates"/> is <c>null</c>.</exception>
        public static void SetViewTemplates(DependencyObject dependencyObject, ViewTemplateCollection viewTemplates)
        {
            if (dependencyObject is null)
            {
                throw new ArgumentNullException(nameof(dependencyObject));
            }

            if (viewTemplates is null)
            {
                throw new ArgumentNullException(nameof(viewTemplates));
            }

            dependencyObject.SetValue(ViewTemplatesProperty, viewTemplates);
        }
        #endregion Dependency property accessors

        #region internal methods
        internal static DataTemplate? GetDialogView<TDialog>()
        {
            foreach (var descriptor in _viewDescriptors)
            {
                if (descriptor.TargetType == typeof(TDialog) && descriptor.GetOwner().IsActive)
                {
                    return descriptor.ViewTemplate;
                }
            }

            return default;
        }
        #endregion internal methods

        #region Dependency property changed event handlers
        private static void OnViewTemplatesChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue is ViewTemplateCollection oldTemplates)
            {
                foreach (var oldTemplate in oldTemplates)
                {
                    var foundTemplatesDescriptor = _viewDescriptors.Where(o => o.GetAttachedObject() == dependencyObject && o.TargetType == oldTemplate.DataType as Type);
                    _viewDescriptors.RemoveRange(foundTemplatesDescriptor);
                }
            }

            if (args.NewValue is ViewTemplateCollection newTemplates)
            {
                foreach (var newTemplate in newTemplates)
                {
                    DialogViewDescriptor descriptor = new(dependencyObject, newTemplate);

                    if (_viewDescriptors.Any(o => o.GetOwner() == descriptor.GetOwner() && o.TargetType == newTemplate.DataType as Type))
                    {
                        throw new ArgumentException($"The {nameof(DataTemplate)} with same {nameof(DataTemplate.DataType)} already registered to target {nameof(Window)}.");
                    }

                    _viewDescriptors.Add(descriptor);
                }
            }
        }
        #endregion Dependency property changed event handlers
    }
}
