using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public StageScriptableObject[] stages; //스크립터블 오브젝트로 만든 Data를 담기 위한 변순

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
        CreatStage();
        // CreateMap();
        goalObject = GameObject.FindWithTag("Goal"); //Goal 오브젝트를 찾아서 대입해준다.
    }

    //private void CreateMap()
    //{
    //    //초기 생성위치는 항상 0,0,0 이다.
    //    Vector3 mapPosition = Vector3.zero;
    //
    //    for (int i = 0; i < 5; i++) //일단 5번만 
    //    {
    //        GameObject selectedMap; //만들 map을 선택한다
    //        if (i == 0)
    //        {
    //            selectedMap = mapPrefabs[0]; //처음에는 무조건  0번째 배열의 Map이 만들어진다.
    //        }
    //        else if (i == 4)
    //        {
    //            selectedMap = goalObject; //마지막은  goal 맵이 나오게 
    //        }
    //        else
    //        {
    //            selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)];
    //            //2번째 Map에서부터 이전 Map의 크기의 반을 더해준다
    //            mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
    //        }
    //        GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity); // 현재 만들 맵 생성
    //        mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //현재 생성된 Map의 길이의 반을 더한다.
    //    }
    //}
    private void CreatStage()
    {
        int currentStageIndex = GetStage();
        currentStageIndex = currentStageIndex % stages.Length; //이렇게 하면 stage의 범위를 벗어나는 경우가 없을 것이다.
        StageScriptableObject stage = stages[currentStageIndex];

        CreateMap(stage.maps);
    }
    private void CreateMap(Map[] stageMaps)
    {
        //초기 생성위치는 항상 0,0,0 이다.
        Vector3 mapPosition = Vector3.zero;

        for (int i = 0; i < stageMaps.Length; i++) //일단 5번만 
        {
            Map selectedMap = stageMaps[i];
            if(i>0)
            {
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            Map nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity, transform); // 현재 만들 맵 생성
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2; //현재 생성된 Map의 길이의 반을 더한다.
        }
    }
    public int GetStage()
    {
        return PlayerPrefs.GetInt("Stage", 0); //playerprefs 사용법 1.데이터 저장(세가지 데이터 유형(정수, 부동소수점,문자열)을 저장 할 수 있다)
    }
    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }
}
