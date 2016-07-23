using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager c;

    public int amountOfPlayers = 4;

    public GameObject worldEdge1, worldEdge2;


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

    public float GetWorldSize()
    {
        return Vector3.Distance(worldEdge1.transform.position, worldEdge2.transform.position);
    }


}
