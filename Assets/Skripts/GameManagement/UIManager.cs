using UnityEngine;

public class UIManager : MonoBehaviour {

    public GameObject gameUI;

    void Awake()
    {
        gameUI.SetActive(true);
    }
}
