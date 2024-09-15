using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterResources : MonoBehaviour
{
    [SerializeField]
    public Character character;
    
    [SerializeField]
    public Emotion emotion;
}

public enum Character
{
    MONOKUMA,
    CHIAKI_NANAMI
}

public enum Emotion
{
    angry,
    eat,
    happy,
    hold,
    idle,
    idleAngry,
    idleHappy,
    look,
    lookHappy,
    pointForward,
    pointUp,
    pout,
    question,
    retard,
    sad,
    sleep,
    sleepy,
    sulk,
    sulkHood,
    think,
    goof,
    bomb,
    laugh,
    perv,
    bye
}