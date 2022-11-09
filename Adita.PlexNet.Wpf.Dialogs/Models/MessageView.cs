using Adita.PlexNet.Core.Dialogs;
using Adita.PlexNet.Wpf.Media;
using System.Windows;
using System.Windows.Controls;

namespace Adita.PlexNet.Wpf.Dialogs
{
    /// <summary>
    /// Represents a message view.
    /// </summary>
    [TemplatePart(Name = OkButtonName, Type = typeof(Button))]
    [TemplatePart(Name = CancelButtonName, Type = typeof(Button))]
    [TemplatePart(Name = YesButtonName, Type = typeof(Button))]
    [TemplatePart(Name = NoButtonName, Type = typeof(Button))]
    [TemplatePart(Name = AbortButtonName, Type = typeof(Button))]
    [TemplatePart(Name = IgnoreButtonName, Type = typeof(Button))]
    [TemplatePart(Name = InfoIconName, Type = typeof(Image))]
    [TemplatePart(Name = QuestionIconName, Type = typeof(Image))]
    [TemplatePart(Name = WarningIconName, Type = typeof(Image))]
    [TemplatePart(Name = ErrorIconName, Type = typeof(Image))]
    public class MessageView : Control, IMessageView
    {
        #region Private constants
        private const string OkButtonName = "PART_Ok";
        private const string CancelButtonName = "PART_Cancel";
        private const string YesButtonName = "PART_Yes";
        private const string NoButtonName = "PART_No";
        private const string AbortButtonName = "PART_Abort";
        private const string IgnoreButtonName = "PART_Ignore";

        private const string InfoIconName = "PART_InfoIcon";
        private const string QuestionIconName = "PART_QuestionIcon";
        private const string WarningIconName = "PART_WarningIcon";
        private const string ErrorIconName = "PART_ErrorIcon";
        #endregion Private constants

        #region Private fields
        private Button? _okButton;
        private Button? _cancelButton;
        private Button? _yesButton;
        private Button? _noButton;
        private Button? _abortButton;
        private Button? _ignoreButton;

        private Image? _infoIcon;
        private Image? _questionIcon;
        private Image? _warningIcon;
        private Image? _errorIcon;
        #endregion Private fields

