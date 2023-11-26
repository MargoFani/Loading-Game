using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private LoadingFile loadingFile;
    [SerializeField] private Arrow speedometrArrow;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private Text loadedSizeText;
    [SerializeField] private Text plyerPointsText;
    [SerializeField] public int PlayerPoints { get; set; }

    [SerializeField] private Image effectImage;
    [SerializeField] private Text effectDescription;

    private int allLoadedFiles = 0;

    [SerializeField] private Text allLoadedFilesText;
    private bool IsLoading = true;

    void Start()
    {
        PlayerPoints = 250;
        effectImage.enabled = false;
        effectDescription.enabled = false;

        loadingFile = new LoadingFile(180f);
        loadingFile.OnFileLoaded += EndLevel_OnFileLoaded;
        loadingBar.minValue = 0;
        loadingBar.maxValue = loadingFile.FileSize;
        allLoadedFilesText.text = allLoadedFiles.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        plyerPointsText.text = PlayerPoints.ToString();

        if (IsLoading)
        {
            loadingFile.Load(speedometrArrow.actualLoadingSpeed*Time.deltaTime);
            loadingBar.value = loadingFile.LoadedSize;
            loadedSizeText.text = Math.Ceiling(loadingFile.LoadedSize) + " Mb / " + loadingFile.FileSize + " Mb ";
        }
        
    }

    private void EndLevel_OnFileLoaded(object sender, EventArgs e)
    {
        Debug.Log("File loaded");
        IsLoading = false;

        System.Random rnd = new System.Random();
        int value = rnd.Next(46, 1024);
        loadingFile = new LoadingFile(value);

        loadingFile.OnFileLoaded += EndLevel_OnFileLoaded;
        loadingBar.value = loadingFile.LoadedSize;

        loadingBar.maxValue = loadingFile.FileSize;
        //speedometrArrow.StopLoading();
        IsLoading = true;

        allLoadedFiles++;
        allLoadedFilesText.text = allLoadedFiles.ToString();


    }

    public void SetEffectInfo(Sprite effectIcon, string description)
    {
        effectImage.enabled = true;
        effectDescription.enabled = true;
        effectImage.sprite = effectIcon;
        effectImage.SetNativeSize();
        effectDescription.text = description;

    }
}
