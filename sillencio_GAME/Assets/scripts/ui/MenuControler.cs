using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    public GameObject painelMobile;
    // Start is called before the first frame update
    void Start()
    {
          if (Application.platform != RuntimePlatform.Android )
        {
            painelMobile.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
