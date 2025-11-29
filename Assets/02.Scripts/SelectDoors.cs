using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro를 사용하기 위해서 선언

//밖으로 빼면 다른 스크립트에서도 쓸 수 있는 변수가 된다
public enum DoorType
{
    Plus,
    Minus,
    Times,
    Division
}
public class SelectDoors : MonoBehaviour
{
    public SpriteRenderer rightDoorSpriteRD; //오른쪽 문의 색을 관리할 변수
    public SpriteRenderer leftDoorSpriteRD; //왼쪽 문의 색을 관리할 변수
    public TextMeshPro rightDoorText; //오른쪽 문의 Text를 관리할 변수
    public TextMeshPro leftDoorText; //왼쪽 문의 Text를 관리할 변수

    [SerializeField]
    private DoorType rightDoorType; //오른쪽 문의 상태를 관리할 변수
    public int rightDoorNumber; //오른쪽 문에서 계산될 숫자 변수
    [SerializeField]
    private DoorType leftDoorType; //왼쪽 문의 상태를 관리할 변수
    public int leftDoorNumber; //왼쪽 문에서 계산될 숫자 변수

    public Color goodColor; //좋은쪽 문의 색상
    public Color badColor; //나쁜쪽 문의 색상
    void Start()
    {
        SettingDoors();
    }
    void Update()
    {
        
    }
    public void SettingDoors()
    {
        //오른쪽 문 세팅.
        if(rightDoorType.Equals(DoorType.Plus))
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "+" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Minus))
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "-" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Times))
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "x" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Division))
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "÷" + rightDoorNumber;
        }

        //왼쪽 문 세팅.
        if (leftDoorType.Equals(DoorType.Plus))
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "+" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Minus))
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "-" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Times))
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "x" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Division))
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "÷" + leftDoorNumber;
        }
    }
    public DoorType GetDoorType(float xPos)
    {
        if(xPos > 0) //Dino의 위치값이 0보다 크면
        {
            return rightDoorType; //오른쪽 문 타입 반환
        }
        else
        {
            return leftDoorType; //왼쪽 문 타입 반환
        }
    }
    public int GetDoorNumber(float xPos)
    {
        if (xPos > 0) // Dino의 위치값이 보다 크면
        {
            return rightDoorNumber; //오른쪽 문 값 반환
        }
        else
        {
            return leftDoorNumber; //왼쪽 문 값 반환
        }
    }
}
