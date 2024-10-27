using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StateMental : MonoBehaviour
{
   public float estresse = 0.0f;
   public float addEstresse = 0.001f;
   public Animator aniObjectve;
   public GameObject ObjFoco;
   public MenuManage menuManage;

   private void Update() {
        estresse += Time.deltaTime * addEstresse;

        //vibração
        float estresseRotation = estresse/5;
        ObjFoco.transform.rotation = Quaternion.Euler(0,0,Random.Range(-estresseRotation,estresseRotation));
        ObjFoco.GetComponent<Graphic>().color = new Color(1,1,1,estresse/5);
        //volume da respiração
        AudioManager.instance.SetVolumeEstresse(estresse/5);

          if(estresse/5 >= 1){
               //fim de game 
               menuManage.FimGame();
          }

   }
   private void OnObjectve(){
    Debug.Log("mostrar ojetivos");
    aniObjectve.SetBool("show",true);
    Invoke("DesativeAniObjective",1);
   }
   public float   nivelEstresse (){
        return estresse;
   }
   private void DesativeAniObjective(){
        aniObjectve.SetBool("show",false);

   }
   public void SetEstresse(float ae)
   {
     estresse = ae;
   }
   public void SetAddEstresse(float ae)
   {
     addEstresse = ae;
   }
}
