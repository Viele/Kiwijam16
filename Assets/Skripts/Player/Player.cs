using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerManager pManager;
    public PlayerNumber player;
    public PlayerUI playerUI;

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
        if(playerGraphic)
            playerGraphic.SetActive(true);
        active = true;
    }

    void GameEnd(GameEndStates state)
    {
        coll.enabled = false;
        Destroy(playerGraphic);
    }





    public void KillPlayer()
    {
        playerUI.KillPlayer();
        coll.enabled = false;
        playerGraphic.SetActive(false);
        active = false;
        if (predator)
            GameManager.c.ReducePredatorCount();
        else
            GameManager.c.ReducePrayCount();
    }


    public bool IsActive()
    {
        return active;
    }

    public bool IsPredator()
    {
        return predator;
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

        playerGraphic.transform.SetParent(gameObject.transform, false);
    }

    public void DeletePlayerGraphic()
    {
        Destroy(playerGraphic);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }






}
