using UnityEngine;
using System.Collections.Generic; // Listを使う場合は必要

// [System.Serializable] を必ずつける
[System.Serializable]
public class Course
{
    public string title;
    public int credits;
}

[System.Serializable]
public class Profile
{
    public string name;
    public int age;
    public string email;
    public bool isStudent;
    public List<Course> courses; // Courseクラスのリスト（配列でも可）
}

// ★★★ 追加部分 ★★★
// Profileのリストを格納するための「受け皿」となるクラス
[System.Serializable]
public class ProfileList
{
    // JSONのキー "profiles" と変数名を一致させる
    public List<Profile> profiles;
}