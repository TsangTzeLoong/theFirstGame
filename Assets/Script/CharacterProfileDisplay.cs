using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterProfileDisplay : MonoBehaviour{
    private int characterLevel;
    [SerializeField]
    private TMP_Text characterLevelTxt;
    private int coin;
    [SerializeField]
    private TMP_Text coinTxt;
    private int beerFlower;
    [SerializeField]
    private TMP_Text beerFlowerTxt;
    [SerializeField]
    private Button updateBtn; 
    private DataRepository dataRepository;
    private Inventory inventory;
    void Start(){
        dataRepository = DataRepository.Instance;
        inventory = new Inventory();
        updateBtn.onClick.AddListener(Plus);
        Init();
        //ProfileInfoUpdate();
    }
    void Plus(){
        inventory.AddItem(ItemType.Potion, 1);
        inventory.PrintInventory();
    }
    void Init(){
        characterLevel = dataRepository.CharacterAttributes.level;
        coin = dataRepository.CharacterAttributes.Coin;
        beerFlower = dataRepository.CharacterAttributes.BeerFlower;

        characterLevelTxt.text = $"Character Level: {characterLevel}";
        coinTxt.text = $"Coin: {coin}";
        beerFlowerTxt.text = $"Beer Flower: {beerFlower}";
    }
    private void ProfileInfoUpdate() {
        if(DataRepository.Instance == null || DataRepository.Instance.CharacterAttributes == null){
        Debug.LogError("DataRepository or CharacterAttributes is not initialized!");
        return;
    }
        dataRepository.CharacterAttributes.UpdateAttributes();
    }
    void Update(){
       //ProfileInfoUpdate();
    }
    private void OnDestroy() {
        updateBtn.onClick.RemoveAllListeners();
    }
}