using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect :ScriptableObject
{
    public string description = "";
    public List<Stat> stats;

    public abstract void Apply(Character targetCharacter);
}
