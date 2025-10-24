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
        
        Debug.Log("--- 全員の履修コース ---");
        // 1. まず、プロフィールのリストから一人ずつ取り出す (外側のループ)
        foreach (Profile personProfile in profileList.profiles)
        {
            // 誰のコースリストか分かりやすいように名前を表示
            Debug.Log($"--- {personProfile.name}さんの履修コース ---");

            // もしコースが一つも登録されていない場合はスキップ
            if (personProfile.courses.Count == 0)
            {
                Debug.Log("履修コースはありません。");
                continue; // 次の人の処理へ
            }

            // 2. 次に、その人のコースリストからコースを一つずつ取り出す (内側のループ)
            foreach (Course course in personProfile.courses)
            {
                Debug.Log($"コース名: {course.title}, 単位数: {course.credits}");
            }
        }
    }
}