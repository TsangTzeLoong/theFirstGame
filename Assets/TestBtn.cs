using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestBtn : MonoBehaviour{

[SerializeField]
private Button testBtn;
private int num = TouchMonitor.pointCount;
    void Start(){
       testBtn.onClick.AddListener(Test); 
    }
    private void Test(){
        Debug.Log($"num: {num}");
    }
    private void OnDestroy(){
        testBtn.onClick.RemoveAllListeners();
    }
}
