using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastSearched : MonoBehaviour
{
    public GetSong getSong;
    public RawImage[] serchedAlbuns;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNewSearch()
    {
        serchedAlbuns[4].texture = serchedAlbuns[3].texture;
        serchedAlbuns[3].texture = serchedAlbuns[2].texture;
        serchedAlbuns[2].texture = serchedAlbuns[1].texture;
        serchedAlbuns[1].texture = serchedAlbuns[0].texture;
        serchedAlbuns[0].texture = getSong.albumCover.texture;
    }
}
