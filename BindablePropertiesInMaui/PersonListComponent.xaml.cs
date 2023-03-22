using AvnObservable;

namespace BindablePropertiesInMaui;

public partial class PersonListComponent : ContentView
{
    public PersonListComponent()
    {
        InitializeComponent();
    }

    public void Refresh()
    {
        PersonCollection.UpdateSelectedItemInCollection();
        OnPropertyChanged("PersonCollection");
    }

    private void PersonPropertyChanged(object sender, TextChangedEventArgs e)
    {
        // required for instant updates as you type
        PersonCollection.UpdateSelectedItemInCollection();
    }

    // Define a bindable property for the PersonCollection
    public static readonly BindableProperty PersonCollectionProperty =
        // Use the BindableProperty.Create method to create a new bindable property
        BindableProperty.Create(nameof(PersonCollection),
        typeof(ObservableCollectionWithSelection<Person>),
        typeof(PersonListComponent),
        new ObservableCollectionWithSelection<Person>(),
        validateValue: IsCollectionValid);

    // Define a property that wraps the bindable property
    public ObservableCollectionWithSelection<Person> PersonCollection
    {
        get => (ObservableCollectionWithSelection<Person>)GetValue(PersonCollectionProperty);
        set => SetValue(PersonCollectionProperty, value);
    }

    // Define a bindable property for the validation error message
    public static readonly BindableProperty ValidationErrorMessageProperty =
       BindableProperty.Create(nameof(ValidationErrorMessage),
       typeof(string),
       typeof(PersonListComponent));

    // Define a property that wraps the validation error message bindable property
    public string ValidationErrorMessage
    {
        get => (string)GetValue(ValidationErrorMessageProperty);
        set => SetValue(ValidationErrorMessageProperty, value);
    }

    // Validation function to check if the collection has at least one item
    static bool IsCollectionValid(BindableObject view, object value)
    {
        if (((ObservableCollectionWithSelection<Person>)value).Count < 1)
        {
            ((PersonListComponent)view).ValidationErrorMessage = "Collection should be initialized with at least one item.";
            return false;
        }

        return true;
    }
}