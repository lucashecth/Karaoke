using SimpleJSON;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetSong : MonoBehaviour
{
    public RawImage albumCover, artistPhoto, Background;
    //public Text songNameTEXT, artistNameTEXT;
    public Text searchSongName, searchArtistName;
    public LastSearched lastSearched;


    private readonly string baseSongURL = "http://api.genius.com/search?q=";


    // Start is called before the first frame update
    void Start()
    {
        albumCover.texture = Texture2D.blackTexture;
        //OnButtonGetMusicInfo();
    }

    // Update is called once per frame
    public void Update()
    {/*
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            //string song = "meu%20lugar";
            string song = searchSongName.text + " " + searchArtistName.text;
            Uri.EscapeDataString(song);
            //Uri.EscapeUriString(song);
            StartCoroutine(findSong(song));
        }*/
    }
    public void SearchMusic()
    {
        string song = searchSongName.text + " " + searchArtistName.text;
        Uri.EscapeDataString(song);
        StartCoroutine(findSong(song));
    }
    
    public void OnButtonGetMusicInfo()
    {
        //string song = "meu%20lugar";
        string song = searchSongName.text + " " + searchArtistName.text;
        Uri.EscapeDataString(song);
        //Uri.EscapeUriString(song);
        StartCoroutine(findSong(song));
    }

    IEnumerator findSong(string song)
    {
        string songSearchURL = baseSongURL + song;
        Debug.Log(songSearchURL);

        UnityWebRequest songInfoRequest = UnityWebRequest.Get(songSearchURL);
        songInfoRequest.SetRequestHeader("Authorization", "Bearer 9Ovm7gjgYWsR4rcge4_sKRKBSwT8F-vzX1sQkDkPSQ98o38Ej79cR-SGum9F4Hb5 ");
        //songInfoRequest.SetRequestHeader("Authorization", "Bearer 25SBZHJoLI80AH2u8fdOqNxIaOBc7xC7qJotF0SrCYIgCOvqC4G2kFJn-pH2AZrv ");


        yield return songInfoRequest.SendWebRequest();

        if (songInfoRequest.isNetworkError || songInfoRequest.isHttpError)
        {
            Debug.LogError(songInfoRequest.error);
            yield break;
        }

        JSONNode songInfo = JSON.Parse(songInfoRequest.downloadHandler.text);

        string status = songInfo["meta"]["status"]; //ok if = 200


        JSONNode homonimunSongs = songInfo["response"]["hits"]; //ir até o elemento que é vetor
        string[] songsFounded = new string[homonimunSongs.Count];


        string songName = homonimunSongs[0]["result"]["title"]; //Completar até o objeto desejado
        //songNameTEXT.text = songName;

        string artistName = homonimunSongs[0]["result"]["primary_artist"]["name"]; //Completar até o objeto desejado
        //artistNameTEXT.text = artistName;


        string songCoverURL = homonimunSongs[0]["result"]["song_art_image_url"];

        Debug.Log("nome:" + songName);
        Debug.Log("status:" + status);
        Debug.Log("url:" + songCoverURL);
        //Debug.Log(songsFounded[0]);

        //GetAlbumCover

        UnityWebRequest AlbumCoverRequest = UnityWebRequestTexture.GetTexture(songCoverURL);

        yield return AlbumCoverRequest.SendWebRequest();

        if (AlbumCoverRequest.isNetworkError || AlbumCoverRequest.isHttpError)
        {
            //Debug.LogError(AlbumCoverRequest.error);
            yield break;
        }

        string ArtistPicURL = homonimunSongs[0]["result"]["primary_artist"]["image_url"];
        Debug.Log("url:" + ArtistPicURL);

        //GetSingerPic

        UnityWebRequest ArtistPicRequest = UnityWebRequestTexture.GetTexture(ArtistPicURL);

        yield return ArtistPicRequest.SendWebRequest();

        if (ArtistPicRequest.isNetworkError || ArtistPicRequest.isHttpError)
        {
            //Debug.LogError(AlbumCoverRequest.error);
            yield break;
        }
        //UI

        /*     <----------------------------------------->    */

        albumCover.texture = DownloadHandlerTexture.GetContent(AlbumCoverRequest);
        albumCover.texture.filterMode = FilterMode.Point;

        artistPhoto.texture = DownloadHandlerTexture.GetContent(ArtistPicRequest);
        artistPhoto.texture.filterMode = FilterMode.Point;

        lastSearched.OnNewSearch();
    }
}
