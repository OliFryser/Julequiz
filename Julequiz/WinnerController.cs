namespace Julequiz;

public class WinnerController : IWinnerController
{
    public string WinnerName {get; set;} = "";

    public IResult RegisterWinnerName(string name) 
    {
        if(!IsWinnerFound()) 
        {
            lock(WinnerName) 
            {
                WinnerName = name;
            }
            return TypedResults.Ok(WinnerName);
        }
        return TypedResults.Conflict(WinnerName);
    }

    private bool IsWinnerFound() => WinnerName != "";

    public IResult ResetWinner() 
    {
        if(IsWinnerFound()) 
        {
            lock(WinnerName) 
            {
            WinnerName = "";
            }
            return TypedResults.NoContent();
        }
        return TypedResults.BadRequest();
    }

    public IResult GetWinner() 
    {
        if(!IsWinnerFound()) 
        {
            return TypedResults.NotFound("no winner");
        }
        else return TypedResults.Ok(WinnerName);
    }

}