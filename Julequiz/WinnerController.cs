namespace Julequiz;

public class WinnerController : IWinnerController
{
    public string? WinnerName {get; set;}

    public void RegisterWinnerName(string name) 
    {
        if(!IsWinnerFound()) 
        {
            WinnerName = name;
        }
    }

    public bool IsWinnerFound() => WinnerName is not null;

    public bool ResetWinner() 
    {
        if(IsWinnerFound()) 
        {
            WinnerName = null;
            return true;
        }
        return false;
    }

    public string? GetWinner() 
    {
        if(!IsWinnerFound()) 
        {
            return "";
        }
        else return WinnerName;
    }

}