namespace Julequiz;
public interface IWinnerController 
{
    IResult RegisterWinnerName(string name);
    IResult ResetWinner();
    IResult GetWinner();
}