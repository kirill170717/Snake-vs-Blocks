using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text view;
    private int destroyPoints;
    private int unlockingPoints;
    public void DestructionPoints()
    {
        destroyPoints++;
        view.text = destroyPoints.ToString();
    }

    public void UnlockingPoints()
    {
        unlockingPoints++;
    }
}