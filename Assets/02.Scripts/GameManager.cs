using System.Collections;
using System.Collections.Generic;
using TMPro; //Text 사용하기 위햐여
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; //싱글톤

    public bool isGameStart;

    public GameObject titlePanel;  //  처음부터 활성
    public GameObject gamePanel;  // 처음엔 비활성
    public GameObject gameOverPanel;

    public Slider progressBar;

    public TextMeshProUGUI nowStageText;  // 현재 스테이지 Text
    public TextMeshProUGUI nextStageText; // 다음 스테이지 Text

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
        Time.timeScale = 0f; //시간을 멈춰서 처음부터 Dino가 달리는걸 막아준다
        progressBar.value = 0f; //처음엔 간 거리를 0으로 세팅
        titlePanel.SetActive(true); //처음엔 Title화면만 보임
        gamePanel.SetActive(false); //Game화면은 비활성화
        gameOverPanel.SetActive(false);  // GameOver화면은 비활성화

        nowStageText.text = MapManager.instance.GetStage().ToString();
        nextStageText.text = (MapManager.instance.GetStage() + 1).ToString();

    }
    void Update()
    {
        SetDistanceProgressBar();
    }
    public void SetDistanceProgressBar() //프로그래스바를 세팅하기 위한 함수
    {
        if (isGameStart.Equals(false))
            return;

        //전체거리 중 Dino의 위치 거리 비율 - 아까 메모장에서 사용했던 0-1사이의 값으로 거리를 세팅하기 위하여
        float goalDistance = DinoController.instance.gameObject.transform.position.z / MapManager.instance.GetGoalDistance();
        progressBar.value = goalDistance;

        //float goalDistance = MapManager.instance.GetGoalDistance();
        //float dinoDistance = DinoController.instance.GetDinoDistance();
        //
        //float value = dinoDistance / goalDistance;
        //progressBar.value = value;
    }
    public void GameStart()
    {
        Time.timeScale = 1f;  //게임 전체 시간을 1로 세팅해서 원래대로 흐르게 함
        isGameStart = true; //게임 시작 변수
        Debug.Log("게임 시작 버튼 누름");
        titlePanel.SetActive(false); //게임 시작하면 Title화면은 비활성화
        gamePanel.SetActive(true); //게임 시작하면 GamePanel 활성화
    }
    public void RestarGame()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        isGameStart = false;
        Time.timeScale = 0f;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}