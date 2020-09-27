using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedFloatValue
{
    public float Value
    {
        get
        {
            return Mathf.Clamp(baseValue + BonusTempValue.Result, minValue, maxValue);
        }

        set
        {
            OldValue = Value;
            baseValue = Mathf.Clamp(value, minValue, maxValue);
        }
    }

    public float OldValue { get; private set; }
    public float DeltaValue => Value - OldValue;

    public BonusValue<float> BonusTempValue { get; } = new BonusValue<float>(BonusValue<float>.CalculateAdditiveFloat);

    float intialBaseValue;
    float baseValue;
    float minValue;
    float maxValue;

    public RangedFloatValue(float baseValue, float minValue, float maxValue)
    {
        this.baseValue = baseValue;
        this.minValue = minValue;
        this.maxValue = maxValue;

        OldValue = baseValue;
        intialBaseValue = baseValue;
    }

    public void Reset()
    {
        baseValue = intialBaseValue;
        BonusTempValue.Clear();
    }

    public static implicit operator float(RangedFloatValue rangeFloatValue)
    {
        return rangeFloatValue.Value;
    }
}
