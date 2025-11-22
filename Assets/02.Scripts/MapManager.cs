using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;
    void Start()
    {
        //초기 생성위치는 항상 0,0,0 이다.
        Vector3 mapPosition = Vector3.zero;

        for (int i = 0; i < 5; i++) //일단 5번만 
        {
            //만들 맵을 랜덤으로 선택한다
            GameObject selectedMap = mapPrefabs[Random.Range(0, mapPrefabs.Length)];//0,1,2 인덱스 중에 뽑힘
            if (i > 0)
            {
                //2번째 Map에서부터 이전 Map의 크기의 반을 더해준다
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity); // 현재 만들 맵 생성  Quaternion : ? 다음주.
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //현재 생성된 Map의 길이의 반을 더한다.
        }
    }
}
