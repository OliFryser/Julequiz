namespace Julequiz;
public interface IWinnerController 
{
    void RegisterWinnerName(string name);
    bool ResetWinner();
    bool IsWinnerFound();
    string? GetWinner();
}