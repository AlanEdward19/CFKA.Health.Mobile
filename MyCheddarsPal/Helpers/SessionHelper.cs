namespace MyCheddarsPal.Helpers;

public static class SessionHelper
{
    public static void SaveToken(string token, DateTime expiresIn)
    {
        Preferences.Set("token", token);
        Preferences.Set("ExpiresDateTimeKey", expiresIn);
    }

    public static async Task<string> GetTokenAsync()
    {
        var expireDateTime = Preferences.Get("ExpiresDateTimeKey", DateTime.MinValue);

        if (expireDateTime <= DateTime.Now)
        {
            await Shell.Current.DisplayAlert("Atenção", "Token expirado, você será redirecionado para pagina de login",
                "Ok");
            await Shell.Current.GoToAsync(nameof(LoginPage));
            return string.Empty;
        }

        return Preferences.Get("token", string.Empty);
    }
}