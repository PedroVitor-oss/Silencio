using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManage : MonoBehaviour
{
    // Start is called before the first frame update

    public static UIManage insatance;

    public GameObject cursor;
    void Start()
    {
        insatance = this;
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void  SetHandCursor(bool state)
    {
        cursor.SetActive(state);
    }
}
