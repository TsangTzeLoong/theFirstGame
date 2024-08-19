using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchMonitor : MonoBehaviour{

[SerializeField]
private GameObject self;
private bool isPlayerInRange = false;
private SceneController sceneController;
private bool canLoadNewScene;
//[SerializeField]
internal static int pointCount = 0;
    void Start(){

    }

    void Update(){
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E)){
            pointCount++;
            Destroy(self);
            Debug.Log($"point: {pointCount}");
            //SceneManager.LoadSceneAsync(2);
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            isPlayerInRange = true;
            canLoadNewScene = true;
            Debug.Log($"point: {pointCount}");
        } 
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            isPlayerInRange = false;
            Debug.Log("离开了可触发区域!!");
        }
    }
}
