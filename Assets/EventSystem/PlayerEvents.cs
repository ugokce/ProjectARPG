using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventWithVector3 : UnityEvent<Vector3>
{}

public class EventWithFloat : UnityEvent<float>
{}

public class GenericEvent<T> : UnityEvent<T>
{ }

public class PlayerEvents
{
    //move speed
    public EventWithVector3 onPlayerMove;
    //rotation direction
    public EventWithFloat onPlayerTurn;
    public UnityEvent onPlayerJump;
    //fall speed
    public EventWithFloat onPlayerGrounded;
    //attack direction
    public UnityEvent onPlayerAttack;
    //run
    public GenericEvent<bool> onPlayerPressedShift;

    public PlayerEvents()
    {
        onPlayerJump = new UnityEvent();
        onPlayerMove = new EventWithVector3();
        onPlayerTurn = new EventWithFloat();
        onPlayerGrounded = new EventWithFloat();
        onPlayerAttack = new UnityEvent();
        onPlayerPressedShift = new GenericEvent<bool>();
    }
}
