using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using ООО__Товары_для_животных_.Database;
using ООО__Товары_для_животных_.IDatabase;
using ООО__Товары_для_животных_.Models;

namespace ООО__Товары_для_животных_.Tools;

internal static class Auth
{
    internal static string Username { get; set; } = string.Empty;

    internal static string UserRole { get; set; } = string.Empty;

    internal static bool IsUserAdmin { get; private set; } = false;

    private static readonly IDB dB;

    internal static User ValidateUser(string pass, string login)
    {
        User findedUser = null!;

        try
        {
            findedUser = dB.GetUsers(pass, login);
        }
        catch
        {
            MessageBox.Show("Ошибка связи с базой данных. Обратитесь к администратору");
            return null!;
        }

        if (findedUser == null)
        {
            MessageBox.Show("Пользователя с таким логином и паролем не существует!");
            return null!;
        }

        IsUserAdmin = findedUser.UserRoleNavigation.RoleName == "Администратор";

        return findedUser;
    }
}