        #region Private static constructors
        static MessageView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageView), new FrameworkPropertyMetadata(typeof(MessageView)));
        }
        #endregion Private static constructors

        #region Public instance constructors
        /// <summary>
        /// Initialize a new instance of <see cref="MessageView"/>.
        /// </summary>
        public MessageView() { }
        /// <summary>
        /// Initialize a new instance of <see cref="MessageView"/> using specified <paramref name="caption"/>, <paramref name="content"/>, <paramref name="details"/>,
        /// <paramref name="type"/> and <paramref name="action"/>.
        /// </summary>
        /// <param name="caption">The caption of the <see cref="MessageView"/>.</param>
        /// <param name="header">The header of the <see cref="MessageView"/>.</param>
        /// <param name="content">The content of the <see cref="MessageView"/>.</param>
        /// <param name="details">The details of the <see cref="MessageView"/>.</param>
        /// <param name="footer">The footer of the <see cref="MessageView"/>.</param>
        /// <param name="type">The <see cref="MessageType"/> of the <see cref="MessageView"/>.</param>
        /// <param name="action">The <see cref="MessageAction"/> of the <see cref="MessageView"/>.</param>
        public MessageView(string caption, string header, string content, string details, string footer, MessageType type, MessageAction action)
        {
            Caption = caption;
            Header = header;
            Content = content;
            Details = details;
            Footer = footer;
            Type = type;
            Action = action;
        }
        #endregion Public instance constructors

        #region Dependency properties
        /// <summary>
        /// Identifies <see cref="Type"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register(nameof(MessageType), typeof(MessageType), typeof(MessageView), new FrameworkPropertyMetadata(MessageType.None, OnTypePropertyChanged));

        /// <summary>
        /// Identifies <see cref="Action"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register(nameof(MessageAction), typeof(MessageAction), typeof(MessageView), new FrameworkPropertyMetadata(MessageAction.OK, OnActionPropertyChanged));

        /// <summary>
        /// Identifies <see cref="Caption"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register(nameof(Caption), typeof(string), typeof(MessageView), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies <see cref="Header"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
           DependencyProperty.Register(nameof(Header), typeof(string), typeof(MessageView), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies <see cref="Content"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
           DependencyProperty.Register(nameof(Content), typeof(string), typeof(MessageView), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies <see cref="Details"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty DetailsProperty =
           DependencyProperty.Register(nameof(Details), typeof(string), typeof(MessageView), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies <see cref="Footer"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FooterProperty =
           DependencyProperty.Register(nameof(Footer), typeof(string), typeof(MessageView), new FrameworkPropertyMetadata(string.Empty));
        #endregion Dependency properties

        #region Public properties
        /// <summary>
        /// Gets or sets a <see cref="MessageType"/> of the message dialog.
        /// </summary>
        public MessageType Type
        {
            get { return (MessageType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }
        /// <summary>
        /// Gets or sets a <see cref="MessageAction"/> of the message dialog.
        /// </summary>
        public MessageAction Action
        {
            get { return (MessageAction)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }
        /// <summary>
        /// Gets or sets the caption of the message.
        /// </summary>
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        /// <summary>
        /// Gets or sets the header of the message.
        /// </summary>
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        /// <summary>
        /// Gets or sets the details of the message.
        /// </summary>
        public string Details
        {
            get
            {
                return (string)GetValue(DetailsProperty);
            }
            set
            {
                SetValue(DetailsProperty, value);
            }
        }
        /// <summary>
        /// Gets or sets the footer of the message.
        /// </summary>
        public string Footer
        {
            get
            {
                return (string)GetValue(FooterProperty);
            }
            set
            {
                SetValue(FooterProperty, value);
            }
        }
        #endregion Public properties

        #region Events
        /// <summary>
        /// Occurs when an action invoked.
        /// </summary>
        /// <remarks>
        /// This raised when an action button of current <see cref="MessageView"/> is clicked.
        /// </remarks>
        public event ActionInvokedHandler? ActionInvoked;
        #endregion Events

        #region Public methods
        /// <summary>
        /// Invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" />.
        /// </summary>
        public override void OnApplyTemplate()
        {
            _okButton = GetTemplateChild(OkButtonName) as Button;
            _cancelButton = GetTemplateChild(CancelButtonName) as Button;
            _yesButton = GetTemplateChild(YesButtonName) as Button;
            _noButton = GetTemplateChild(NoButtonName) as Button;
            _ignoreButton = GetTemplateChild(IgnoreButtonName) as Button;
            _abortButton = GetTemplateChild(AbortButtonName) as Button;

            _infoIcon = GetTemplateChild(InfoIconName) as Image;
            _questionIcon = GetTemplateChild(QuestionIconName) as Image;
            _warningIcon = GetTemplateChild(WarningIconName) as Image;
            _errorIcon = GetTemplateChild(ErrorIconName) as Image;

            Initialize();

            base.OnApplyTemplate();
        }
        #endregion Public methods

        #region Private methods
        private void Initialize()
        {
            ChangeVisibleButtons(Action);
            ChangeVisibleIcon(Type);
        }
        private void ChangeVisibleButtons(MessageAction action)
        {
            if (_okButton != null)
            {
                if (action == MessageAction.OK || action == MessageAction.OKCancel)
                {
                    _okButton.Visibility = Visibility.Visible;
                    _okButton.Click += OnClickedOk;
                    _okButton.IsDefault = true;
                }
                else
                {
                    _okButton.Visibility = Visibility.Collapsed;
                    _okButton.Click -= OnClickedOk;
                    _okButton.IsDefault = false;
                }
            }

            if (_cancelButton != null)
            {
                if (action == MessageAction.OKCancel ||
                    action == MessageAction.YesNoCancel)
                {
                    _cancelButton.Visibility = Visibility.Visible;
                    _cancelButton.Click += OnClickedCancel;
                    _cancelButton.IsCancel = true;
                }
                else
                {
                    _cancelButton.Visibility = Visibility.Collapsed;
                    _cancelButton.Click -= OnClickedCancel;
                    _cancelButton.IsCancel = false;
                }
            }

            if (_yesButton != null)
            {
                if (action == MessageAction.YesNo || action == MessageAction.YesNoCancel)
                {
                    _yesButton.Visibility = Visibility.Visible;
                    _yesButton.Click += OnClickedYes;
                    _yesButton.IsDefault = true;
                }
                else
                {
                    _yesButton.Visibility = Visibility.Collapsed;
                    _yesButton.Click -= OnClickedYes;
                    _yesButton.IsDefault = false;
                }
            }

            if (_noButton != null)
            {
                if (action == MessageAction.YesNo || action == MessageAction.YesNoCancel)
                {
                    _noButton.Visibility = Visibility.Visible;
                    _noButton.Click += OnClickedNo;
                }
                else
                {
                    _noButton.Visibility = Visibility.Collapsed;
                    _noButton.Click -= OnClickedNo;
                }
            }

            if (_abortButton != null)
            {
                if (action == MessageAction.AbortIgnore)
                {
                    _abortButton.Visibility = Visibility.Visible;
                    _abortButton.Click += OnClickedAbort;
                    _abortButton.IsDefault = true;
                }
                else
                {
                    _abortButton.Visibility = Visibility.Collapsed;
                    _abortButton.Click -= OnClickedAbort;
                    _abortButton.IsDefault = false;
                }
            }

            if (_ignoreButton != null)
            {
                if (action == MessageAction.AbortIgnore)
                {
                    _ignoreButton.Visibility = Visibility.Visible;
                    _ignoreButton.Click += OnClickedIgnore;
                    _ignoreButton.IsCancel = true;
                }
                else
                {
                    _ignoreButton.Visibility = Visibility.Collapsed;
                    _ignoreButton.Click -= OnClickedIgnore;
                    _ignoreButton.IsCancel = false;
                }
            }
        }
        private void ChangeVisibleIcon(MessageType type)
        {
            if (_infoIcon != null)
            {
                if (type == MessageType.Information)
                {
                    _infoIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    _infoIcon.Visibility = Visibility.Collapsed;
                }
            }

            if (_questionIcon != null)
            {
                if (type == MessageType.Question)
                {
                    _questionIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    _questionIcon.Visibility = Visibility.Collapsed;
                }
            }

            if (_warningIcon != null)
            {
                if (type == MessageType.Warning)
                {
                    _warningIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    _warningIcon.Visibility = Visibility.Collapsed;
                }
            }

            if (_errorIcon != null)
            {
                if (type == MessageType.Error)
                {
                    _errorIcon.Visibility = Visibility.Visible;
                }
                else
                {
                    _errorIcon.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void OnClickedOk(object sender, RoutedEventArgs e)
        {
            OnActionInvoked(MessageActionResult.Ok);
        }
        private void OnClickedCancel(object sender, RoutedEventArgs e)
        {
            OnActionInvoked(MessageActionResult.Cancel);
        }
        private void OnClickedYes(object sender, RoutedEventArgs e)
        {
            OnActionInvoked(MessageActionResult.Yes);
        }
        private void OnClickedNo(object sender, RoutedEventArgs e)
        {
            OnActionInvoked(MessageActionResult.No);
        }
        private void OnClickedAbort(object sender, RoutedEventArgs e)
        {
            OnActionInvoked(MessageActionResult.Abort);
        }
        private void OnClickedIgnore(object sender, RoutedEventArgs e)
        {
            OnActionInvoked(MessageActionResult.Ignore);
        }
        private void OnActionInvoked(MessageActionResult actionResult)
        {
            ActionInvoked?.Invoke(this, new(actionResult));
        }
        #endregion Private methods

        #region Dependency property changed event handlers
        private static void OnTypePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (!(dependencyObject is MessageView message && args.NewValue is MessageType type))
            {
                return;
            }

            message.ChangeVisibleIcon(type);
        }
        private static void OnActionPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (!(dependencyObject is MessageView message && args.NewValue is MessageAction action))
            {
                return;
            }

            message.ChangeVisibleButtons(action);
        }
        #endregion Dependency property changed event handlers
    }
}
