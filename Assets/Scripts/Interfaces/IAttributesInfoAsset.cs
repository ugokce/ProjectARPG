using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttributesInfoAsset
{
    EntityType EntityType { get; }

    int MinAttributeValue { get; }
    int MaxAttributeValue { get; }
}