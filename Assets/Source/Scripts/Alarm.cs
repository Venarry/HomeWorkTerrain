using System;
using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const float MaxVolume = 1;

    private float _volumeChangeSpeed = 0.01f;
    private float _currentVolume;
    private Coroutine _currentAlarmModify;

    public float VolumeProgress => _currentVolume / MaxVolume;

    public event Action AlarmVolumeChanged;

    public void PlayAlarm()
    {
        TryStopAlarm();
        _currentAlarmModify = StartCoroutine(ModifyAlarm(MaxVolume));
    }

    public void StopAlarm()
    {
        TryStopAlarm();
        _currentAlarmModify = StartCoroutine(ModifyAlarm(0));
    }

    private void TryStopAlarm()
    {
        if (_currentAlarmModify != null)
            StopCoroutine(_currentAlarmModify);
    }

    private IEnumerator ModifyAlarm(float targetVolume)
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

        while (_currentVolume != targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _volumeChangeSpeed);
            AlarmVolumeChanged?.Invoke();
            yield return waitForFixedUpdate;
        }
    }
}
