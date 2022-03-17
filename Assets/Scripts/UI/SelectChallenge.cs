using UnityEngine;
using UnityEngine.UI;

public class SelectChallenge : MonoBehaviour
{
    public Text label;
    public Text description;
    public void ChallengeNumber(int value)
    {
        UiManager.instance.OpenSelectedChallenge();
        switch (value)
        {
            case 1:
                label.text = "01";
                description.text = "Break 10 blocks";
                break;
            case 2:
                label.text = "02";
                description.text = "Break 20 blocks";
                break;
            case 3:
                label.text = "03";
                description.text = "Break 40 blocks";
                break;
            case 4:
                label.text = "04";
                description.text = "Break 60 blocks";
                break;
            case 5:
                label.text = "05";
                description.text = "Break 80 blocks";
                break;
        }
    }
}
