using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTime : Effect
{
    public float duration = 0;

    public override void Apply(Character targetCharacter)
    {
        duration -= 1;
    }
}
