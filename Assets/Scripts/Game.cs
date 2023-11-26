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
    private bool IsLoading = true;

    void Start()
    {
        loadingFile = new LoadingFile(1860f);
        loadingFile.OnFileLoaded += EndLevel_OnFileLoaded;
        loadingBar.minValue = 0;
        loadingBar.maxValue = loadingFile.FileSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLoading)
        {
            loadingFile.Load(speedometrArrow.actualLoadingSpeed);
            loadingBar.value = loadingFile.LoadedSize;
        }
    }

    private void EndLevel_OnFileLoaded(object sender, EventArgs e)
    {
        Debug.Log("File loaded");
        IsLoading = false;
        speedometrArrow.StopLoading();
    }
}
