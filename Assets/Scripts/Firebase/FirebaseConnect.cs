using UnityEngine;
using Firebase;
using Firebase.Auth;

public class FirebaseConnect : MonoBehaviour
{
    public static FirebaseAuth auth;
    public static FirebaseUser user;

    void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
}