using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieuKhienGamePlay : MonoBehaviour
{
    public static DieuKhienGamePlay ins;
    public Button BatDau;
    public Text diemSo, endScore, bestScore;
    public GameObject gameOverPanel, pausePanel;

    private void Awake()
    {
        Time.timeScale = 0;
        MakeIns();
    }

    void MakeIns()
    {
        if(ins == null)
        {
            ins = this;
        }
    }    
    public void ButtonBatDau()
    {
        BatDau.gameObject.SetActive(false);
        Time.timeScale = 1;               
    }

    public void SetDiemSo(int diem)
    {
        diemSo.text = "" + diem;
    }    

    public void SetPanelGo(int diem)
    {
        gameOverPanel.SetActive(true);
        endScore.text = "" + diem;
        if(diem > QuanLyGame.ins.GetHighScore())
        {
            QuanLyGame.ins.SetHighScore(diem);
        }
        bestScore.text = "" + QuanLyGame.ins.GetHighScore();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }    

    public void ResetButton()
    {
        SceneManager.LoadScene("SampleScene");
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
