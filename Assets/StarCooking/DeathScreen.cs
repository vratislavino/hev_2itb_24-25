using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public TMP_Text ingameTime;
    public TMP_Text deathScreenTime;

    private float time = 0;

    void Start()
    {
        Time.timeScale = 1;
        UpdateTimeText();
    }

    void Update()
    {
        time += Time.deltaTime;
        UpdateTimeText();
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
        deathScreenTime.text = $"U dead, your time was {time.ToString("F2")}";
        ingameTime.gameObject.SetActive(false);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    private void UpdateTimeText()
    {
        ingameTime.text = $"Your time: {time.ToString("F2")}";
    }
}
