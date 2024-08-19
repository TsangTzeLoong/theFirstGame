using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInfoDisplay : MonoBehaviour {
    [SerializeField]
    private TMP_Text characterInfoTxt;
    [SerializeField]
    private CharacterAttributes characterAttributes;
    void Start(){
        DisplayCharacterInfo();
    }
    void Update() {
        DisplayCharacterInfo();
    }
    private void DisplayCharacterInfo(){
        characterInfoTxt.text = $"Name: {characterAttributes.characterName}\nHealth: {characterAttributes.Health}\nWallet: {characterAttributes.wallet}\nSobriety:{characterAttributes.sobriety}\nBeerFlowerCount: {characterAttributes.beerFlowerCounts}";

    }
}
