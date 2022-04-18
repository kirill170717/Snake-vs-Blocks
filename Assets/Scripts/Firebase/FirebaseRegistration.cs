using UnityEngine;
using Firebase.Auth;
using TMPro;
using System.Collections;
using Firebase;

public class FirebaseRegistration : MonoBehaviour
{
    public FirebaseAuth auth;
    public FirebaseUser user;

    public TMP_InputField username;
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField confirmPassword;
    public TMP_Text status;

    public void RegisterButton()
    {
        StartCoroutine(Register(username.text, email.text, password.text, confirmPassword.text));
    }

    private IEnumerator Register(string username, string email, string password, string confirmPassword)
    {
        auth = FirebaseAuth.DefaultInstance;
        status.color = Color.red;

        if (string.IsNullOrWhiteSpace(username))
            status.text = LocalizationManager.instance.GetText("missingUsername");
        else if (password != confirmPassword)
            status.text = LocalizationManager.instance.GetText("passDoesNotMatch");
        else
        {
            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
            yield return new WaitUntil(predicate: () => registerTask.IsCompleted);

            if (registerTask.Exception != null)
            {
                FirebaseErrors.instance.WhatErrorOut(registerTask.Exception.GetBaseException() as FirebaseException);
                status.text = FirebaseErrors.instance.error;
            }
            else
            {
                user = registerTask.Result;

                if (user != null)
                {
                    UserProfile profile = new UserProfile { DisplayName = username };
                    var ProfileTask = user.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                        status.text = LocalizationManager.instance.GetText("usernameSetFailed");
                    else
                    {
                        status.color = Color.green;
                        status.text = LocalizationManager.instance.GetText("success");
                        FirebaseDB.instance.SaveData();
                    }
                }
            }
        }
    }
}