using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("Listen to event channels")]
    public VoidEventChannel onPlayerDeath;
    
    [Header("Game Over UI")]
    public GameObject gameOverUI;

    private void OnEnable()
    {
        onPlayerDeath.OnEventRaised += OnGameOver;
    }

   public void OnGameOver()
{
    // Pas de Time.timeScale ici, on attend juste
    Invoke(nameof(ShowGameOver), 1.5f);
}

private void ShowGameOver()
{
    gameOverUI.SetActive(true);
    // On met pas Time.timeScale à 0 pour l'instant
}

    private void OnDisable()
    {
        onPlayerDeath.OnEventRaised -= OnGameOver;
    }
}