using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors; //Raptor들을 관리할 부모 오브젝트
   // public float dinoGapX;
    public float radius = 1f; //원의 반지름
    public float ratio = 0.1f; //배치 간격 비율(작을수록 촘촘)

    void Update()
    {
        SetDinoPosition();
    }
    private void SetDinoPosition()
    {
        //360도 각도 계산을 위한 각도 증가값
        float angleStep = 360f / (raptors.childCount * ratio);
        //Q. 왜 9마리일대는 잘되고, 1마리 더 늘려서 10마리가 되면 왜 뭉쳐서 달릴까?
        //A. 10 * 0.1 은 1이 되므로

        for(int i =0; i< raptors.childCount; i++)
        {
            //각 오브젝트의 배치 각도 계산
            float angle = i * angleStep;

            //각도를 라디안으로 변환
            float angleRad = angle * Mathf.Deg2Rad;

            //x와 z 좌표를 원형으로 계산
            float x = Mathf.Cos(angleRad) * radius;
            float z = Mathf.Sin(angleRad) * radius;

            //새로운 위치로 자식 오브젝트를 위치시킴
            raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
        }
    }

    //** chlid dino들을 일렬로 고르게 배치하는 방법 ** (내 방식으로 바꿔보기)
    //  void Start()
    //  {
    //
    //  }
    //  void Update()
    //  {
    //      float startPosX = (transform.childCount * -(dinoGapX / 2) + (dinoGapX / 2)); //x축의 시작 포지션
    //
    //      //이 스크립트가 있는 오브젝트의 자식 오브젝트의 개수만큼 반복
    //      for (int i = 0; i < transform.childCount; i++)
    //      {
    //          //GetChild함수를 이용해 인덱스 번호 (유니티에서 자식 오브젝트의 맨 왼쪽에서부터 순서)순서대로 계산한 z값
    //          transform.GetChild(i).localPosition = new Vector3(startPosX + (dinoGapX * i), 0, 0);
    //      }
    //  }
}
       
