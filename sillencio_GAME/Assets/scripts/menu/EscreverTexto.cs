using UnityEngine;
using UnityEngine.UI;
using TMPro; // Use isso se for TextMeshPro
using System.Collections;
using FMODUnity;
using FMOD.Studio;

public class EscreverTexto : MonoBehaviour
{
    public TMP_Text uiText; // Ou TMP_Text se estiver usando TextMeshPro
    // public TMP_Text uiText;
    public string fullText;
    public EventReference typingSound;
    public float delay = 0.1f;
    // public AudioSource typingsound;  // Adicione o som de digitação aqui

    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            uiText.text = currentText;

            
                AudioManager.instance.PlayEvent(typingSound,transform.position);
            

            yield return new WaitForSeconds(delay);
        }
    }
}
