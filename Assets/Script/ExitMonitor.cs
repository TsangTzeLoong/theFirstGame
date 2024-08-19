using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMonitor : MonoBehaviour{
[SerializeField]
private bool isPlayerInRange = false;
private bool canLoadNewScene = false;
private int point;
private void Start() {
    point = TouchMonitor.pointCount;
}
    void Update(){
        point = TouchMonitor.pointCount;
        if(canLoadNewScene && Input.GetKeyDown(KeyCode.E)){
            SceneManager.LoadSceneAsync(2);
        }
    }
    private void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Player")){
            isPlayerInRange = true;
        } 
        if(point >= 2){
            canLoadNewScene = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            isPlayerInRange = false;
            canLoadNewScene = false;
            Debug.Log("离开了可触发区域!!");
        }
    }
}
