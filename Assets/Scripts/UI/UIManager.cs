using System;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    private Dictionary<PanelType,GameObject> _panels;
    [SerializeField] private GameObject[] Panels;
    enum PanelType
    {
        Pause,
        Exit
    }

    private void OnEnable()
    {
        MiniGameManager.instance.onGamePause += Pause;
        MiniGameManager.instance.onGameEnd += Death;
    }

    private void OnDisable()
    {
        MiniGameManager.instance.onGamePause -= Pause;
        MiniGameManager.instance.onGameEnd -= Death;
    }

    public void Pause()
    {
        Panels[0].SetActive(!Panels[0].activeSelf); 
    }
    public void Death()
    {
        Panels[1].SetActive(true);
    }
    public void Restart()
    { 
        MiniGameManager.instance.DestroyGame();
        MiniGameManager.instance.CreateGame();
        ClosePanels();
    }

    public void Exit()
    {
        MiniGameManager.instance.DestroyGame();
    }

    public void ClosePanels()
    {
        foreach (var t in Panels)
        {
            t.SetActive(false);
        }
    }
}
