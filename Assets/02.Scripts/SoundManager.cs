using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource doorHit; //door에 닿았을 때 나는 사운드
    public AudioSource dinoDie;// Raptor가 Destroy됐을 때
    public AudioSource gameClear; //Stage를 클리어 했을 때
    public AudioSource gameOver; //GameOver가 됐을 때

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {

    }
    public void DoorHitSoundPlay() //door에 닿았을 때 실행해줄 함수
    {
        doorHit.Play();
    }
    public void DinoDieSoundPlay() //door에 닿았을 때 실행해줄 함수
    {
        dinoDie.Play();
    }
    public void GameClearSoundPlay() //door에 닿았을 때 실행해줄 함수
    {
        gameClear.Play();
    }
    public void GameOverSoundPlay() //door에 닿았을 때 실행해줄 함수
    {
        gameOver.Play();
    }
}
