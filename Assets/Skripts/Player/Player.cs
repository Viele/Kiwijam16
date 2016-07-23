using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerManager pManager;

    private bool predator;
    private GameObject playerGraphic;
    private Collider coll;
    private bool active = true;

    void Awake()
    {
        EventManager.GameStart += GameStart;
        EventManager.GameEnd += GameEnd;
        coll = GetComponent<Collider>();
    }

    void GameStart()
    {
        coll.enabled = true;
    }

    void GameEnd(GameEndStates state)
    {
        coll.enabled = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player>())
            CheckCollisionPlayer(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            CheckTriggerPlayer(other.gameObject);
    }


    public void KillPlayer()
    {

    }


    public bool IsActive()
    {
        return active;
    }

    public void SetPredator(bool predator)
    {
        this.predator = predator;
    }

    public void SpawnPlayerGraphic()
    {
        if(predator)
            playerGraphic = Instantiate(pManager.predatorGraphic);
        else
            playerGraphic = Instantiate(pManager.preyGraphic);

        playerGraphic.transform.SetParent(gameObject.transform);
    }

    public void DeletePlayerGraphic()
    {
        Destroy(playerGraphic);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }







    private void CheckCollisionPlayer(GameObject other)
    {
        if (other.GetComponent<Player>().predator)
            active = false;
    }

    private void CheckTriggerPlayer(GameObject other)
    {
        if (!other.GetComponent<Player>().predator)
            Debug.Log("quak");
    }

}
