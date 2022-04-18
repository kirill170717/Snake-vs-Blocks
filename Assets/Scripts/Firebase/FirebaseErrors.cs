using UnityEngine;
using Firebase.Auth;
using Firebase;

public class FirebaseErrors : MonoBehaviour
{
    public static FirebaseErrors instance;

    [HideInInspector] public string error;

    private void Awake()
    {
        instance = this;
    }

    public void WhatErrorOut(FirebaseException firebaseException)
    {
        AuthError errorCode = (AuthError)firebaseException.ErrorCode;
        string message = LocalizationManager.instance.GetText("loginFailed");
        switch (errorCode)
        {
            case AuthError.EmailAlreadyInUse:
                message = LocalizationManager.instance.GetText("emailAlreadyInUse");
                break;
            case AuthError.InvalidEmail:
                message = LocalizationManager.instance.GetText("invalidEmail");
                break;
            case AuthError.WrongPassword:
                message = LocalizationManager.instance.GetText("wrongPass");
                break;
            case AuthError.UserNotFound:
                message = LocalizationManager.instance.GetText("userNotExist");
                break;
            case AuthError.WeakPassword:
                message = LocalizationManager.instance.GetText("weakPass");
                break;
            case AuthError.MissingEmail:
                message = LocalizationManager.instance.GetText("missingEmail");
                break;
            case AuthError.MissingPassword:
                message = LocalizationManager.instance.GetText("missingPass");
                break;
        }
        error = message;
    }
}