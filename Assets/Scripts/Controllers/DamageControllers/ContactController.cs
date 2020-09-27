using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactController : CustomMonoBehaviour
{
    public Entity Owner { get; private set; }

    void Awake()
    {
        Owner = GetComponentInParent<Entity>();
    }

    void OnTriggerEnter(Collider other)
    {
        var targetEntity = other.GetComponentInParent<Entity>();

        if (targetEntity.IsNull())
        {
            return;
        }

        if (targetEntity.AttributesController.TargetType != Owner.AttributesController.TargetType)
        {
            var damageController = targetEntity.gameObject.GetComponent<DamageController>();

            if(damageController.IsNull())
            {
                return;
            }

            damageController.AddDamage(Owner.AttributesController.ContactDamageInfo, targetEntity.gameObject);
        }
    }
}
