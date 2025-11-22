using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DinoCounter : MonoBehaviour
{
    public TextMeshPro dinoCountText;
    public Transform raptor; //Raptor들을 관리할 부모 오브젝트

    void Start()
    {
        
    }
    void Update()
    {
        dinoCountText.text = raptor.childCount.ToString();
    }
}
