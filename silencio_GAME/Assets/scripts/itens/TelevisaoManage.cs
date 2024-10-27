using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisaoManage : MonoBehaviour
{
    public Material desligada;
    public Material ligada;
 private MeshRenderer meshRenderer;
    void Start()
    {
         meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public void LigarTv()
    {
         if (meshRenderer != null && meshRenderer.materials.Length > 1)
        {
            // Troca o segundo material pelo novo material
            Material[] materiais = meshRenderer.materials;
            materiais[1] = ligada;
            meshRenderer.materials = materiais;
        }
        else
        {
            Debug.LogWarning("O objeto não tem materiais suficientes.");
        }
    }
}
