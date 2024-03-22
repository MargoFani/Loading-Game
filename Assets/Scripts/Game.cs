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
    [SerializeField] public int PlayerPoints { get; set; } = 0;

    [SerializeField] private Image effectImage;
    [SerializeField] private Text effectDescription;

    private float timer = 0f;
    [SerializeField] private Text timerText;

    private int allLoadedFiles = 0;

    [SerializeField] private Text allLoadedFilesText;
    private bool IsLoading = true;

    public bool IsEffectActive = false;
    private int activeEffect = -1;


    private int allLoadedSize = 0;

    [SerializeField] private AudioSource fileLoadedSound;
    [SerializeField] private PopUpSystem popUpSystem;

    [SerializeField] private List<float> downloadedFiles = new List<float>();
    [SerializeField] private AllCollections allCollections;
    void Start()
    {
        //PlayerPoints = 1450;
        effectImage.enabled = false;
        effectDescription.enabled = false;
        timerText.enabled = false;

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
        if (timerText.enabled)
        {
            timer -= Time.deltaTime;
            timerText.text = $"{timer:F1}";

            if (timer <= 0)
            {
                effectImage.enabled = false;
                effectDescription.enabled = false;
                timerText.enabled = false;
                IsEffectActive = false;
                StopEffect(activeEffect);
                activeEffect = -1;                                
            }
                
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
    public void SetEffectInfo(Sprite effectIcon, string description)
    {
        effectImage.enabled = true;
        effectDescription.enabled = true;
        effectImage.sprite = effectIcon;
        effectImage.SetNativeSize();
        effectDescription.text = description;

    }

    public void StartEffect(int effectNumber)
    {
        
        Debug.Log("StartEffect: " + effectNumber);
        switch (effectNumber)
        {
            // new ShopItem(100, "��������", "� ������ ��������� ��������, ���� ��������� ������. �������� �������� ��������� �� 15 Mb. ���� ����� �� ���������.", -1),
            //TargetSpeedOfLoading + 20 
            case 0:
                speedometrArrow.IncreaseAngle(-40);
                StartEffectTimer(0, 5);
                return;
            //new ShopItem(350, "����", "��� �� ������, ���� = �������. ������ �� ������ �������� � 2 ���� �� 30 ������.", 30)
            //SpeedUpAngle * 2 �� 30 ������
            case 1:
                speedometrArrow.SpeedUpAngle = speedometrArrow.SpeedUpAngle * 2;
                StartEffectTimer(1, 30);
                return;
            //new ShopItem(120, "�������", "��� ��������� ������ � ������, ����� ������ �� ������ ��� ��������. �������� �������� ��������� �� 10 Mb � �� ����������� � ������� 30 ������.", 30),
            //CanDecrise = false �� 30 ������ and TargetSpeedOfLoading + 15 
            case 2:
                speedometrArrow.IncreaseAngle(-30);
                speedometrArrow.CanDecrise = false;
                StartEffectTimer(2, 30);
                return;
            //new ShopItem(440, "����� ����", "����� - ���� �������������. �������� �� ���������� ���� 10 Mb/c � ������� 30 ������.", 30),
            //��������� ����� 
            case 3:
                speedometrArrow.CanClick = false;
                StartEffectTimer(3, 30);
                return;
            //new ShopItem(110, "������", "����� � �������� �����������������. �������� �� ����� ������ � ������� 30 ������.", 30)
            //CanDecrise = false �� 30 ������
            case 4:
                speedometrArrow.CanDecrise = false;
                StartEffectTimer(2,30);
                return;
        }
                   
            
    }

    public void StartEffectTimer(int active, int duration)
    {
        Debug.Log("StartEffectTimer: " + active);
        timerText.enabled = true;
        timer = duration;
        activeEffect = active;
        IsEffectActive = true;
    }

    public void StopEffect(int effectNumber)
    {
        Debug.Log("StopEffect: " + effectNumber);
        switch (effectNumber)
        {
            // new ShopItem(100, "��������", "� ������ ��������� ��������, ���� ��������� ������. �������� �������� ��������� �� 15 Mb. ���� ����� �� ���������.", -1),
            //������ �� ����
            case 0:
                return;
            //new ShopItem(350, "����", "��� �� ������, ���� = �������. ������ �� ������ �������� � 2 ���� �� 30 ������.", 30)
            case 1:
                //SpeedUpAngle/2
                speedometrArrow.SpeedUpAngle = speedometrArrow.SpeedUpAngle/2;
                return;
            //new ShopItem(120, "�������", "��� ��������� ������ � ������, ����� ������ �� ������ ��� ��������. �������� �������� ��������� �� 10 Mb � �� ����������� � ������� 30 ������.", 30),
            case 2:
                speedometrArrow.CanDecrise = true;
                return;
            //new ShopItem(440, "����� ����", "����� - ���� �������������. �������� �� ���������� ���� 10 Mb/c � ������� 30 ������.", 30),
            case 3:
                speedometrArrow.CanClick = true;
                return;
            //new ShopItem(110, "������", "����� � �������� �����������������. �������� �� ����� ������ � ������� 30 ������.", 30)
            case 4:
                speedometrArrow.CanDecrise = true;
                return;
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
