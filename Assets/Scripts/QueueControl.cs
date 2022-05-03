using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class QueueControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public LeitorPlanilha leitorPlanilha;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        Debug.Log("Terminou");

        if (leitorPlanilha.quantasEmQueue > 0)
        {
            leitorPlanilha.digitaNumero();
        }
        else
        {
            //retorna pro menu
        }
    }
}
