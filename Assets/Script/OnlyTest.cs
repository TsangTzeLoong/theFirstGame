using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class OnlyTest: MonoBehaviour{

[SerializeField]
private Button testBtn;
private DataSaveLoad dataSaveLoad;
private DataRepository dataRepository;
private Inventory inventory;
private CloudSaveManager cloudSaveManager;
    void Start(){
        dataRepository = DataRepository.Instance;
        dataSaveLoad = gameObject.AddComponent<DataSaveLoad>();

        // 挂载一个云存储的go 初始化
        //cloudSaveManager = gameObject.AddComponent<CloudSaveManager>();

        testBtn.onClick.AddListener(Test);
    }
    private void Test(){
        //dataRepository.CharacterAttributes.LevelUp();
        dataSaveLoad.SaveData(dataRepository.CharacterAttributes);
        dataSaveLoad.SaveInventory(dataRepository.Inventory);
        //cloudSaveManager.SaveDataToCloud(dataRepository.CharacterAttributes);

        //dataSaveLoad.LoadData();
    }
    void OnDestroy(){
        testBtn.onClick.RemoveAllListeners();
    }
}
