using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class LocalizationManager:MonoBehaviour{
    /// <summary>
    /// json读出来的k-v dictionary 
    /// </summary>
    private Dictionary<string, string> localizedText;
    private string currentLanguage = "en";
    void Start(){
        LoadLocalizedText("en_localization.json");
    }
    public void LoadLocalizedText(string fileName){
        // todo 切系统注意改一下斜杠
        string filePath = Path.Combine(Application.persistentDataPath + "/Localization", fileName);
        if (File.Exists(filePath)){
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData localizationData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            localizedText = new Dictionary<string, string>();

            foreach (LocalizedItem item in localizationData.items){
                localizedText.Add(item.key, item.value);
            }
            Debug.Log("Localized text loaded successfully.");
        }
        else{
            Debug.LogError($"Cannot find file at {filePath}!");
    }
    }
    public string GetLocalizedValue(string key){
        if (localizedText.ContainsKey(key)){
            return localizedText[key];}
        else{
            Debug.LogError($"found {key}'s value fail");
        }
        return null;
    }
    [System.Serializable]
    public class LocalizationData{
        public List<LocalizedItem> items;
    }

    [System.Serializable]
    public class LocalizedItem{
        public string key;
        public string value;
    }
}