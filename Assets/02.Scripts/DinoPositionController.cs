using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DinoPositionController : MonoBehaviour
{
    public Transform raptors; //Raptor들을 관리할 부모 오브젝트
                              // public float dinoGapX;
    public GameObject raptorPrefab; // 추가할 Raptor 프리팹

    public float radius = 1f; //원의 반지름
    public float ratio = 0.1f; //배치 간격 비율(작을수록 촘촘)

    void Start()
    {
    }
    void Update()
    {
        SetDinoPosition();
    }
    public void SetDoorcalc(DoorType doorType, int doorNumber)
    {
        if(doorType.Equals(DoorType.Plus)) //더하기 
        {
            PlusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Minus)) //빼기
        {
            Minusraptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Times)) //곱하기
        {
            int raptorNum = (raptors.childCount * (doorNumber - 1)); //(+)를 이용해서 * 계산하기
            PlusRaptor(raptorNum);
        }
        else if (doorType.Equals(DoorType.Division)) //나누기
        {
            //계산 후
            int raptorNum = raptors.childCount - (raptors.childCount / doorNumber); //(-) 를 이용해서 / 계산하기
            //빼야할 값을 이용해서 빼기 함수 이용
            Minusraptor(raptorNum);
        }
    }
    private void PlusRaptor(int number)
    {
        for(int i = 0; i<number; i++)
        {
            Instantiate(raptorPrefab, raptors); //매개변수로 받은 number 수만큼 raptorPrefab을 생성자가 줍니다
        }
    }
    private void Minusraptor(int number)
    {
        //빼는 숫자가 현재 나의 Raptor숫자보다 더 크면
        if(number > raptors.childCount)
        {
            //빼는 숫자를 현재 나의 Raptor 수로 세팅해준다.(어차피 0이 될 것이므로, 나중에 0이 되면 게임오버  시킬 것임)
            number = raptors.childCount;
        }
        int raptorNum = raptors.childCount; //현재 나의  Raptor 숫자를 구하고

        //맨 마지막 Raptor 오브젝트부터 시작해서 전체 Raptor에서 문에 써져있는 숫자만큼 밴 값보다 같거나 클때까지 점점 i를 줄이면서
        for(int i = raptorNum -1; i>=(raptorNum - number); i--)
        {
            Destroy(raptors.GetChild(i).gameObject);//맨 마지막 오브젝트부터 삭제 시킵니다.
        }
    }
    private void SetDinoPosition()
    {
        for (int i = 0; i < raptors.childCount; i++)
        {
            if (i > 8) //Raptor 오브젝트가 10개째부터는 화면에 보이지지 않게 함(i 는 0부터 시작되므로 9가 10번째이다)
            {
                //보이지 않게 만들어주는 코드
                raptors.GetChild(i).gameObject.SetActive(false); //10번째 오브젝트부터는 화면에 보이지 않게 함
                continue; //이 아래의 계산은 하지 않는다 즉 continue 아래에 있는 코드들은 실행되지 않고, 바로 다음 루프로 넘어감
            }
            else //Raptor의 개수가 9개 이하일 때는 각도 계산해서 배치해줌
            {
                //보이게 하면서 배치를 계산하는 코드
                if(raptors.childCount < 10 )
                {
                    //360도 각도 계산을 위한 각도 증가값
                    float angleStep = 360f / (raptors.childCount * ratio);
                    //Q. 왜 9마리일대는 잘되고, 1마리 더 늘려서 10마리가 되면 왜 뭉쳐서 달릴까?
                    //A. 10 * 0.1 은 1이 되므로

                    //각 오브젝트의 배치 각도 계산
                    float angle = i * angleStep;

                    //각도를 라디안으로 변환
                    float angleRad = angle * Mathf.Deg2Rad;

                    //x와 z 좌표를 원형으로 계산
                    float x = Mathf.Cos(angleRad) * radius;
                    float z = Mathf.Sin(angleRad) * radius;

                    //새로운 위치로 자식 오브젝트를 위치시킴
                    raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
                    raptors.GetChild(i).gameObject.SetActive(true);
                }
            }
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
       
