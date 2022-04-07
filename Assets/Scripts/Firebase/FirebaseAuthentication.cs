using UnityEngine;
using Firebase.Auth;
using TMPro;
using System.Collections;
using Firebase;
using UnityEngine.UI;

public class FirebaseAuthentication : MonoBehaviour
{
    public FirebaseAuth auth;
    public FirebaseUser user;

    public TMP_InputField email;
    public TMP_InputField password;
    public Toggle remember;
    public TMP_Text status;

    public void LoginButton()
    {
        StartCoroutine(Login(email.text, password.text));
    }
    
    private IEnumerator Login(string email, string password)
    {
        auth = FirebaseAuth.DefaultInstance;
        Credential credential = EmailAuthProvider.GetCredential(email, password);
        
        var loginTask = auth.SignInWithCredentialAsync(credential);
        yield return new WaitUntil(predicate: () => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            FirebaseException firebaseEx = loginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
            string message = LocalizationManager.instance.GetText("loginFailed");

            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = LocalizationManager.instance.GetText("missingEmail");
                    break;
                case AuthError.MissingPassword:
                    message = LocalizationManager.instance.GetText("missingPass");
                    break;
                case AuthError.WrongPassword:
                    message = LocalizationManager.instance.GetText("wrongPass");
                    break;
                case AuthError.InvalidEmail:
                    message = LocalizationManager.instance.GetText("invalidEmail");
                    break;
                case AuthError.UserNotFound:
                    message = LocalizationManager.instance.GetText("userNotExist");
                    break;
            }
            status.text = message;
        }
        else
        {
            user = loginTask.Result;
            status.text = LocalizationManager.instance.GetText("success");
            UiManager.instance.CloseAuth();
        }
    }

    public void SignOut()
    {
        auth = FirebaseAuth.DefaultInstance;
        Debug.Log("Sign out");
        auth.SignOut();
    }
}