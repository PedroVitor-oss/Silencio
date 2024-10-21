using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator aniFade;
    void Start()
    {
    }

    // Update is called once per frame
    
public void LoadLevel(){
    Debug.Log("start fade out");
            aniFade.SetBool("endFade",true);
    
}
}
