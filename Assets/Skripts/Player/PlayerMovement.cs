using UnityEngine;
using System.Collections;

public enum PlayerNumber
{
    p1,
    p2,
    p3,
    p4
}


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    public float movementFac, rotationFac;

    private Rigidbody rb;
    private Player p;

	void Awake () {
        rb = GetComponent<Rigidbody>();
        p = GetComponent<Player>();
	}
	
	
	void FixedUpdate () {
        if (GameManager.c.IsGameActive() && p.IsActive())
        {
            transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal_" + p.player)*rotationFac,0)*Time.fixedDeltaTime);
            rb.AddRelativeForce(new Vector3(0, 0, Input.GetAxis("Vertical_"+p.player))*movementFac);
        }
	}
}
