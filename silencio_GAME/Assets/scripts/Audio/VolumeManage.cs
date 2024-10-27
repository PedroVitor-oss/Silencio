using UnityEngine;

public class VolumeManage : MonoBehaviour
{
    public GameObject pointer; // O GameObject que será rotacionado
    public float volume = 0f; // O nível do volume (0 a 1)
    public float rotationMin = 0f; // Rotação mínima (0 graus)
    public float rotationMax = 180f; // Rotação máxima (180 graus)
    public float volumeStep = 0.1f; // Quanto o volume aumenta ou diminui por passo

    // Update is called once per frame
    void Update()
    {
        // Atualizar a rotação do ponteiro com base no volume
        UpdatePointerRotation();
        volume = AudioManager.instance.GetVolume();
    }
    public void addVolume(){

            ChangeVolume(volumeStep);
    }
    public void subVolume(){

            ChangeVolume(-volumeStep);
    }

    // Função para mudar o volume
    void ChangeVolume(float amount)
    {
        volume = Mathf.Clamp(volume + amount, 0f, 1f); // Limitar volume entre 0 e 1
        AudioManager.instance.SetVolume(volume);
    }

    // Função para rotacionar o GameObject baseado no volume
    void UpdatePointerRotation()
    {
        // Calcular a rotação com base no volume
        float zRotation = Mathf.Lerp(rotationMin, rotationMax, volume);
        
        // Aplicar a rotação ao eixo Z do ponteiro
        pointer.transform.rotation = Quaternion.Euler(0, -180, zRotation);
    }
}
