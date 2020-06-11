using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Persistence
{
    private static float _masterV = 1;
    private static float _musicV = 1;
    private static float _sfxV = 1;
    private static float _dialogV = 1;
    private static float _indexSpam = 0;
    private static string _sceneName = "Prolog";
    private static float _tutorial = 0;
    private static float _xp = 0;
    private static int _lvl = 0;

    public static void SaveData()
    {
        PlayerPrefs.SetString("Scene", _sceneName);
        PlayerPrefs.SetFloat("MasterV", _masterV);
        PlayerPrefs.SetFloat("MusicV", _musicV);
        PlayerPrefs.SetFloat("SfxV", _sfxV);
        PlayerPrefs.SetFloat("DialogV", _dialogV);
        PlayerPrefs.SetFloat("Tutorial", _tutorial);
        PlayerPrefs.SetFloat("CurrentXP", _xp);
        PlayerPrefs.SetInt("Lvl", _lvl);
    }

    public static void LoadData()
    {
        _sceneName = PlayerPrefs.GetString("Scene");
        _masterV = PlayerPrefs.GetFloat("MasterV");
        _musicV = PlayerPrefs.GetFloat("MusicV");
        _sfxV = PlayerPrefs.GetFloat("SfxV");
        _dialogV = PlayerPrefs.GetFloat("DialogV");
        _tutorial = PlayerPrefs.GetFloat("Tutorial");
        _lvl =PlayerPrefs.GetInt("Lvl");
        _xp =PlayerPrefs.GetFloat("CurrentXP");
    }

    public static void ResetGame()
    {
        PlayerPrefs.SetString("Scene",_sceneName);
        PlayerPrefs.SetFloat("indexSpam",0);
        PlayerPrefs.SetFloat("Monstro1", 0);
        PlayerPrefs.SetFloat("Monstro2", 0);
        PlayerPrefs.SetFloat("Monstro3", 0);
        PlayerPrefs.SetFloat("Missao", 0);
        PlayerPrefs.SetFloat("Tutorial", 0);
        PlayerPrefs.SetFloat("CurrentXP", 0);
        PlayerPrefs.SetInt("Lvl", 0);
    }
    
}
