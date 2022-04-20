using UnityEngine;
using Firebase.Database;
using System.Collections.Generic;
using TMPro;
using Firebase.Extensions;

public class FirebaseDB : MonoBehaviour
{
    public static FirebaseDB instance;

    DatabaseReference reference;

    [HideInInspector] public string userId;

    public TMP_Text username;
    public TMP_Text lifes;

    public int Life
    {
        get { return Data.instance.player.life; }
        set { Data.instance.player.life = value; }
    }
    public int RecordLevel
    {
        get { return Data.instance.player.recordLevel; }
        set { Data.instance.player.recordLevel = value; }
    }
    public int CompletedLevel
    {
        get { return Data.instance.player.completedLevel; }
        set { Data.instance.player.completedLevel = value; }
    }
    public int RecordInfinite
    {
        get { return Data.instance.player.recordInfinite; }
        set { Data.instance.player.recordInfinite = value; }
    }
    public int Coin
    {
        get { return Data.instance.player.coin; }
        set { Data.instance.player.coin = value; }
    }
    public List<bool> PurchaseSkin
    {
        get { return Data.instance.player.purchaseSkins; }
        set { Data.instance.player.purchaseSkins = value; }
    }
    public List<Challenges> Challenges
    {
        get { return Data.instance.player.challenges; }
        set { Data.instance.player.challenges = value; }
    }

    private void Awake()
    {
        instance = this;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SaveData()
    {
        if (FirebaseConnect.instance.user != null)
        {
            userId = FirebaseConnect.instance.user.UserId;
            FirebaseUserData userData = new FirebaseUserData(FirebaseConnect.instance.user.DisplayName,
                        FirebaseConnect.instance.user.Email, Life, RecordLevel, CompletedLevel, RecordInfinite, Coin, PurchaseSkin, Challenges);
            string json = JsonUtility.ToJson(userData);

            reference.Child("Users").Child(userId).SetRawJsonValueAsync(json);
        }
    }

    public void LoadData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users").ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        userId = FirebaseConnect.instance.user.UserId;

        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        else
        {
            Life = int.Parse(args.Snapshot.Child(userId).Child("life").Value.ToString());
            RecordLevel = int.Parse(args.Snapshot.Child(userId).Child("recordLevel").Value.ToString());
            CompletedLevel = int.Parse(args.Snapshot.Child(userId).Child("completedLevel").Value.ToString());
            RecordInfinite = int.Parse(args.Snapshot.Child(userId).Child("recordInfinite").Value.ToString());
            Coin = int.Parse(args.Snapshot.Child(userId).Child("coin").Value.ToString());

            for (int i = 0; i < args.Snapshot.Child(userId).Child("purchaseSkin").ChildrenCount; i++)
                PurchaseSkin[i] = (bool)args.Snapshot.Child(userId).Child("purchaseSkin").Child(i.ToString()).Value;

            for (int i = 0; i < args.Snapshot.Child(userId).Child("challenges").ChildrenCount; i++)
                Challenges[i].complete = (bool)args.Snapshot.Child(userId).Child("challenges").Child(i.ToString()).Child("complete").Value;
        }
    }

    public void ProfileStat()
    {
        userId = FirebaseConnect.instance.user.UserId;
        FirebaseDatabase.DefaultInstance.GetReference("Users").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                username.text = snapshot.Child(userId).Child("username").Value.ToString();
                lifes.text = snapshot.Child(userId).Child("life").Value.ToString();
            }
        });
    }

    private bool quit;

    private void OnApplicationFocus(bool focus)
    {
        quit = focus;
        if (!focus)
            SaveData();
    }

    private void OnApplicationQuit()
    {
        if (quit)
            SaveData();
    }
}