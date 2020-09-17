using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "ScriptableObjects/Potion", order = 2)]
public class Potion : Usable
{
    public List<Effect> effects;
    public override bool Use()
    {
        throw new System.NotImplementedException();
    }
}
