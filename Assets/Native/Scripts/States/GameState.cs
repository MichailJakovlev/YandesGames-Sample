using UnityEngine;

public class GameState : MonoBehaviour
{
    public YandexManager _yandexManager;
    public AudioState _audioState;
    
    private bool _isGameReady = false;

    // Game States managment
    public void StopGame()
    {
        _yandexManager.StopGame();
        _audioState.StopSounds();
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        if (_isGameReady == false)
        {
            _yandexManager.ReadyGame();
            _isGameReady = true;
        }

        _yandexManager.StartGame();
        _audioState.StartSounds();
        Time.timeScale = 1;
    }

    // Game Focus managment
    void OnApplicationFocus(bool hasFocus)
    {
        GameFocus(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        GameFocus(isPaused);
    }

    private void GameFocus(bool focusState)
    {
        if (focusState)
        {
            StopGame();
        }
        else
        {
            StartGame();
        }
    }
}
