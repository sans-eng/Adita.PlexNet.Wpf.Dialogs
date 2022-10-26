using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a dialog view collection.
    /// </summary>
    public sealed class DialogViewCollection : Collection<DialogViewDescriptor>   
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogViewCollection"/> class that is empty.
        /// </summary>
        public DialogViewCollection() { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="DialogViewCollection"/> class as a wrapper for the specified list.
        /// </summary>
        /// <param name="list">The list that is wrapped by the new collection.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <c>null</c>.</exception>
        public DialogViewCollection(IList<DialogViewDescriptor> list) : base(list) { }
        #endregion Constructors

        #region Public methods
        /// <summary>
        /// Adds specified <paramref name="items"/> to current <see cref="DialogViewCollection"/>.
        /// </summary>
        /// <param name="items">The <see cref="DialogViewDescriptor"/>s to add to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is <c>null</c>.</exception>
        /// <exception cref="NotSupportedException">The <see cref="DialogViewCollection" /> is read-only.</exception>
        public void AddRange(IEnumerable<DialogViewDescriptor> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (Items.IsReadOnly)
            {
                throw new NotSupportedException($"The {nameof(DialogViewCollection)} is read-only.");
            }

            foreach (var dialogView in items)
            {
                Add(dialogView);
            }
        }
        /// <summary>
        /// Gets all the <see cref="DialogViewDescriptor"/> that belongs to specified <paramref name="owner"/> from current <see cref="DialogViewCollection"/>.
        /// </summary>
        /// <param name="owner">The owner's of <see cref="DialogViewDescriptor"/>.</param>
        /// <returns>A <see cref="DialogViewCollection"/> that contains <see cref="DialogViewDescriptor"/> which belongs to specified <paramref name="owner"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="owner"/> is <c>null</c>.</exception>
        public DialogViewCollection GetByOwner(Window owner)
        {
            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            return new DialogViewCollection(Items.Where(p => p.GetOwner() == owner).ToList());
        }
        /// <summary>
        /// Removes all the <see cref="DialogViewDescriptor" /> which belongs to specified <paramref name="owner"/> from the current <see cref="DialogViewCollection"/>.
        /// </summary>
        /// <param name="owner">The owner's of <see cref="DialogViewDescriptor"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="owner"/> is <c>null</c>.</exception>
        /// <exception cref="NotSupportedException">The <see cref="DialogViewCollection" /> is read-only.</exception>
        public void RemoveByOwner(Window owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            try
            {
                IEnumerable<DialogViewDescriptor> foundItems = Items.Where(p => p.GetOwner() == owner);
                foreach (var foundItem in foundItems)
                {
                    Remove(foundItem);
                }
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException($"The {nameof(DialogViewCollection)} is read-only.");
            }
        }
        /// <summary>
        /// Removes specified <paramref name="items"/> from current <see cref="DialogViewCollection"/>.
        /// </summary>
        /// <param name="items">The <see cref="DialogViewDescriptor"/>s to remove from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is <c>null</c>.</exception>
        /// <exception cref="NotSupportedException">The <see cref="DialogViewCollection" /> is read-only.</exception>
        public void RemoveRange(IEnumerable<DialogViewDescriptor> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            try
            {
                foreach (var item in items)
                {
                    Items.Remove(item);
                }
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException($"The {nameof(DialogViewCollection)} is read-only.");
            }
        }
        #endregion Public methods
    }
}
