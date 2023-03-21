using UnityEngine;
using System;

public class AlarmLamp : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private Color _targetColor;

    private Material _material;
    private Color _startColor;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Start()
    {
        _startColor = _material.color;
    }

    private void OnEnable()
    {
        _alarm.AlarmVolumeChanged += OnAlarmVolumeChange;
    }

    private void OnAlarmVolumeChange()
    {
        _material.color = Color.Lerp(_startColor, _targetColor, _alarm.VolumeProgress);
    }
}
