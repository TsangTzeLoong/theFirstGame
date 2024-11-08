using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeController : MonoBehaviour{
    private DataRepository dataRepository;
    [SerializeField]
    private Button transferBtn;
    [SerializeField]
    private Button addCoinBtn;
    [SerializeField]
    private Button addFlowerBtn;
    [SerializeField]
    private TMP_Text goBeerTxt;
    private int beerCount;
    bool hvEnoughFlower = false;
    void Transfer(){
        if(hvEnoughFlower){
            dataRepository.CharacterAttributes.BeerFlower -= 3;
            beerCount++;
        }
        UpdateData();
    }
    void AddFlower(){
        dataRepository.CharacterAttributes.BeerFlower ++;
        hvEnoughFlower = dataRepository.CharacterAttributes.BeerFlower >= 3;
        Debug.Log(dataRepository.CharacterAttributes.BeerFlower);
        Debug.Log(hvEnoughFlower);
    }
    void AddCoin(){
        dataRepository.CharacterAttributes.Coin ++;
    }
    void UpdateData(){
        goBeerTxt.text = beerCount.ToString();

    }

    void Start() {
        goBeerTxt.text = beerCount.ToString();
        transferBtn.onClick.AddListener(Transfer);
        addFlowerBtn.onClick.AddListener(AddFlower);
        addCoinBtn.onClick.AddListener(AddCoin);
        dataRepository = DataRepository.Instance;
    }
}
