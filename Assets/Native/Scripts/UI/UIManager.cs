using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _stopSoundButton;
    public GameObject _startSoundButton;

    public void DisableSoundButton()
    {
        _stopSoundButton.SetActive(false);
        _startSoundButton.SetActive(true);
    }

    public void EnableSoundButton()
    {
        _stopSoundButton.SetActive(true);
        _startSoundButton.SetActive(false);
    }
}
