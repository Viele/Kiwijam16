using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject gameUI;
    public Text winText;
    public Button startButton;


    void Awake()
    {
        gameUI.SetActive(true);
        EventManager.GameStart += GameStart;
        EventManager.GameEnd += GameEnd;
    }

    void GameStart()
    {
        winText.gameObject.SetActive(false);
    }

    void GameEnd(GameEndStates state)
    {
        winText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        if (state == GameEndStates.PredatorWin)
            winText.text = "Cat wins";
        else
            winText.text = "Ducklings win";
    }
}
