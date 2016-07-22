
public enum GameEndStates
{
    PredatorWin,
    PreyWin
}

public static class EventManager{

    public delegate void GameEvent();

    public delegate void GameEventParameter(GameEndStates state);



    public static GameEvent 
        GameStart;

    public static GameEventParameter 
        GameEnd;



    public static void TriggerGameStart()
    {
        if (GameStart != null)
            GameStart();
    }

    public static void TriggerGameEnd(GameEndStates state)
    {
        if (GameEnd != null)
            GameEnd(state);
    }
}
