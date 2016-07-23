using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerManager pManager;
    public PlayerNumber player;
    public PlayerUI playerUI;

    private bool predator;
    private GameObject playerGraphic;
    private PlayerMovement mov;
    private bool active = true;


    void Awake()
    {
        EventManager.GameStart += GameStart;
        EventManager.GameEnd += GameEnd;
        mov = GetComponent<PlayerMovement>();
    }

    void GameStart()
    {
        active = true;
    }

    void GameEnd(GameEndStates state)
    {
        Destroy(playerGraphic);
    }




    public void Alert(Vector3 position)
    {
        playerUI.Alert(position);
    }

    public void KillPlayer()
    {
        playerUI.KillPlayer();
        Destroy(playerGraphic);
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
        if (predator)
            mov.SetPredatorMovement();
        else
            mov.SetPreyMovement();
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
