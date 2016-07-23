using UnityEngine;
using System.Collections;

public class PlayerPredator : MonoBehaviour {

    public float attackReach = 2;

    private Player p;

    void Awake()
    {
        GetPlayer();
    }

	void Update () {
        if (!p)
            GetPlayer();
        if (Input.GetButtonDown("Action_" + p.player))
            CheckRayForPrey(Physics.OverlapSphere(transform.position + transform.forward, attackReach, 1 << LayerMask.NameToLayer("Player")));
        
	}

    private void GetPlayer()
    {
        p = GetComponentInParent<Player>();
    }

    private void CheckRayForPrey(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != transform.gameObject)
            {
                if (colliders[i].gameObject.GetComponentInParent<Player>() && !colliders[i].isTrigger)
                    colliders[i].gameObject.GetComponentInParent<Player>().KillPlayer();
                
            }
        }
    }
}
