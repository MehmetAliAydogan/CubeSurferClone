using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _startButton, _retryButton, _nextLevelButton;
    void Awake() 
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy()
    {
         GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state){
        _startButton.gameObject.SetActive(state == GameState.TapScreen);
        _retryButton.gameObject.SetActive(state == GameState.PlayerDead);
        _nextLevelButton.gameObject.SetActive(state == GameState.LevelFinished);
    } 
    // Start is called before the first frame update
    void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _retryButton.onClick.AddListener(Retry);
        _nextLevelButton.onClick.AddListener(NextLevel);

    }

    public void StartGame(){
        GameManager.Instance.UpdateGameState(GameState.PlayerPlay);
    }

    public void Retry(){
        GameManager.Instance.UpdateGameState(GameState.PlayerPlay);
        SceneManager.LoadScene("Level1");
    }

    public void NextLevel(){
        GameManager.Instance.UpdateGameState(GameState.LevelFinished);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
