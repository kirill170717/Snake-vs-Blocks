using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Awake()
    {
        SaveController.Load<Data>();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            SaveController.Save(Data.instance);
        else
            SaveController.Load<Data>();
    }

    private void OnApplicationQuit()
    {
        SaveController.Save(Data.instance);
    }
}