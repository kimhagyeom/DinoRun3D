using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;
    public GameObject goalObject; //거리를 구하기 위한 오브젝트를 담기 위한 변수.

    public static MapManager instance; //싱글톤

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
        CreateMap();
        goalObject = GameObject.FindWithTag("Goal"); //Goal 오브젝트를 찾아서 대입해준다.
    }
    
    private void CreateMap()
    {
        //초기 생성위치는 항상 0,0,0 이다.
        Vector3 mapPosition = Vector3.zero;

        for (int i = 0; i < 5; i++) //일단 5번만 
        {
            GameObject selectedMap; //만들 map을 선택한다
            if (i > 0)
            {
                selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)];
                //2번째 Map에서부터 이전 Map의 크기의 반을 더해준다
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            else
            {
                selectedMap = mapPrefabs[0]; //처음에는 무조건  0번째 배열의 Map이 만들어진다.
            }
            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity); // 현재 만들 맵 생성
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //현재 생성된 Map의 길이의 반을 더한다.
        }
    }
    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }
}
