using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BonusValue<T>
{
    public T Result
    {
        get
        {
            if (updateResultOnEveryCall)
                CalculateResult();

            return result;
        }
    }

    public int OwnerCount
    {
        get
        {
            return ownerDict.Count;
        }
    }

    Dictionary<object, BonusValueInfo<T>> ownerDict = new Dictionary<object, BonusValueInfo<T>>();
    T result;
    bool updateResultOnEveryCall;

    System.Func<Dictionary<object, BonusValueInfo<T>>, T> calculateFunction;
    System.Action<T, T> resultChangedAction;

    public BonusValue(System.Func<Dictionary<object, BonusValueInfo<T>>, T> calculateFunction, System.Action<T, T> resultChangedAction = null, bool precalculateResult = true, bool updateResultOnEveryCall = false)
    {
        this.calculateFunction = calculateFunction;
        this.resultChangedAction = resultChangedAction;
        this.updateResultOnEveryCall = updateResultOnEveryCall;

        if (precalculateResult)
            CalculateResult();
    }

    public BonusValueInfo<T> AddValue(object owner, T value)
    {
        BonusValueInfo<T> bonusValueInfo = null;

        if (!ownerDict.ContainsKey(owner))
        {
            bonusValueInfo = new BonusValueInfo<T>(value);
            ownerDict.Add(owner, bonusValueInfo);
            CalculateResult();
        }
        else
        {
            Debug.Log($"{nameof(BonusValue<T>)} => Owner already exists!");
        }

        return bonusValueInfo;
    }

    public void RemoveValue(object owner)
    {
        if (ownerDict.ContainsKey(owner))
        {
            ownerDict.Remove(owner);
            CalculateResult();
        }
        else
        {
            Debug.Log($"{nameof(BonusValue<T>)} => There is no such owner!");
        }
    }

    void CalculateResult()
    {
        var oldResult = result;
        result = calculateFunction(ownerDict);
        resultChangedAction?.Invoke(result, oldResult);
    }

    public void Clear()
    {
        ownerDict.Clear();
        CalculateResult();
    }

    public static implicit operator T(BonusValue<T> bonusValue)
    {
        return bonusValue.Result;
    }

    public static int CalculateAdditiveInt(Dictionary<object, BonusValueInfo<int>> ownerDict)
    {
        int result = 0;

        foreach (var item in ownerDict)
        {
            result += item.Value.Value;
        }

        return result;
    }

    public static float CalculateAdditiveFloat(Dictionary<object, BonusValueInfo<float>> ownerDict)
    {
        float result = 0f;

        foreach (var item in ownerDict)
        {
            result += item.Value.Value;
        }

        return result;
    }

    public static Vector3 CalculateAdditiveVector(Dictionary<object, BonusValueInfo<Vector3>> ownerDict)
    {
        Vector3 result = Vector3.zero;

        foreach (var item in ownerDict)
        {
            result += item.Value.Value;
        }

        return result;
    }

    public static float CalculateFactorFloat(Dictionary<object, BonusValueInfo<float>> ownerDict)
    {
        float result = 1f;

        foreach (var item in ownerDict)
        {
            result *= item.Value.Value;
        }

        return result;
    }

    public static float CalculatePercentageStackForSharedBonuses(Dictionary<object, BonusValueInfo<float>> ownerDict)
    {
        if (ownerDict.Values.Count == 0)
            return 0f;

        return ownerDict.Values.Select(x => x.Value).Max();
    }

    public static bool CalculateIfAnyTrue(Dictionary<object, BonusValueInfo<bool>> ownerDict)
    {
        foreach (var owner in ownerDict)
        {
            if (owner.Value.Value)
            {
                return true;
            }
        }

        return false;
    }
}

public class BonusValueInfo<T>
{
    public T Value { get; set; }

    public BonusValueInfo(T value)
    {
        Value = value;
    }
}