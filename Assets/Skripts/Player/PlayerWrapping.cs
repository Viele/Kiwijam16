using UnityEngine;

public class PlayerWrapping : MonoBehaviour {

    private float edgeThreshold = 0.5f;

	void Update () {
        if (Mathf.Abs(transform.position.x) > GameManager.c.worldSize + edgeThreshold)
            WrapPlayer(new Vector3(-1,1,1));

        if (Mathf.Abs(transform.position.z) > GameManager.c.worldSize + edgeThreshold)
            WrapPlayer(new Vector3(1,1,-1));
	}

    private void WrapPlayer(Vector3 wrap)
    {
        transform.position = new Vector3(
            transform.position.x * wrap.x + 2*(Mathf.Sign(transform.position.x) * edgeThreshold * BoolToInt(wrap.x < 0)),
            transform.position.y * wrap.y,
            transform.position.z * wrap.z + 2*(Mathf.Sign(transform.position.z) * edgeThreshold * BoolToInt(wrap.z < 0))
            );
    }

    private int BoolToInt(bool fac)
    {
        return fac ? 1 : 0;
    }

}
