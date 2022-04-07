using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Collections;

public class FirebaseConnect : MonoBehaviour
{
    public static FirebaseConnect instance;

    public FirebaseAuth auth;
    public FirebaseUser user;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        StartCoroutine(CheckAndFixDependancies());
    }

    private IEnumerator CheckAndFixDependancies()
    {
        var task = FirebaseApp.CheckAndFixDependenciesAsync();
        yield return new WaitUntil(predicate: () => task.IsCompleted);
        var result = task.Result;

        if (result == DependencyStatus.Available)
        {
            auth = FirebaseAuth.DefaultInstance;
            StartCoroutine(CheckAutoLogin());
            auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
        }
        else
            Debug.LogError("Could not resolve all Firebase dependencies: " + result);
    }

    private IEnumerator CheckAutoLogin()
    {
        yield return new WaitForEndOfFrame();

        if(user != null)
        {
            var reloadUserTask = user.ReloadAsync();
            yield return new WaitUntil(predicate: () => reloadUserTask.IsCompleted);
            AutoLogin();
        }
        else
            UiManager.instance.OpenAuth();
    }

    private void AutoLogin()
    {
        if(user != null)
            UiManager.instance.CloseAuth();
        else
            UiManager.instance.OpenAuth();
    }

    private void AuthStateChanged(object sender, System.EventArgs e)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if (!signedIn && user != null)
                Debug.Log("Sign out");

            user = auth.CurrentUser;

            if (signedIn)
                Debug.Log($"Sign in: {user.DisplayName}");
        }
    }
}