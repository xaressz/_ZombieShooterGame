using UnityEngine;

public class WinDoor : MonoBehaviour, IWinable
{
    private void Awake()
    {
        Time.timeScale = 1f;  // zaman normal akıyor
    }

    public void OnLevelComplete()
    {
        // animasyon eklemediğim için level complete olduğunda time scale i 0lıyoruz ve düşmanların spawn olmasını engelliyoruz
        Time.timeScale = 0f;
        Debug.Log("Congratulations, level is completed");
    }
}