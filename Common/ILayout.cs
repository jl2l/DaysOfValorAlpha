using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEditorUI
{
    /// <summary>
    /// Layouts are widgets that can contain other child widgets.
    /// </summary>
    public interface ILayout : IWidget
    {
        /// <summary>
        /// Creates a new button and adds it to the layout.
        /// </summary>
        IButton Button();
        

        /// <summary>
        /// Widget for choosing dates, similar do TextBox except with date validation built-in.
        /// </summary>
        IDateTimePicker DateTimePicker();

     
        /// <summary>
        /// Inserts a space between other widgets.
        /// </summary>
        ILayout Spacer();

        /// <summary>
        /// Creates a VerticalLayout and adds it to this layout.
        /// </summary>
        ILayout VerticalLayout();

        /// <summary>
        /// Creates a horizontal layout and adds it to this layout.
        /// </summary>
        ILayout HorizontalLayout();

        /// <summary>
        /// Whether or not to draw this layout and its sub-widgets (default is true).
        /// </summary>
        IPropertyBinding<bool, ILayout> Enabled { get; }
    }
}
