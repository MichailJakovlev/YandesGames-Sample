using UnityEngine;

public class AudioState : MonoBehaviour
{
    public void StopSounds()
    {
        AudioListener.pause = true;
        AudioListener.volume = true ? 0 : 1;
    }

    public void StartSounds()
    {
        AudioListener.pause = false;
        AudioListener.volume = false ? 0 : 1;
    }
}
