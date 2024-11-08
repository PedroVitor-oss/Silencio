using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
   public Estante[] estantes;
   public PanelaControler panela;
   public int quantObjetivo;
      public MenuManage menuManage;


   void Start(){
    quantObjetivo = estantes.Length;
    Debug.Log("quantidades de objetivos: "+quantObjetivo);
   }

   void Update(){
    int objetivosCompletos = 0;

        for (int i = 0; i < quantObjetivo; i++)
        {
            if (estantes[i] != null && estantes[i].complet)
                objetivosCompletos++;
        }

        if (panela.complet)
        {
            Debug.Log("Panela completa");
        }

        if (objetivosCompletos == quantObjetivo && panela.complet)
        {
            Debug.Log("Todos os objetivos completos, incluindo a panela. Carregando cena de final de jogo...");
            menuManage.WinGame();
            
        }
   }
}
