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
    public GameObject textLanterna;

    public EventReference QuedaDaLuzSound;
    public EventReference RuidoRadioSound;
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
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);


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
                        invetario.addItem(interable.item.name);
                        if(interable.item.name == "lanterna")
                        {
                            textLanterna.SetActive(true);
                        }

                    }else{//if (interable.item.indexFunction != 0){//função
                        Debug.Log("Executar função ");
                        switch (interable.item.indexFunction)
                        {
                            case 1://colocar objeto em algun lugar
                                Debug.Log("colocar livro na estante");
                                if(currrentIterable != null ){
                                    // StartCoroutine(MovingItem(currrentIterable,currrentIterable.transform.position,null));
                                    AudioManager.instance.PlayEvent(interable.item.soundEvent,transform.position);
                                    StartCoroutine(MovingItem(currrentIterable,    interable.gameObject.GetComponent<Estante>().GetPositionBook(),interable.transform));
                                    interable.gameObject.GetComponent<Estante>().DropBoock();

                                    if(currrentIterable.item.text == "panela")
                                    {
                                        currrentIterable.GetComponent<PanelaControler>().ColocarNoFogao();
                                    }
                                    currrentIterable = null;
                                }
                            break;
                            case 2://iniciar musica do radio
                                Debug.Log("iniciar Musica do radio");
                              
                                float timeDestroy = 40.0f;
                                Destroy(interable.gameObject,timeDestroy);
                                Invoke("MoreEstress",timeDestroy);
                                AudioManager.instance.PlayEvent(interable.item.soundEvent,transform.position);


                                mental.SetEstresse(0f);
                                mental.SetAddEstresse(0.001f);
                            break;
                            case 3://abrir guarda roupa
                                Debug.Log("Abrir guardar roupa");
                                Animator aniGuardaRoupa = interable.gameObject.GetComponentInParent<Animator>();
                                if(aniGuardaRoupa != null){
                                    Debug.Log("Animator do guarda roupa");
                                    aniGuardaRoupa.SetBool("open",!aniGuardaRoupa.GetBool("open"));
                                }
                                break;
                            case 4://colocar roupa no guardaroupa
                                Debug.Log("colocar rolpas no guarda roupa");
                                
                                if (roupaPrefab != null && invetario.QuantItem()>0)
                                {
                                    int quantItens =  invetario.removeItens("Roupa");
                                    for(int i =0;i<quantItens;i++){
                                        interable.gameObject.GetComponent<Estante>().DropBoock();
                                        Vector3 pos = interable.gameObject.GetComponent<Estante>().GetPositionBook();
                                        Instantiate(roupaPrefab,pos, Quaternion.identity);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("Prefab não encontrado!");
                                }
                                break;
                                case 5://interação com o relogio  almentar estresse
                                    mental.SetAddEstresse(0.5f);
                                break;
                                case 6://ligar a tv
                                    interable.gameObject.GetComponent<TelevisaoManage>().LigarTv();
                                    AudioManager.instance.PlayEvent(interable.item.soundEvent,transform.position);
                                    mental.SetAddEstresse(0.005f);
                                    //inciar 
                                    Invoke("DesligarLuz",50.0f);
                                    break;
                                case 7://abrir gavate
                                  
                                    StartCoroutine(MovingItem(interable,    interable.gameObject.transform.position +    Vector3.forward,interable.transform.parent,false,interable.transform.parent,new Vector3(-90,0,90)));
                                    
                                    break;
                                case 8://ligar a tv
                                  
                                    AudioManager.instance.PlayEvent(interable.item.soundEvent,transform.position);
                                    mental.SetAddEstresse(0.005f);
                                    //inciar 
                                    Invoke("LigarLuz",0.1f);
                                    break;
                                    case 9 :// torneira
                                        interable.GetComponent<ParticleSystem>().Play();
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

    IEnumerator MovingItem(Interable obj, Vector3 posittion, Transform parent,bool tnull = true,Transform startParent = null,Vector3 rotationEuler= default){
        float timer =0;
        if(tnull) obj.transform.SetParent(null);
        else obj.transform.SetParent(startParent);
        while(timer < 1){
            obj.transform.position = Vector3.Lerp(obj.transform.position,posittion, Time.deltaTime * 5);
            timer+=Time.deltaTime;
            yield return  null;

        }

        obj.transform.position = posittion;
        obj.transform.SetParent(parent);
        // if(rotationEuler == null) rotationEuler = Vector3.zero;
        obj.transform.rotation = Quaternion.Euler(rotationEuler);
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
        mental.SetAddEstresse(0.03f);
        AudioManager.instance.SetVolume(0,"musica");
        AudioManager.instance.PlayEvent(RuidoRadioSound,transform.position);
    }
    private void DesligarLuz(){
      
        Light[] lights = FindObjectsOfType<Light>();
        AudioManager.instance.PlayEvent(QuedaDaLuzSound,transform.position);
        AudioManager.instance.SetVolume(1,"tv");

        foreach (Light light in lights)
        {
            mental.SetAddEstresse(0.05f);
            light.enabled = false;
        }
        
    }
    private void LigarLuz(){
      
        Light[] lights = FindObjectsOfType<Light>();
        AudioManager.instance.PlayEvent(QuedaDaLuzSound,transform.position);
        foreach (Light light in lights)
        {
            mental.SetAddEstresse(0.05f);
            light.enabled = true;
        }
        
    }
}
