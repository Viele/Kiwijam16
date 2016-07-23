using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Image blackScreen;

    void Awake()
    {
        EventManager.GameStart += GameStart;
        EventManager.GameEnd += GameEnd;
    }

    void GameStart()
    {
        BlackScreen(false);
    }

    void GameEnd(GameEndStates state)
    {
        BlackScreen(true);
    }

    public void KillPlayer()
    {
        BlackScreen(true);
    }



    private void BlackScreen(bool active)
    {
        blackScreen.gameObject.SetActive(active);
    }
}
