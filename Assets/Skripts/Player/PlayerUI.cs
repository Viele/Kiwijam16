using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Image blackScreen;
    public Image alert;

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

    public void Alert(Vector3 position)
    {
        alert.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(DeactivateAfterTime(0.5f, alert.gameObject));
    }


    private void BlackScreen(bool active)
    {
        blackScreen.gameObject.SetActive(active);
    }

    private IEnumerator DeactivateAfterTime(float delay, GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    } 
}
