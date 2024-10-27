using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovPlayer : MonoBehaviour
{
    public CharacterController cc; 
    public PlayerInteraction playerInteraction;
    public float speed = 5;
    public float yVelocity = -2f;
    float vertical,horizontal;
    [Header("Animation")]
    public Animator ani;
    public Transform transAni;
    [Header("Estado Mental")]
    public StateMental ment;
    


    void Start()
    {
        cc = GetComponent<CharacterController>();
        ment = GetComponent<StateMental>();
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal = Input.GetAxis("Horizontal");// isso deveria esta no Update 
        // vertical = Input.GetAxis("Vertical");

        transAni.position = transform.position;
        transAni.rotation = transform.rotation;
       
        Vector3 dir = transform.right * horizontal + transform.forward * vertical;
        dir.y = yVelocity; //new Vector3(horizontal,yVelocity,vertical);
        cc.Move(dir * speed * Time.deltaTime);

        //animation 
        ani.SetFloat("vertical",vertical);
        ani.SetBool("showEstresse",false);
    }

    private void OnMove(InputValue  value)
    {
        horizontal = value.Get<Vector2>().x;
        vertical = value.Get<Vector2>().y;
    }

    private void OnTakeItem()
    {
        if(playerInteraction.isTakeItem()){
            // ani.SetBool("takeItem",true);

            Invoke("DesativeAniTakeItem",1);
            Debug.Log("Iniciar animação de take item");
       }
    }
    private void DesativeAniTakeItem()
    {
        ani.SetBool("takeItem",false);
        playerInteraction.SetTakeItemtoFalse();
    }
    private void OnShowEstresse(){
        Debug.Log("mostrar estresse com tremor de mãos");
        ani.SetFloat("estresse",ment.nivelEstresse());
        ani.SetBool("showEstresse",true);
    }

    
    
}
