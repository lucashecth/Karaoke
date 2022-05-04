using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class configuration : MonoBehaviour
{

    // caminho da pasta: @"E:/Google Drive/Karaokê Completo - 32A/Karaokê Completo - 32A/"
    public LeitorPlanilha leitorPlanilha;
    public string pathToMusics;
    public Text pathtoMusicsPH;
    public InputField pathToMusicsInput;
    string stockFilePath;

    // Start is called before the first frame update
    private void Awake()
    {
        //stockFilePath = "E:/Google Drive/Karaokê Completo - 31A/Karaokê Completo - 31A/";
        //pathtoMusicsPH.GetComponent<Text>().text = stockFilePath;
        //pathToMusics = stockFilePath;
        pathtoMusicsPH.text = PlayerPrefs.GetString("pathToMusics");
    }

    void Start()
    {

    }
    public void UpdateFilePath()
    {
        pathToMusics = pathToMusicsInput.text;
        PlayerPrefs.SetString("pathToMusics", pathToMusicsInput.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
