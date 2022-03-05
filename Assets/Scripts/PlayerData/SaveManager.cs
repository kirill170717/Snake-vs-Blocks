using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Awake() => Data.instance = SaveController.Load<Data>();

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            SaveController.Save(Data.instance);
    }
}