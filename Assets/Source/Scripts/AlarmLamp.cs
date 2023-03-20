using UnityEngine;

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

    private void Update()
    {
        if (_alarm == null)
            throw new MissingComponentException();

        _material.color = Color.Lerp(_startColor, _targetColor, _alarm.VolumeProgress);
    }
}
