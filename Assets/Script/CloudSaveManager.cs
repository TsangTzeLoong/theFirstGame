using Unity.Services.Authentication;
using Unity.Services.Core;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.CloudSave;

public class CloudSaveManager: MonoBehaviour{
    async void Start(){
        try{
            // 初始化 Unity 服务
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services Initialized.");

            // 检查是否已经登录
            if (!AuthenticationService.Instance.IsSignedIn){
                // 使用匿名方式登录
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Signed in anonymously.");
            }
        }
        catch (Exception e){
            Debug.LogError($"Failed to initialize Unity Services or sign in: {e}");
        }
    }

    // 上传数据到云端
    public async void SaveDataToCloud(CharacterAttributes characterAttributes){
        if (!AuthenticationService.Instance.IsSignedIn){
            Debug.LogError("Cannot save data, user is not signed in.");
            return;
        }

        string jsonData = JsonUtility.ToJson(characterAttributes);
        Dictionary<string, object> dataToSave = new Dictionary<string, object>{
            {"playerSaveData", jsonData}
        };

        try{
            await CloudSaveService.Instance.Data.Player.SaveAsync(dataToSave);
            Debug.Log("Data saved to cloud.");
        }
        catch (CloudSaveException e){

            Debug.LogError($"Failed to save data to cloud: {e}");
        }
    }
}
