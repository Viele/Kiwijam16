using UnityEngine;
using System.Collections;

public class PlayerPredator : MonoBehaviour {

    public float attachReach = 1;

    private Player p;

    void Awake()
    {
        GetPlayer();
    }

	void Update () {
        if (!p)
            GetPlayer();
        if (Input.GetButtonDown("Action_" + p.player))
        {
            CheckRayForPrey(Physics.OverlapSphere(transform.position + transform.forward, attachReach, 1 << LayerMask.NameToLayer("Player")));
        }
	}

    private void GetPlayer()
    {
        p = GetComponentInParent<Player>();
    }

    private void CheckRayForPrey(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != transform.parent.gameObject)
            {
                if (colliders[i].gameObject.GetComponent<Player>())
                    colliders[i].gameObject.GetComponent<Player>().KillPlayer();

            }
        }
    }
}
