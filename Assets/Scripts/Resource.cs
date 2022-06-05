using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/Resource")]
public class Resource : ScriptableObject
{

    [SerializeField] private ResourceType m_Type;
    [SerializeField] private ResourceRepresentation resourceUIPrefab;

    [SerializeField] private float initialMaxValue;
    [SerializeField] private float initialValue;

    private Action<float> _onValueChanged;
    private Action<float> _onMaxChanged;
    private ResourceRepresentation _representation;
    public ResourceType Type
    {
        get { return m_Type; }
    }

    public float Value
    {
        get { return _currentValue; }
        private set { SetValue(value); }
    }

    public float Maximum
    {
        set 
        {
            if (value > 0f)
            {
                _maxValue = value;
                _onMaxChanged?.Invoke(_maxValue);
            } 
        }
    }

    public bool Maxed
    {
        get
        {
            return Value >= _maxValue;
        }
    }

    private float _currentValue;
    private float _maxValue;

    public void Initialize()
    {
        _representation = Instantiate(resourceUIPrefab, ResourcesManager.Instance.ResourcesRepresentationRoot).GetComponent<ResourceRepresentation>();

        _onValueChanged = _representation.UpdateRepresentation;
        _onMaxChanged = _representation.UpdateValueBounds;

        Value = initialValue;
        Maximum = initialMaxValue;
    }

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
        _onValueChanged?.Invoke(_currentValue);
    }
}
