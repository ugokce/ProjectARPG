using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedIntValue
{
    public int Value
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

    public int OldValue { get; private set; }
    public int DeltaValue => Value - OldValue;

    public BonusValue<int> BonusTempValue { get; } = new BonusValue<int>(BonusValue<int>.CalculateAdditiveInt);

    int intialBaseValue;
    int baseValue;
    int minValue;
    int maxValue;

    public RangedIntValue(int baseValue, int minValue, int maxValue)
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

    public static implicit operator int(RangedIntValue rangeIntValue)
    {
        return rangeIntValue.Value;
    }
}