using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaptors : MonoBehaviour
{
    public GameObject enemyRaptorPrefab;
    public int enemyRaptorNumber;
    public Transform enemyRaptorsParent;  // EnemyRaptor가 생성되는 오브젝트의 부모가 되는 오브젝트를 담기 위한 변수


    public float initialRadius = 0f; // 첫 오브젝트의 반지름
    public float radiusGrowth = 0.12f;  // 오브젝트 간 반지름 증가량
    public float angleIncrement = 137.5f;  // 각도 증가 비율 (보통 골든 앵글 사용)

    void Start()
    {
        CreateEnemyRaptors();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void CreateEnemyRaptors()
    {
        // 내가 정한 수 만큼 EnemyRaptor생성
        for (int i = 0; i < enemyRaptorNumber; i++)
        {
            // 반지름이 점점 커짐 피보나치 수열 효과
            float currentRadius = initialRadius + (radiusGrowth * i);

            // 각도가 점점 증가 (오브젝트가 계속 나선형으로 퍼져나감)
            float angle = i * angleIncrement;

            // 각도를 라디안 단위로 변환 후 좌표 계산
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * currentRadius;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRadius;

            GameObject enemyRaptor = Instantiate(enemyRaptorPrefab, enemyRaptorsParent);
            enemyRaptor.gameObject.transform.localPosition = new Vector3(x, 0, z);
        }
    }
}
