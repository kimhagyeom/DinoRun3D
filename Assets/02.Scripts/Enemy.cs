using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State
    {
        Idle, //대기 상태
        Run  //Raptor에게 달려오는 상태
    }
    public float moveSpeed; //Dino에게 달려가는 스피드
    public float detectRadius; //감지하는 범위의 반지름
    private State state; //Enemey의 상태를 나타낼 변수
    private Transform targetRaptor; // Enemy의 타겟이 될 Dino

    [SerializeField] private bool isTargeOn;//Enemy인 나 자신이 타겟을 설정 했는지 안했는지 판단하는 변수
    void Start()
    {
        GetComponent<Animator>().speed = 0f; //대기상태에서는 애니메이션 시간을 0으로 해서 멈춰있게 함   
    }
    void Update()
    {
        SetState();
    }
    private void SetState()
    {
        switch (state)
        {
            case State.Idle:
                DetectDino();
                break;
            case State.Run:
                GoToDino();
                break;
        }
    }
    private void DetectDino() // Dino를 찾고 있는 함수, 항상 Update에서 작동 되고 있음.
    {
        if (isTargeOn.Equals(true))
        {
            return;
        }
        // 구체 영역 내의 Collider들을 감지
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRadius);

        // 감지된 Collider들 처리
        foreach (Collider colls in hitColliders)
        {
            Raptor raptor = colls.GetComponent<Raptor>();

            if (raptor != null && raptor.IsTarget().Equals(false)) //Raptor가 타겟이 아닌 경우만 검사
            {
                Invoke("SetTargetDino", 0.1f);
                targetRaptor = raptor.transform;
                break; //첫번째 타겟만 설정하고 루프를 중단.
            }
        }
    }
    private void SetTargetDino()
    {
        //Raptor가 타겟이 지정되있지 않은 경우만 검사
        if (targetRaptor != null && targetRaptor.GetComponent<Raptor>().IsTarget().Equals(false))
        {
            targetRaptor.GetComponent<Raptor>().SetTarget();
            isTargeOn = true; //나는 찜했어

            StartGotoDino(); //상태 변경
        }
    }

    // // 감지된 Collider들 처리
    // foreach (Collider colls in hitColliders)
    // {
    //     // 검색된 곳에  Dino가 있다면
    //     if (colls.gameObject.GetComponent<Raptor>() != null)
    //     {
    //         if (colls.gameObject.GetComponent<Raptor>().IsTarget()) // 이미 타겟으로 지정되어 있다면, 다음 충돌 오브젝트로
    //             continue;
    //
    //         colls.gameObject.GetComponent<Raptor>().SetTarget();  // 충돌 오브젝트에 타겟으로 지정됐다고 스위치 켜주고
    //
    //         targetRaptor = colls.gameObject.transform;   // 충돌 오브젝트를 targetRaptor로 지정해줌
    //
    //         StartGotoDino();  // 상태 바꿔주는 함수 실행
    //     }
    // }
    private void StartGotoDino() //찾았을때 작동하는 함수
    {
        state = State.Run; //상태를 Run으로 바꿔주고
        GetComponent<Animator>().speed = 1f; //애니메이션 시간을 원래 1로 돌려서 움직이게 바꿈
    }
    private void GoToDino() //찾고난 후 Dino에게 달려가는 함수
    {
        if (targetRaptor == null) //타겟이 없으면 작동하지 않음
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetRaptor.position, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, targetRaptor.position) < 0.1f) //targetRaptor와 거리가 0.1보다 작아졌다면
        {
            SoundManager.instance.DinoDieSoundPlay(); //Raptor가 삭제될때 죽는 사운드
            Destroy(targetRaptor.gameObject); //targetRaptor 삭제
            Destroy(this.gameObject); //Enemy인 나 자신도 삭제
        }
    }
}
