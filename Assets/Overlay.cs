using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overlay : MonoBehaviour
{

    public TextMeshProUGUI nome;
    public TextMeshProUGUI pontos;

    public void salvar()
    {
        if (nome.text.Length < 2)
            return;

        JogadorPontos jogador = new JogadorPontos();

        jogador.nome = nome.text;
        jogador.pontos = Int32.Parse(pontos.text);

        string caminho = Path.Combine(
            Application.streamingAssetsPath,
            jogador.nome + ".json"
            );


        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        if (File.Exists(caminho))
        {
            try
            {

                string json2 = File.ReadAllText(caminho);

                JogadorPontos jogador2 = JsonUtility.FromJson<JogadorPontos>(json2);

                if (jogador2.pontos >=jogador.pontos)
                {
                    SceneManager.LoadScene("Menu");
                    return;
                }

            }
            catch (System.Exception)
            {

                print("Jogador não encontrado!");

            }
        }

        string json = JsonUtility.ToJson(jogador);

        print("JSON: " + json);

        using (StreamWriter arquivo = new StreamWriter(caminho))
        {
            arquivo.WriteLine(json);
        }

        SceneManager.LoadScene("Menu");

    }



}
