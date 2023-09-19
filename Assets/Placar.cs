using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Placar : MonoBehaviour
{

    public TextMeshProUGUI placar;

    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath);

        if (dir.GetFiles().Length <= 0)
        {
            return;
        } 

        List<JogadorPontos> lista = new List<JogadorPontos>();

        foreach (FileInfo arquivo in dir.GetFiles())
        {
            try
            {

                string json = File.ReadAllText(Application.streamingAssetsPath + "/" + arquivo.Name);

                JogadorPontos jogador = JsonUtility.FromJson<JogadorPontos>(json);
                print(jogador.nome);
                lista.Add(jogador);

            }
            catch (System.Exception)
            {

                print("Jogador não encontrado!");

            }
        }

        placar.text = "";

        lista.Sort();

        for (int i = 0; i < Math.Min(12, lista.Count); i++)
        {
            print(lista[i].pontos);
            placar.text += (i + 1) + "º) " + lista[i].ToString() + "\n";

        }

        //print(lista[1].pontos > lista[2].pontos);

    }

}
