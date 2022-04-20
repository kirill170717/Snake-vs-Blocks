using UnityEngine;
using Firebase.Auth;
using TMPro;
using System.Collections;
using Firebase;

public class FirebaseAuthentication : MonoBehaviour
{
    public FirebaseAuth auth;
    public FirebaseUser user;
    FirebaseErrors errors = new FirebaseErrors();

    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_Text status;

    public void LoginButton()
    {
        StartCoroutine(Login(email.text, password.text));
    }

    private IEnumerator Login(string email, string password)
    {
        auth = FirebaseAuth.DefaultInstance;
        Credential credential = EmailAuthProvider.GetCredential(email, password);
        status.color = Color.red;
        var loginTask = auth.SignInWithCredentialAsync(credential);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            errors.WhatErrorOut(loginTask.Exception.GetBaseException() as FirebaseException);
            status.text = errors.error;
        }
        else
        {
            user = loginTask.Result;
            status.color = Color.green;
            status.text = LocalizationManager.instance.GetText("success");
            UiManager.instance.CloseAuth();
            Data.instance.player.unknown = false;
        }
    }

    public void SignOut()
    {
        FirebaseDB.instance.SaveData();
        auth = FirebaseAuth.DefaultInstance;
        Debug.Log("Sign out");
        auth.SignOut();
        UiManager.instance.OpenAuth();
    }
}