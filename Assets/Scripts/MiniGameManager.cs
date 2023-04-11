using System;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager instance;
    [SerializeField]private GameObject MiniGamePrefab;
    
    private bool isPaused = false;
    
    public Action onGameCreate;
    public Action onGameStart;
    public Action onGameEnd;
    public Action onGameDestroy;
    public Action onGamePause;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
        CreateGame();
    }

    public void CreateGame()
    {
        Instantiate(MiniGamePrefab,transform);
        onGameCreate?.Invoke();
        Debug.Log("GameCreated");
        Physics.gravity = new Vector3(0, -18, 0);

        StartGame();
    }

    public void StartGame()
    {
        onGameStart.Invoke();
        Time.timeScale = 1;
        Debug.Log("GameStarted");
    }

    public void EndGame()
    {        
        onGameEnd?.Invoke();
        Time.timeScale = 0;
        Debug.Log("GameEnded");
    }
    public void DestroyGame()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        onGameDestroy?.Invoke();
        foreach (Transform childTransform in transform) Destroy(childTransform.gameObject);
        Debug.Log("GameDestroyed");
    }

    public void PauseGame()
    {
        onGamePause?.Invoke();
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}
