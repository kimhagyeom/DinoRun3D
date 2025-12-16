using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //싱글톤

    public bool isGameStart;

    public GameObject titlePanel;

    public Slider progressBar;

    private void Awake() //싱글톤
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void SetDistanceProgressBar() //프로그래스바를 세팅하기 위한 함수
    {
        float goalDistance = MapManager.instance.GetGoalDistance();
        float dinoDistance = DinoController.instance.GetDinoDistance();

        float value = dinoDistance / goalDistance;
        progressBar.value = value;
    }
    public void GameStart()
    {
        Time.timeScale = 1f;
        isGameStart = true;
        Debug.Log("게임 시작 버튼 누름");
        titlePanel.SetActive(false);
    }

    void Update()
    {
        if (isGameStart)
        {
            SetDistanceProgressBar();
        }
    }
}