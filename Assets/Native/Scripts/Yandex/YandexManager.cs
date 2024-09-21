using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YandexManager : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void SendGameReady();

    [DllImport("__Internal")]
    public static extern void SendGameStart();

    [DllImport("__Internal")]
    public static extern void SendGameStop();

    [DllImport("__Internal")]
    public static extern string GetLang();

    [DllImport("__Internal")]
    public static extern void ShowAd();

    [DllImport("__Internal")]
    public static extern void ShowReward();

    [SerializeField] TextMeshProUGUI _languageText;

    public GameState _gameState;
    public string _currentLanguage;

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ShowFullscreenAd();
        }
    }

    // Ready Game API managment
    public void ReadyGame()
    {
        SendGameReady();
    }

    public void StartGame()
    {
        SendGameStart();
    }

    public void StopGame()
    {
        SendGameStop();
    }

    // Languages managment
    public static YandexManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            _currentLanguage = GetLang();
            _languageText.text = _currentLanguage;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Ad managment
    public void ShowFullscreenAd()
    {
        _gameState.StopGame();
        ShowAd();
    }

    public void ShowRewardAd()
    {
        _gameState.StopGame();
        ShowReward();
    }

    public void Rewarded()
    {
        _gameState.StartGame();
        //Add method to get bonus
    }
}
