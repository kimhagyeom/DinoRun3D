using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public static DinoController instance; //싱글톤
    public float moveSpeedZ; //z축 움직이는 속도 변수
    public float moveSpeedX; //x축 움직이는 속도 변수

    //구체의 중심이 될 위치
    public Vector3 sphereCenter;

    //구체의 반지름
    public float sphereRadius = 0.5f;

    public DinoPositionController dinoPositionController;

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
    void Start()
    {
        
    }
    void Update()
    {
        if (GameManager.instance.isGameStart == true)
        {
            DinoMove(); // (alt + enter키 메서드 추출 -> 함수 만들어줌)
            DoorCheck();
        }
    }

    private void DinoMove()
    {
        //trnaform.Translate(0,0,moveSpeedZ);
        transform.position += Vector3.forward * Time.deltaTime * moveSpeedZ;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += Vector3.right * Time.deltaTime ;
            transform.Translate(moveSpeedX * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // transform.position += Vector3.left * Time.deltaTime;
            transform.Translate(-moveSpeedX * Time.deltaTime, 0, 0);
        }
        //공룡 움직이는 범위[1]
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.9f, 3.9f), transform.position.y, transform.position.z);

        //공룡 움직이는 범위 방법[2]
        //if(transform.position.x >-3.9f)
        //{
        //    if (Input.GetKey(KeyCode.RightArrow))
        //    {
        //        transform.Translate(moveSpeedX * Time.deltaTime, 0, 0);
        //    }
        //}
        //if (transform.position.x > -3.9f)
        //{
        //    if (Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        transform.Translate(-moveSpeedX * Time.deltaTime, 0, 0);
        //    }
        //}
    }
    void DoorCheck()
    {
        //구체 영역 내의 Collider들을 감지
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        //감지된 collider들 처리
        foreach(Collider doors in hitColliders)
        {
            if (doors.CompareTag("Goal"))
            {
                //Goal인 지점에 닿았을 때
                Debug.Log("골인!");
                //충돌한 오브젝트의 Boxcollider컴포넌트를 비활성화 해줌
                doors.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                //Debug.Log("감지된 오브젝트" + doors.gameObject.name);
                //여기에서 충돌한 Door의 타입과 문에 써진 숫자를 받아와서
                int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);
                DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);

                //충돌한 오브젝트의 Boxcollider컴포넌트를 비활성화 해줌
                doors.gameObject.GetComponent<BoxCollider>().enabled = false;

                //DionPositioncontroller 스크립트에서 적절하게 사칙연산에 맞게 계산해서 Rapotor들을 늘이거나 줄이면 될거 같음.
                dinoPositionController.SetDoorcalc(doorType, doorNumber);
            }
            
        }
    }

    //구체 영역을 Gizmo로 시각화
     void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
    public float GetDinoDistance()
    {
        return dinoPositionController.transform.position.z;
    }
}
