using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterProfileDisplay : MonoBehaviour{
    [SerializeField]
    private TMP_Text txtCollectionCount;
    [SerializeField]
    private TMP_Text playerNameDisplay;
    private DataRepository dataRepository;
    void Start(){
        dataRepository = DataRepository.Instance;
        ProfileInfoUpdate();
    }
    private void ProfileInfoUpdate() {
        if(DataRepository.Instance == null || DataRepository.Instance.CharacterAttributes == null){
        Debug.LogError("DataRepository or CharacterAttributes is not initialized!");
        return;
    }
        //DataRepository dataRepository = DataRepository.Instance;
        dataRepository.CharacterAttributes.UpdateAttributes();

        int beerFlowerCounts = dataRepository.CharacterAttributes.BeerFlower;
        txtCollectionCount.text = $"Already hv {beerFlowerCounts.ToString()}";
        int Health = dataRepository.CharacterAttributes.Health;
        playerNameDisplay.text = Health.ToString();
    }
    void Update(){
       ProfileInfoUpdate();
    }
}