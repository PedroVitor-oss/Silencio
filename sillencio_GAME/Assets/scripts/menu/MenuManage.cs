using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManage : MonoBehaviour
{
     void Start(){
 Cursor.lockState = CursorLockMode.None;
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Menu")
        {

        LoadSceneWithDelay("Menu");
        }else{
            Sair();
        }
    }

    public void FimGame(){
        LoadSceneWithDelay("GameOver");
    }
    public void StartGame()
    {
        LoadSceneWithDelay("Game");
    }

    public void ConfigurationsScreen()
    {
        LoadSceneWithDelay("Configurations");
    }

    public void CreditsScreen()
    {
        LoadSceneWithDelay("Creditos");
    }

    public void MenuScreen()
    {
        LoadSceneWithDelay("Menu");
    }

    // Função genérica que carrega qualquer cena com um atraso
    private void LoadSceneWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        // Aguarda 1 segundo antes de carregar a cena
        yield return new WaitForSeconds(1f);

        // Carrega a cena especificada
        SceneManager.LoadScene(sceneName);
    }
     public void  Sair(){
     Application.Quit();
   }
}
