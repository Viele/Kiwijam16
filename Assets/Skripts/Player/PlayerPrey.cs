using UnityEngine;

public class PlayerPrey : MonoBehaviour {

    private int preyFound = 0;

    void Awake()
    {
        EventManager.GameStart += GameStart;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            CheckTriggerPlayer(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            if(!other.GetComponent<Player>().IsPredator())
                preyFound--;
        }

    }

    void GameStart()
    {
        preyFound = 0;
    }



    private void CheckTriggerPlayer(GameObject other)
    {
        if (!other.GetComponent<Player>().IsPredator())
            preyFound++;

        GameManager.c.TryPrayWin(preyFound);
    }
}
