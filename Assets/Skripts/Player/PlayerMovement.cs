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

    public PlayerNumber player;

    public float movementFac, rotationFac;

    private Rigidbody rb;
    private Player p;

	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate () {
        if (GameManager.c.IsGameActive() && p.IsActive())
        {
            transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal_" + player)*100,0)*Time.fixedDeltaTime);
            rb.AddRelativeForce(new Vector3(0, 0, Input.GetAxis("Vertical_"+player))*10);
        }
	}
}
