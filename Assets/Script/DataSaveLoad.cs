using System.Collections;
using System.Collections.Generic;
using Unity.Services.CloudSave;
using UnityEngine;
using System.IO;

public class DataSaveLoad: MonoBehaviour{
private AssetBundle loadedAssetBundle;
private DataRepository dataRepository;
private CharacterAttributes characterAttributes;
    void Start(){
        // 不继承monobehaviour的话用这个方法
        characterAttributes = new CharacterAttributes();
        // 继承的话用这个方法
        //characterAttributes = gameObject.AddComponent<CharacterAttributes>();

        string bundlePath = Path.Combine(Application.streamingAssetsPath, "ui_profiledisplay");
        loadedAssetBundle = AssetBundle.LoadFromFile(bundlePath);
        Debug.Log(bundlePath);
        if (loadedAssetBundle == null){
            Debug.LogError("Failed to load AssetBundle!");
            return;
        }

        // 假设你要加载一个Prefab
        LoadAssetFromBundle("ui_profiledisplay");
    }
    public void LoadAssetFromBundle(string assetName){
        // 从Asset Bundle中加载指定资源
        GameObject prefab = loadedAssetBundle.LoadAsset<GameObject>("ui_profiledisplay");
        if (prefab != null){
            // 实例化资源，将其挂载到当前场景中
            Instantiate(prefab);
        }
        else{
            Debug.LogError($"Failed to load {assetName} from AssetBundle!");
        }
    }
    public void SaveData(CharacterAttributes characterAttributes){
        string path = Application.persistentDataPath + "/characterAttributes.json";
        string json = JsonUtility.ToJson(characterAttributes);
        File.WriteAllText(path, json);
        Debug.Log($"Data saved to {path}");
    }
    public void LoadData(){
        string path = Application.persistentDataPath + "/characterAttributes.json";
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            Debug.Log(json);
            characterAttributes = JsonUtility.FromJson<CharacterAttributes>(json); 
            dataRepository = DataRepository.Instance;
            dataRepository.CharacterAttributes = characterAttributes;
            Debug.Log("Data loaded from " + path);
        }
        else{
            Debug.Log("No data file found.");
        }
        //LoadAssetFromBundle("CharacterProfile");
    }
    private void OnDestroy(){
        if (loadedAssetBundle != null){
            loadedAssetBundle.Unload(false);
        }
    }
}
