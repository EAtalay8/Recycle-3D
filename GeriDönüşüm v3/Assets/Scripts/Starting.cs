using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Starting : MonoBehaviour
{

    public GameObject StartPlayingPanel;

    public GameObject PlayUI;

    void Start()
    {
        Invoke("PauseGame", 0.5f);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        StartPlayingPanel.SetActive(false);
        PlayUI.SetActive(true);
        Time.timeScale = 1;
    }


}
