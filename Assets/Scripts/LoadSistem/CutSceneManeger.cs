﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class CutSceneManeger : MonoBehaviour
{
    public VideoPlayer VideoClip;
    public string NextCenaName;
    public string NovoJogo;
    public AudioSource dublagem;
    public Button btn;
    
    // Start is called before the first frame update
    void Start()
    {
        VideoClip.loopPointReached += EndReached;
        btn.onClick.AddListener(NextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        btn.enabled = false;
        btn.interactable = false;
        btn.gameObject.SetActive(false);
        VideoClip.Stop();
        dublagem.mute= true;
        PlayerPrefs.SetString("Scene", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        PlayerPrefs.SetString("Scene", NextCenaName);
        LoadingSisten.LoadLevel(NextCenaName);
    }
    

    public void NewGame()
    {
        Persistence.ResetGame();
        PlayerPrefs.SetString("Scene", NovoJogo);
        LoadingSisten.LoadLevel(NextCenaName);
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }

}
