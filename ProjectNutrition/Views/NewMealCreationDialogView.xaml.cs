using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Views
{
    public partial class NewMealCreationDialogView : ContentView
    {
        public NewMealCreationDialogViewModel VM { get; }
        public NewMealCreationDialogView()
        {
            InitializeComponent();

            VM = MauiProgram.GetService<NewMealCreationDialogViewModel>() ?? throw new NullReferenceException();

            wrapper.BindingContext = VM;
        }

        public Command SaveCommand
        {
            get => (Command)GetValue(SaveCommandProperty);
            set
            {
                SetValue(SaveCommandProperty, value);
                VM.SaveCommand = value;
            }
        }
        public static readonly BindableProperty SaveCommandProperty = BindableProperty.Create(
            nameof(SaveCommand),
            typeof(Command),
            typeof(NewMealCreationDialogView),
            new Command(() => throw new NotImplementedException()),
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (NewMealCreationDialogView)bindable;
                if (@new is Command command)
                    @this.SaveCommand = command;
            });

        public string DefaultMealName
        {
            get => (string)GetValue(DefaultMealNameProperty);
            set
            {
                SetValue(DefaultMealNameProperty, value);
                VM.DefaultMealName = value;
            }
        }
        public static readonly BindableProperty DefaultMealNameProperty = BindableProperty.Create(
            nameof(DefaultMealName),
            typeof(string),
            typeof(NewMealCreationDialogView),
            "Meal",
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (NewMealCreationDialogView)bindable;
                if (@new is string name)
                    @this.DefaultMealName = name;
            });

        public void Save() => VM.Save();
    }
}