using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public bool take = false;
    public bool collect = false;
    public EventReference soundEvent;

    public string text;
    public int indexFunction = 0;
}
