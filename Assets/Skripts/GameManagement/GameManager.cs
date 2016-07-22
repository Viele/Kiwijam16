using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager c;

    public int amountOfPlayers = 4;

    private bool gameActive = false;

    void Awake()
    {
        if (!c)
            c = this;
        else
            Destroy(this);

        EventManager.GameStart += GameStart;
        EventManager.GameEnd += GameEnd;
    }

    void GameStart()
    {
        gameActive = true;
    }

    void GameEnd(GameEndStates state)
    {
        gameActive = false;
    }



    public bool IsGameActive()
    {
        return gameActive;
    }

    public void TriggerGameStart()
    {
        EventManager.TriggerGameStart();
    }


}
