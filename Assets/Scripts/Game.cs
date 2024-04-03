using Assets.Scripts;
using Assets.Scripts.Collections;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private LoadingFile loadingFile;
    [SerializeField] private Arrow speedometrArrow;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private Text loadedSizeText;
    [SerializeField] private Text plyerPointsText;
    [SerializeField] public int PlayerPoints { get; set; } = 1000;    

    private int allLoadedFiles = 0;

    [SerializeField] private Text allLoadedFilesText;
    private bool IsLoading = true;

    private int allLoadedSize = 0;

    [SerializeField] private AudioSource fileLoadedSound;
    [SerializeField] private PopUpSystem popUpSystem;

    [SerializeField] private List<float> downloadedFiles = new List<float>();
    [SerializeField] private AllCollections allCollections;
    void Start()
    {
        loadingFile = new LoadingFile(180f);
        loadingFile.OnFileLoaded += EndLevel_OnFileLoaded;
        loadingBar.minValue = 0;
        loadingBar.maxValue = loadingFile.FileSize;
        allLoadedFilesText.text = allLoadedFiles.ToString();

        popUpSystem.OnPopUpClose += Continue_OnPopUpClose;
        popUpSystem.OnPopUpFileSave += Continue_OnFileSave;

        allCollections.Init();
    }

    // Update is called once per frame
    void Update()
    {
        plyerPointsText.text = PlayerPoints.ToString();

        if (IsLoading)
        {
            loadingFile.Load(speedometrArrow.actualLoadingSpeed * Time.deltaTime);
            loadingBar.value = loadingFile.LoadedSize;
            loadedSizeText.text = Math.Ceiling(loadingFile.LoadedSize) + " Mb / " + loadingFile.FileSize + " Mb ";
        }
        
    }

    private void EndLevel_OnFileLoaded(object sender, EventArgs e)
    {
        fileLoadedSound.Play();
        Debug.Log("File loaded");
        IsLoading = false;
        allLoadedFiles++;
        popUpSystem.PopUp();
    }

    private void Continue_OnFileSave(object sender, EventArgs e)
    {
        System.Random rnd = new System.Random();
        int randomMemId = rnd.Next(0, 25);
        allCollections.mems[randomMemId].isSaved = true;

        Debug.Log("loadingFile.FileSize " + loadingFile.FileSize);
        Debug.Log($"mem id {randomMemId}, rarity {allCollections.mems[randomMemId].rarity}");
        downloadedFiles.Add(loadingFile.FileSize);

        CountPoints();
        CreateNewLoadingFile();
    }
    private void Continue_OnPopUpClose(object sender, EventArgs e)
    {
        CountPoints();
        CreateNewLoadingFile();
    }
    private void CreateNewLoadingFile()
    {
        System.Random rnd = new System.Random();
        int value = rnd.Next(46, 1024);
        loadingFile = new LoadingFile(value);

        loadingFile.OnFileLoaded += EndLevel_OnFileLoaded;
        loadingBar.value = loadingFile.LoadedSize;

        loadingBar.maxValue = loadingFile.FileSize;
        //speedometrArrow.StopLoading();
        IsLoading = true;
        allLoadedFilesText.text = allLoadedFiles.ToString();
    }
    private void CountPoints()
    {
        allLoadedSize += (int)loadingFile.FileSize;

        int pointsPerDownloadedSize = 50;
        int downloadedSize = 300;

        if (allLoadedSize - downloadedSize > 0)
        {
            do
            {
                PlayerPoints += pointsPerDownloadedSize;
                allLoadedSize -= downloadedSize;

            } while (allLoadedSize - downloadedSize > 0);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
