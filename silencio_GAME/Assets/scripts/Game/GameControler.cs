using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
   public Estante[] estantes;
   public int quantObjetivo;

   void Start(){
    quantObjetivo = estantes.Length;
    Debug.Log("quantidades de objetivos: "+quantObjetivo);
   }

   void Update(){
    int objetivosCompletos = 0;
    for(int i =0;i<quantObjetivo;i++){
        if(estantes[i].complet) 
            objetivosCompletos++;

    }
    if(objetivosCompletos == quantObjetivo)
        Debug.Log("Todos os objetivos completos");
   }
}
