using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;

    public static event Action<GameState> OnGameStateChanged;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateGameState(GameState.TapScreen);
    }

    public void UpdateGameState(GameState newState){
        state = newState;
        
        switch(newState){
            case GameState.TapScreen:
                HandleTapScreen();
                break;
            case GameState.PlayerPlay:
                HandlePlay();
                break;
            case GameState.LevelFinished:
                HandleLevelFinished();
                break;
            case GameState.PlayerDead:
                HandlePlayerDead();
                break;
        }
        
        OnGameStateChanged?.Invoke(newState);

    }

    private void HandlePlayerDead()
    {
        //Retry Butonu aktif olsun
    }

    private void HandleLevelFinished()
    {
       //Next Level butonu gelsin
    }

    private void HandlePlay()
    {
        //oyun başlasın level biterse level finished ölürse dead state.
    }

    private void HandleTapScreen()
    {
        //Taplayınca oyunu başlat
    }

}

public enum GameState {
    TapScreen,
    PlayerPlay,
    LevelFinished,
    PlayerDead
}
