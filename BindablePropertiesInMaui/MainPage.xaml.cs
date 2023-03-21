namespace BindablePropertiesInMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = personList;

        // Add data to the PersonList component
        try
        {
            personList.PersonCollection = new AvnObservable.ObservableCollectionWithSelection<Person>
            {
                new Person(1, "Carl", "Franklin", DateTime.Now),
                new Person(2, "Isadora", "Jarr", DateTime.Now),
                new Person(3, "Hugh", "Jass", DateTime.Now)
            };
        }
        catch (Exception ex)
        {
            // Handle any exceptions
        }

        // Handle selected item changing and changed events
        personList.PersonCollection.SelectedItemChanging+= PersonCollection_SelectedItemChanging;
        personList.PersonCollection.SelectedItemChanged+= PersonCollection_SelectedItemChanged;
    }

    private void PersonCollection_SelectedItemChanged(object sender, Person e)
    {
        // A new person has been selected
    }

    private void PersonCollection_SelectedItemChanging(object sender, Person e)
    {
        // Update the existing Person here
    }

    public void Dispose()
    {
        // Unhook the event handlers
        personList.PersonCollection.SelectedItemChanging-= PersonCollection_SelectedItemChanging;
        personList.PersonCollection.SelectedItemChanged-= PersonCollection_SelectedItemChanged;
    }
}