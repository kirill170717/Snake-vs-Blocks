using UnityEngine;
using UnityEngine.UI;

public class SelectChallenge : MonoBehaviour
{
    public Text label;
    public Text description;

    private int number;
    public void ChallengeNumber(int value)
    {
        UiManager.instance.OpenSelectedChallenge();
        number = value;
        switch (value)
        {
            case 1:
                label.text = "01";
                description.text = "Break 10 blocks";
                break;
            case 2:
                label.text = "02";
                
                break;
            case 3:
                label.text = "03";
                
                break;
            case 4:
                label.text = "04";
                
                break;
            case 5:
                label.text = "05";
                
                break;
        }
    }

    public void PlayingChallenge()
    {
        switch (number)
        {
            case 1:
                
                break;
            case 2:
                
                break;
            case 3:
                
                break;
            case 4:
                
                break;
            case 5:
                
                break;
        }
    }
}
