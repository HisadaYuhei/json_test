using UnityEngine;
using System.Collections.Generic; // Listを使うために必要

public class JsonReader : MonoBehaviour
{
    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("profile");

        // ProfileListクラスとしてJSON全体をデシリアライズ（変換）する
        ProfileList profileList = JsonUtility.FromJson<ProfileList>(jsonFile.text);

        // --- データの使い方 ---

        // 3番目（インデックスは2）の人の名前を表示
        // これでやりたかった表現ができます！
        if (profileList.profiles.Count > 2)
        {
            Debug.Log("3番目の人の名前: " + profileList.profiles[2].name); // "鈴木 一郎"
        }

        Debug.Log("--- 全員のプロフィール ---");
        // forループですべてのプロフィール情報を順番に表示する
        for (int i = 0; i < profileList.profiles.Count; i++)
        {
            Debug.Log($"[{i}] 名前: {profileList.profiles[i].name}, 年齢: {profileList.profiles[i].age}");
        }
    }
}