using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    public static ChallengeManager instance;

    public ChallengeDict dict;

    [Header("Buttons")]
    public Button buttonChallenge;
    public Transform container;

    private List<Button> buttons = new();
    private Button clone;

    [Header("Selected challenge")]
    public Button buttonPlay;
    public Text label;
    public Text description;

    private void Awake()
    {
        instance = this;

        int number = 1;
        foreach (ChallengeDict.Challenge challenge in dict.challenges)
        {
            ChallengeTypes challengeTypes = challenge.type;
            int c = number - 1;
            buttonChallenge.GetComponentInChildren<Text>().text = (number).ToString();
            clone = Instantiate(buttonChallenge, container);
            clone.GetComponent<Button>().name = (number).ToString();
            clone.GetComponent<Button>().onClick.AddListener(() => OpenSelectedChallenge(challengeTypes, c));
            buttons.Add(clone);
            number++;
        }
    }

    public void OpenSelectedChallenge(ChallengeTypes type, int number)
    {
        buttonPlay.onClick.RemoveAllListeners();
        buttonPlay.onClick.AddListener(() => PlayChallenge(type, number));
        UiManager.instance.OpenSelectedChallenge();
        label.text = dict.challenges[number].key.ToString();
        description.text = LocalizationManager.instance.GetText(dict.challenges[number].description);
    }

    public void PlayChallenge(ChallengeTypes type, int number)
    {
        UiManager.instance.Play(type);
        Score.instance.ChallengeMode(type, number);
    }
}