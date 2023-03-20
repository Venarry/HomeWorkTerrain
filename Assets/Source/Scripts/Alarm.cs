using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MaxVolume = 1;

    private float _volumeChangeSpeed = 0.01f;
    private bool _isPlaying;
    private float _currentVolume;

    public float VolumeProgress => _currentVolume / MaxVolume;

    private void FixedUpdate()
    {
        if (_isPlaying)
            _currentVolume = Mathf.MoveTowards(_currentVolume, MaxVolume, _volumeChangeSpeed);
        else
            _currentVolume = Mathf.MoveTowards(_currentVolume, 0, _volumeChangeSpeed);
    }

    public void PlayAlarm()
    {
        _isPlaying = true;
    }

    public void StopAlarm()
    {
        _isPlaying = false;
    }
}
