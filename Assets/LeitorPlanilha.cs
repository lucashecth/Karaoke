using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;
using System.IO;

public class Musicas
{
    public string nome, cantor, codigo;
}

//-------------------------------------------------------------------------------------
//  Controles Programados no Karaokê (Seja para teclado numérico ou controle.
//
//
//     / - Limpa o visor numérico e permite escrever outro número alem de trazer a barra do text input de volta
//     * - Play e Pause nas músicas
//     - - Stop na música e retorna ao menu de canções
//
//
//-----------------------------------------------------------------------------------------

public class LeitorPlanilha : MonoBehaviour
{


    public VideoPlayer videofile;
    public Text pesquisaNumero, nomeCancao, numeroCancao, nomeCantor;
    public string recebeNumero;
    string aspas;
    public GameObject Canvas, telaMenu, nomeCancaoGO;
    public InputField mainInputField;
    int hitCounter, hitCounterPlay, hitCounterTela;
    bool isPaused;
    /*------------------------------------------------ public Text recebeCancaoTela;--------------------------------------------------*/

    public TextAsset planilha;
    List<Musicas> Music = new List<Musicas>();

    // Use this for initialization
    void Start()
    {
        mainInputField.ActivateInputField();
        string[] data = planilha.text.Split('\n');
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] linha = data[i].Split(';');
            Musicas videoke = new Musicas();
            videoke.cantor = linha[0];
            videoke.codigo = linha[1];
            videoke.nome = linha[2];
            Music.Add(videoke);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) //funções de entrada de música
        {
            recebeNumero = pesquisaNumero.text.ToString();
            if (System.IO.File.Exists(@"E:/Google Drive/Karaokê Completo - 32A/Karaokê Completo - 32A/" + recebeNumero + ".mp4"))
            {

                NomeMusica();
                NomeCantor();
                if (hitCounter == 1)
                {
                    hitCounter = 0;
                    digitaNumero();

                }

                hitCounter = 1;

            }
            else
            {
                nomeCancao.text = "<< CANÇÃO NÃO ENCONTRADA >>";
            }
        }

        if (videofile.isPlaying)
        {
            telaMenu.SetActive(false);
            hitCounterTela = 1;
        }
        if (!videofile.isPlaying && isPaused == false)
        {
            telaMenu.SetActive(true);
            if (hitCounterTela == 1)
            {
                mainInputField.text = "";
                nomeCancao.text = "";
                mainInputField.ActivateInputField();
                hitCounter = 0;
                hitCounterTela = 0;
            }

        }

        if (Input.GetKeyDown(KeyCode.KeypadDivide)) //Apaga o numero da canção
        {
            mainInputField.text = "";
            nomeCancao.text = "";
            mainInputField.ActivateInputField();
            hitCounter = 0;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            if (hitCounterPlay == 1)
            {
                play();
                Debug.Log("Play");
                hitCounterPlay = 0;
            }
            else
            {

                pause();
                Debug.Log("Pause");
                hitCounterPlay = 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            videofile.Stop();
            hitCounter = 0;
            telaMenu.SetActive(true);
            nomeCancao.text = "";
            mainInputField.text = "";

        }

    }
    //------------------------------------------------------------------------------------------------------------------------------------------------




    /*Android Path*/  // Caminho da pasta de arquivos do Android
                      //videofile.url = "/storage/emulated/0/Download/03328.mp4";

    /*Windows Path*/ //Caminho da pasta de arquivos do Windows 
                     //videofile.url = "D:/Google Drive/Karaokê Completo - 32A/Karaokê Completo - 32A/03328.mp4";

    /*Xiaomi MiBox 3 Path*/ // Caminho da pasta de arquivos da MiBox
                            // videofile.url = "/storage/0A5497D85497C53B/Google Drive/Karaokê Completo - 32A/Karaokê Completo - 32A/"

    //Debug.Log(videofile.url);
    //animTX.Play("sai_digiteONumero");




    //------------------------------------------------------------------------------------------------------------------------------------------------

    public void digitaNumero()
    {

        recebeNumero = pesquisaNumero.text.ToString();

        //Existe a música selecionada no HD?    
        // if (System.IO.File.Exists(@"E:/Google Drive/Karaokê Completo - 32A/Karaokê Completo - 32A/" + recebeNumero + ".mp4"))
        //if (System.IO.File.Exists(@"/storage/0A5497D85497C53B/Google Drive/Karaokê Completo - 32A/Karaokê Completo - 32A/" + recebeNumero + ".mp4")) 
        //{
        videofile.url = "E:/Google Drive/Karaokê Completo - 32A/Karaokê Completo - 32A/" + recebeNumero + ".mp4";
        //telaMenu.SetActive(false);
        numeroCancao.text = "<" + recebeNumero + ">";
        //videofile.url = "/storage/0A5497D85497C53B/Google Drive/Karaokê Completo - 32A/Karaokê Completo - 32A/" + recebeNumero + ".mp4";
        //GetComponent<Canvas>(
        // }
        //else
        //{
        nomeCancao.text = "<<CANÇÃO NÃO ENCONTRADA>>";
        // }

    }
    public void play()
    {
        videofile.Play();
        isPaused = false;
    }

    public void pause()
    {
        videofile.Pause();
        telaMenu.SetActive(false);
        isPaused = true;
    }




    public void NomeMusica()
    {
        for (int i = 0; i < Music.Count; i++)
        {
            nomeCancaoGO.SetActive(true);
            if (Music[i].codigo == recebeNumero)
                nomeCancao.text = Music[i].nome;

        }

    }
    public void NomeCantor()
    {
        for (int i = 0; i < Music.Count; i++)
        {
            if (Music[i].codigo == recebeNumero)
                nomeCantor.text = Music[i].cantor;

        }
    }


}

