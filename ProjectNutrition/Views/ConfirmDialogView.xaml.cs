namespace ProjectNutrition.Views;

public partial class ConfirmDialogView : ContentView
{
    public ConfirmDialogView()
    {
        InitializeComponent();
    }

    private void OnCancel(object sender, EventArgs e) => CancelCommand.Execute(null);

    private void OnConfirm(object sender, EventArgs e) => ConfirmCommand.Execute(null);

    public Command CancelCommand
    {
        get => (Command)GetValue(CancelCommandProperty);
        set => SetValue(CancelCommandProperty, value);
    }
    public static readonly BindableProperty CancelCommandProperty = BindableProperty.Create(
        nameof(CancelCommand),
        typeof(Command),
        typeof(ConfirmDialogView),
        new Command(() => throw new NotImplementedException()),
        propertyChanged: (bindable, old, @new) =>
        {
            var @this = (ConfirmDialogView)bindable;
            if (@new is Command command)
                @this.CancelCommand = command;
        });

    public Command ConfirmCommand
    {
        get => (Command)GetValue(ConfirmCommandProperty);
        set => SetValue(ConfirmCommandProperty, value);
    }
    public static readonly BindableProperty ConfirmCommandProperty = BindableProperty.Create(
        nameof(ConfirmCommand),
        typeof(Command),
        typeof(ConfirmDialogView),
        new Command(() => throw new NotImplementedException()),
        propertyChanged: (bindable, old, @new) =>
        {
            var @this = (ConfirmDialogView)bindable;
            if (@new is Command command)
                @this.ConfirmCommand = command;
        });

    /*    public FormattedString Text
        {
            get => (FormattedString)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(FormattedString),
            typeof(ConfirmDialogView),
            "Are you sure?",
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (ConfirmDialogView)bindable;
                if (@new is not FormattedString text)
                    return;

                @this.confirmTextLabel.FormattedText = text;
            });*/
}