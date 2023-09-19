using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void jogar()
    {

        SceneManager.LoadScene("Jogo");

    }

    public void sair()
    {

        Application.Quit();

    }

    public void voltar()
    {

        SceneManager.LoadScene("Menu");

    }

    public void placar()
    {
        SceneManager.LoadScene("Placar");
    }

}
