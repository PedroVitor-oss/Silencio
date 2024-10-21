using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estante : MonoBehaviour
{
    // Start is called before the first frame update

    public int minBocks = 4;
    public float heightBoock;
    private int inBookcase = 0;
    public Transform estanteTransform;
    void Start(){
    }

    public void DropBoock(){
        inBookcase ++;
    }

    public Vector3 GetPositionBook(){
        Vector3 pos = estanteTransform.position;
        pos.y = pos.y + inBookcase * heightBoock;
        return pos;
    }
}
