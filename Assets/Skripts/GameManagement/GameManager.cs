using UnityEngine;

//TODO scale predator collider
//TODO Audio manager
//TODO bug where ducks win when not together
public class GameManager : MonoBehaviour {

    public static GameManager c;

    public int amountOfPlayers = 4;

    public GameObject worldEdge1, worldEdge2;



    private int livePrey = 4;

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
        livePrey = amountOfPlayers - 1;
    }

    void GameEnd(GameEndStates state)
    {
        gameActive = false;
    }


    public void ReducePrayCount()
    {
        livePrey--;
        if (livePrey < 2)
            EventManager.TriggerGameEnd(GameEndStates.PredatorWin);
    }

    public void ReducePredatorCount()
    {
        EventManager.TriggerGameEnd(GameEndStates.PreyWin);
    }

    public bool IsGameActive()
    {
        return gameActive;
    }

    public void TriggerGameStart()
    {
        EventManager.TriggerGameStart();
    }

    public float GetWorldSize()
    {
        return Vector3.Distance(worldEdge1.transform.position, worldEdge2.transform.position);
    }

    public void TryPrayWin(int preyFound)
    {
        if(preyFound == livePrey-1)
            EventManager.TriggerGameEnd(GameEndStates.PreyWin);
    }


}
