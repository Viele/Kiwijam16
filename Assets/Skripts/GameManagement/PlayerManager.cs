using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    public Player[] players = new Player[4];
    public GameObject predatorGraphic;
    public GameObject preyGraphic;

    private SpawnPosition[] spawnPositions;



    void Awake()
    {
        EventManager.GameStart += GameStart;
        spawnPositions = FindObjectsOfType<SpawnPosition>();
    }

    void GameStart()
    {
        DeterminePredator();
        SpawnGraphics();
        PositionPlayers();
    }




    private void DeterminePredator()
    {
        int predatorIndex = Random.Range(0, GameManager.c.amountOfPlayers);
        for (int i = 0; i < GameManager.c.amountOfPlayers; i++)
        {
            players[i].SetPredator(i==predatorIndex);
        }
    }

    private void SpawnGraphics()
    {
        for (int i = 0; i < GameManager.c.amountOfPlayers; i++)
        {
            players[i].SpawnPlayerGraphic();
        }
    }

    private void PositionPlayers()
    {
        List<SpawnPosition> usedPositions = new List<SpawnPosition>();

        for (int i = 0; i < GameManager.c.amountOfPlayers; i++)
        {
            SpawnPosition pos;
            do
            {
                pos = spawnPositions[Random.Range(0, spawnPositions.Length)];
            } while (usedPositions.Contains(pos));

            usedPositions.Add(pos);
            players[i].SetPosition(pos.transform.position);
        }
    }
}
