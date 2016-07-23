using UnityEngine;

public class PlayerPrey : MonoBehaviour {

    public float alertDistance = 15;
    public float meetupDistance = 3;

    private int preyFound = 0;
    private Player p;

    void Awake()
    {
        EventManager.GameStart += GameStart;
        GetPlayer();
    }

    void Update()
    {
        if (!p)
            GetPlayer();

        if (Input.GetButtonDown("Action_" + p.player))
            CheckRayForPlayers(Physics.OverlapSphere(transform.position, alertDistance, 1 << LayerMask.NameToLayer("Player")));
    }

    void OnTriggerEnter(Collider other)
    {
        CheckOverlapSphere(Physics.OverlapSphere(transform.position, meetupDistance, 1 << LayerMask.NameToLayer("Player")));
    }


    void GameStart()
    {
        preyFound = 0;
    }



    private void GetPlayer()
    {
        p = GetComponentInParent<Player>();
    }

    private void CheckRayForPlayers(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != transform.gameObject)
            {
                colliders[i].GetComponentInParent<Player>().Alert(transform.position);
            }
        }
    }

    private void CheckOverlapSphere(Collider[] colliders)
    {
        int preyFound = 0;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject && !colliders[i].isTrigger)
                preyFound++;
        }
        GameManager.c.TryPreyWin(preyFound);
    }

    private void CheckTriggerPlayer(GameObject other)
    {
        if (!other.GetComponentInParent<Player>().IsPredator())
            preyFound++;

        GameManager.c.TryPreyWin(preyFound);
    }
}
