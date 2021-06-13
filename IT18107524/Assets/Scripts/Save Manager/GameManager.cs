using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CarterGames.Assets.SaveManager;

public class GameManager : MonoBehaviour
{
    public SaveData _data;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        if(SaveManager.LoadGame() == null)
        {
            _data = new SaveData();
            _data.lifecount = new LifeCount();
            _data.healthbar = new HealthBar();
            SaveManager.SaveGame(_data);
        }
        else
        {
            LoadGame();
        }
    }

    //Save Game
    public void SaveGame()
    {
        SaveManager.SaveGame(_data);
    }


    //Load Game
    public void LoadGame()
    {
        _data = SaveManager.LoadGame();
}

}
