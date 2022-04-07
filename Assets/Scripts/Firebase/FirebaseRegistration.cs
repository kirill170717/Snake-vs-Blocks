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

        if (string.IsNullOrWhiteSpace(username))
            status.text = LocalizationManager.instance.GetText("missingUsername");
        else if (password != confirmPassword)
            status.text = LocalizationManager.instance.GetText("passDoesNotMatch");
        else
        {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                string message = LocalizationManager.instance.GetText("registerFailed");

                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = LocalizationManager.instance.GetText("missingEmail");
                        break;
                    case AuthError.MissingPassword:
                        message = LocalizationManager.instance.GetText("missingPass");
                        break;
                    case AuthError.WeakPassword:
                        message = LocalizationManager.instance.GetText("weakPass");
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = LocalizationManager.instance.GetText("emailAlreadyInUse");
                        break;
                }
                status.text = message;
            }
            else
            {
                user = RegisterTask.Result;

                if (user != null)
                {
                    UserProfile profile = new UserProfile { DisplayName = username };
                    var ProfileTask = user.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        status.text = LocalizationManager.instance.GetText("usernameSetFailed");
                    }
                    else
                        status.text = LocalizationManager.instance.GetText("success");
                }
            }
        }
    }
}