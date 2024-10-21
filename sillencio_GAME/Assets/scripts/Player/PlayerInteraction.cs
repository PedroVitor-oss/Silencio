using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roupaPrefab;
    public float rayDist = 5;
    public Camera cam;
    public Transform handTransform;

    private Interable currrentIterable;

    private bool click = false;

    private bool takeItem = false;

    public StateMental mental;
    public Inventario invetario;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIterable();
        click = false;
        
    }
    void CheckIterable()
    {
        RaycastHit hit;
        // Vector2 rayOrigin  = cam.ViewportToWorldPoint(new Vector3( 0.5f,0.5f,0.5f));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit))
        {
            Interable interable = hit.collider.GetComponent<Interable>();
            if(interable!=null)
            {
                UIManage.insatance.SetHandCursor(true);
               
                if(click){
                    

                    Debug.Log(interable.item);
                    if(interable.item.take){//pegar 
                        if(currrentIterable == null)
                            currrentIterable = interable;
                        
                        takeItem = true;
                        Invoke("SetTAkeItemtoFalse",1);
                        Debug.Log("Take Item ");
                        currrentIterable.transform.rotation = Quaternion.Euler(0,0,0);
                        StartCoroutine(MovingItem(currrentIterable,handTransform.position,handTransform));
                    }else if(interable.item.collect){
                        Debug.Log("coletar item");
                        Destroy(interable.gameObject);
                        invetario.addItem(interable.gameObject.name);

                    }else{//if (interable.item.indexFunction != 0){//função
                        Debug.Log("Executar função ");
                        switch (interable.item.indexFunction)
                        {
                            case 1:
                                Debug.Log("colocar livro na estante");
                                if(currrentIterable != null ){
                                    // StartCoroutine(MovingItem(currrentIterable,currrentIterable.transform.position,null));
                                    AudioManager.instance.PlayEvent(interable.item.soundEvent,transform.position);
                                    StartCoroutine(MovingItem(currrentIterable,    interable.gameObject.GetComponent<Estante>().GetPositionBook(),interable.transform));
                                    interable.gameObject.GetComponent<Estante>().DropBoock();
                                    currrentIterable = null;
                                }
                            break;
                            case 2:
                                Debug.Log("iniciar Musica do radio");
                              
 
                                Destroy(interable.gameObject,10.0f);
                                Invoke("MoreEstress",10.0f);
                                AudioManager.instance.PlayEvent(interable.item.soundEvent,transform.position);


                                mental.SetEstresse(0f);
                                mental.SetAddEstresse(0.001f);
                            break;
                            case 3:
                                Debug.Log("Abrir guardar roupa");
                                Animator aniGuardaRoupa = interable.gameObject.GetComponentInParent<Animator>();
                                if(aniGuardaRoupa != null){
                                    Debug.Log("Animator do guarda roupa");
                                    aniGuardaRoupa.SetBool("open",!aniGuardaRoupa.GetBool("open"));
                                }
                                break;
                            case 4:
                                Debug.Log("colocar rolpas no guarda roupa");
                                
                                Vector3 pos = interable.gameObject.GetComponent<Estante>().GetPositionBook();
                                 if (roupaPrefab != null && invetario.QuantItem()>0)
                                {
                                    Instantiate(roupaPrefab,pos, Quaternion.identity);
                                }
                                else
                                {
                                    Debug.LogError("Prefab não encontrado!");
                                }
                                break;
                                case 5:
                                    mental.SetAddEstresse(0.5f);
                                break;
                        }
                    }
                }
            }else{
                UIManage.insatance.SetHandCursor(false);

            }
        }else{
                UIManage.insatance.SetHandCursor(false);

        }
    }

    IEnumerator MovingItem(Interable obj, Vector3 posittion, Transform parent){
        float timer =0;
        obj.transform.SetParent(null);
        while(timer < 1){
            obj.transform.position = Vector3.Lerp(obj.transform.position,posittion, Time.deltaTime * 5);
            timer+=Time.deltaTime;
            yield return  null;

        }

        obj.transform.position = posittion;
        obj.transform.SetParent(parent);
        obj.transform.rotation = Quaternion.Euler(0,0,0);
    }

    private void OnTakeItem()
    {
       click = true;
    }
    public bool isTakeItem(){
        return takeItem;
    }
    public void SetTakeItemtoFalse(){
        takeItem = false;
    }
    private void MoreEstress(){
        mental.SetAddEstresse(0.01f);
    }
}
