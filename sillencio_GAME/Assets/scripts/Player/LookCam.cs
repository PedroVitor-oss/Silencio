using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookCam : MonoBehaviour
{
    public float mouseSencitify = 100f;
    public Transform playerBody;
    public Transform transformCam;
    float  xRotation;
    Vector2 deltaMouse;

    public StateMental mental;


    private PlayerInput playerInput;
    private InputAction cameraMoveAction;
    private InputAction touchPositionAction;

    public bool inMoveCameraArea;
    public RectTransform moveCameraArea;
    private bool isAndroid = false;
    private Vector2 touchPosition;
    private Vector3 originalPos;
    public Vector3 offset;



     private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        cameraMoveAction = playerInput.actions["MoveCam"];
        touchPositionAction = playerInput.actions["TouchPosition"];
    }


    void Start()
    {
        originalPos = transformCam.position;

        if(Application.platform == RuntimePlatform.Android)
        {
            isAndroid = true;
        }else{

        Cursor.lockState = CursorLockMode.Locked;
        }

        inMoveCameraArea = true;
    }

    // Update is called once per frame
    void Update()
    {
        // originalPos = playerBody.transform.position + new Vector3(-0.0761982203f,5.10422993f,0.0338068008f);
        //VibrarCam();


         if (isAndroid)
        {
            touchPosition = touchPositionAction.ReadValue<Vector2>();
            inMoveCameraArea = RectTransformUtility.RectangleContainsScreenPoint(moveCameraArea, touchPosition);
        }

        deltaMouse = cameraMoveAction.ReadValue<Vector2>();


        float mouseX = deltaMouse.x   * mouseSencitify * Time.deltaTime;
        float mouseY = deltaMouse.y   * mouseSencitify * Time.deltaTime;

        if (inMoveCameraArea) {

            if(isAndroid)
                Debug.Log("inMoveCameraArea");
                
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation,-70,70);
       

       
            transformCam.transform.localRotation = Quaternion.Euler(xRotation,0,0.0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        
    }
    
    private void VibrarCam(){
        
        float shakeAmount = mental.nivelEstresse()/100;


            float x = Random.Range(-shakeAmount, shakeAmount);
            float y = Random.Range(-shakeAmount, shakeAmount);
            
            transformCam.position = playerBody.position + offset  + new Vector3(x, y, 0);
    }
}

