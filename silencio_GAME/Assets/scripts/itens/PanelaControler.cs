using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelaControler : MonoBehaviour
{

    public RectTransform positionTimer;
    public Image timerFill;
    public Transform transformTimer;
    public GameObject fireObj;
    public GameObject Canvas;
    public float timer = 5;
    private float maxTimer = 5;
    public float heightTimerUI = 1;
    public bool complet = false;


    void Start()
    {
        maxTimer = timer; 
    }

    public void Update()
    {
        if (fireObj.active && timer>0)
        {
            timer -= Time.deltaTime;
            timerFill.fillAmount  = timer/maxTimer;
        }

        if(timer<=0)
        {
            complet = true;
        }

        // Primeiro, obtenha o componente RectTransform do seu canvas
        RectTransform CanvasRect = Canvas.GetComponent<RectTransform>();

        // Calcule a posição do elemento UI
        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(transformTimer.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f))
        );

        // Defina a posição do elemento UI
        positionTimer.anchoredPosition = WorldObject_ScreenPosition;

        // Calcule a distância da câmera ao objeto
        float distance = Vector3.Distance(Camera.main.transform.position, transformTimer.position);

        // Ajuste o tamanho do elemento UI com base na distância
        float scaleFactor = heightTimerUI / distance; // Você pode ajustar essa fórmula conforme necessário
        positionTimer.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

    }
    public void ColocarNoFogao()
    {
        Invoke("AtivarFogao", 1);
    }
    public void AtivarFogao()
    {
        fireObj.SetActive(true);
        timerFill.enabled = true;

    }
}
