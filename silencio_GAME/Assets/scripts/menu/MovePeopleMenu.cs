using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePeopleMenu : MonoBehaviour
{
    public float speed;
    private int direction = 1;

    public float distance = 20;

    void Update(){
        transform.Translate(transform.right * speed * direction * Time.deltaTime);

        if(transform.position.x>= distance ){
            direction = 1;
            transform.rotation  = Quaternion.Euler(0,-90,0);
        } 
        if(transform.position.x<= -distance){
            direction = -1;
            transform.rotation  = Quaternion.Euler(0,90,0);
        }
    }
}
