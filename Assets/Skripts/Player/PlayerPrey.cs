using UnityEngine;

public class PlayerPrey : MonoBehaviour {

    public float alertDistance = 15;

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
        if (other.GetComponentInParent<Player>())
            CheckTriggerPlayer(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Player>())
        {
            if(!other.GetComponentInParent<Player>().IsPredator())
                preyFound--;

            Debug.Log(preyFound);
        }

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

    private void CheckTriggerPlayer(GameObject other)
    {
        if (!other.GetComponentInParent<Player>().IsPredator())
            preyFound++;

        GameManager.c.TryPrayWin(preyFound);
    }
}
