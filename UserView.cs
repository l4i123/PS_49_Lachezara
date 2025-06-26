public class UserView
{
    private UserViewModel _viewModel;
    public UserViewModel ViewModel { get; set; }

    public void DisplayUserInfo()
    {
        // Implementation for displaying user info
    }

    public void DisplayError()
    {
        Console.WriteLine("An error occurred while displaying user information.");
    }
}
