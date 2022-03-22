using UnityEngine;
using UnityEngine.UI;

public class SelectChallenge : MonoBehaviour
{
    public static SelectChallenge instance;

    public Text label;
    public Text description;

    [HideInInspector]
    public bool challenge = false;

    private string challengeDescription;

    private void Awake()
    {
        instance = this;
    }

    public void ChallengeNumber(int number)
    {
        UiManager.instance.OpenSelectedChallenge();
        switch (number)
        {
            case 1:
                label.text = "01";
                challengeDescription = "challenge_01";
                break;
            case 2:
                label.text = "02";
                challengeDescription = "challenge_02";
                break;
            case 3:
                label.text = "03";
                challengeDescription = "challenge_03";
                break;
            case 4:
                label.text = "04";
                challengeDescription = "challenge_04";
                break;
            case 5:
                label.text = "05";
                challengeDescription = "challenge_05";
                break;
            case 6:
                label.text = "06";
                challengeDescription = "challenge_06";
                break;
        }

        string response = LocalizationManager.instance.GetText(challengeDescription);
        if (!string.IsNullOrEmpty(response))
            description.text = response;
        else
            Debug.Log("Localization Error!: The '" + challengeDescription + "' key doesn't exist!");
    }

    public void PlayingChallenge()
    {
        challenge = true;
        UiManager.instance.PlayChallenge();
    }
}