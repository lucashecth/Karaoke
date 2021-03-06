using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class QueueControl : MonoBehaviour
{
    public VideoPlayer vid;
    public LeitorPlanilha leitorPlanilha;
    public GameObject menu, hudInMusic;


    void Start() { vid.loopPointReached += CheckOver; }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {

        if (leitorPlanilha.quantasEmQueue > 0)
        {
            leitorPlanilha.digitaNumero();
        }
        else
        {
            hudInMusic.SetActive(false);
            menu.SetActive(true);
            Debug.Log("Acabou a Queue");
        }
    }

}