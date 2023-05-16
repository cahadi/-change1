using System.Windows;
using System.Windows.Controls;
using ООО__Товары_для_животных_.Models;
using ООО__Товары_для_животных_.Tools;
using ООО__Товары_для_животных_.Views.Pages;

namespace ООО__Товары_для_животных_.ViewModels;

public class MainViewModel : ViewModel
{
    public MainViewModel()
    {
        User = new User();

        CurrentPage = new LogInPage(this);

        LogoutCommand = new(() =>
        {
            User = new User();
            LoggedInVisibility = Visibility.Collapsed;
            CurrentPage = new LogInPage(this);
        });
    }

    public User User
    {
        get => user;
        set
        {
            LoggedInVisibility = Visibility.Visible;
            user = value;

            OnPropertyChanged();

            Auth.Username = $"{user?.UserSurname} {user?.UserName} {user?.UserPatronymic}";
            Auth.UserRole = user.UserRoleNavigation?.RoleName ?? "Гость";

            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(UserRole));
        }
    }

    public string UserRole
    {
        get => Auth.UserRole;
    }

    public string UserName
    {
        get => Auth.Username;
    }

    private Visibility _loggedInVisibility = Visibility.Collapsed;
    public Visibility LoggedInVisibility
    {
        get => _loggedInVisibility;
        set
        {
            _loggedInVisibility = value;
            OnPropertyChanged();
        }
    }

    private Page _currentPage;
    private User user;

    public Page CurrentPage 
    { 
        get => _currentPage;
        set
        {
            _currentPage = value;
            OnPropertyChanged();
        }
    }

    public Command LogoutCommand { get; set; }
}