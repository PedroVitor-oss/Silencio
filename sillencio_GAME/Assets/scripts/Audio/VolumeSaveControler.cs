using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class VolumeSaveControler : ScriptableObject
{
    public float _volume;

    public float Volume
    {
        get { return _volume; }
        set { _volume = Mathf.Clamp(value, 0f, 1f); } // Limitar entre 0 e 1
        
    }

    
}
