namespace iMaxwell.EmployeeClient.Models;

public class TokenModel
{
    private bool _loggedIn;

    public event Action OnChange;

    public string? UserName { get; set; }

    public string? Token { get; set; }

    public bool LoggedIn
    {
        get { return _loggedIn; }
        set
        {
            if(_loggedIn != value)
            {
                _loggedIn = value;
                NotifyStateChanged();
            }
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
