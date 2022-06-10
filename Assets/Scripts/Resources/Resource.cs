using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Resources/Resource")]
public class Resource : ScriptableObject, IRepresentable
{
    [Header("General")]
    [SerializeField] private ResourceType m_Type;

    [SerializeField] private float initialMaxValue;
    [SerializeField] private float initialValue;

    [Header("UI")]
    [SerializeField] private RepresentationColorData m_ColorData;

    public Action<float> onValueChanged;
    public Action<float> onMaxChanged;

    private ResourceRepresentation m_Representation;

    private float _currentValue;
    private float _maxValue;

    private void Awake()
    {
        _currentValue = initialValue;
        _maxValue = initialMaxValue;
    }

    public ResourceType Type
    {
        get { return m_Type; }
    }
    public string Name => Type.ToString();

    public float Value
    {
        get { return _currentValue; }
        private set { SetValue(value); }
    }

    public float Maximum
    {
        get { return _maxValue; }
        set
        {
            if (value > 0f)
            {
                _maxValue = value;
                onMaxChanged?.Invoke(_maxValue);
            }
        }
    }

    public bool isFull
    {
        get
        {
            return Value >= _maxValue;
        }
    }

    public IRepresentation Representation 
    { 
        get => m_Representation;
        set => m_Representation = value as ResourceRepresentation; 
    }

    public RepresentationColorData ColorData => m_ColorData;

    public void Add(float value)
    {
        if (value < 0f)
            return;

        if (Value + value > _maxValue)
        {
            SetValue(_maxValue);
        }
        else
            SetValue(_currentValue + value);

    }

    public void Substract(float value)
    {
        if (value < 0f)
            return;

        if (_currentValue - value < 0f)
        {
            SetValue(0f);
        }
        else
            SetValue(_currentValue - value);
    }

    private void SetValue(float value)
    {
        _currentValue = value;
        onValueChanged?.Invoke(_currentValue);
    }
}
