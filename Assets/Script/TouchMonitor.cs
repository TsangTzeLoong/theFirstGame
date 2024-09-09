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
private DataRepository dataRepository;
//[SerializeField]
internal static int pointCount = 0;
private int i;
    void Start(){
        dataRepository = DataRepository.Instance;
        i = dataRepository.CharacterAttributes.BeerFlower;

    }

    void Update(){
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E)){
            dataRepository.CharacterAttributes.BeerFlower++;
            Debug.Log($"beerFlower: {i}");
            i++;
            Debug.Log($"beerFlower2: {i}");
            Destroy(self);
            //SceneManager.LoadSceneAsync(2);
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            isPlayerInRange = true;
            canLoadNewScene = true;
            Debug.Log($"beerFlower: {i}");
        } 
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            isPlayerInRange = false;
            i++;
        }
    }
}
