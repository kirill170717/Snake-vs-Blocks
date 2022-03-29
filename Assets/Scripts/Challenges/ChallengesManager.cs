using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengesManager : MonoBehaviour
{
    public static ChallengesManager instance;

    public ChallengesDict dict;

    [Header("Button")]
    public Button buttonChallenge;
    public Transform container;

    private Button clone;

    [HideInInspector] public List<Image> buttonImages;

    [Header("Selected challenge")]
    public Button buttonPlay;
    public Text label;
    public Text description;

    private List<Challenges> Challenges
    {
        get { return Data.instance.player.challenges; }
        set { Data.instance.player.challenges = value; }
    }

    private void Awake()
    {
        instance = this;

        InstantiateButtons();
    }

    private void InstantiateButtons()
    {
        int number = 0;
        foreach (ChallengesDict.Challenge challenge in dict.challenges)
        {
            ChallengesTypes challengeTypes = challenge.type;
            int c = number;

            buttonChallenge.GetComponentInChildren<Text>().text = dict.challenges[c].key.ToString();
            clone = Instantiate(buttonChallenge, container);
            clone.name = dict.challenges[c].key.ToString();
            clone.onClick.AddListener(() => OpenSelectedChallenge(challengeTypes, c));
            buttonImages.Add(clone.image);

            if (c + 1 > Challenges.Count)
                Challenges.Add(new Challenges() { key = dict.challenges[c].key });

            number++;
        }

        for (int i = 0; i < Challenges.Count; i++)
            if (Challenges[i].complete == true)
                buttonImages[i].color = Color.gray;
    }

    public void OpenSelectedChallenge(ChallengesTypes type, int number)
    {
        buttonPlay.onClick.RemoveAllListeners();
        buttonPlay.onClick.AddListener(() => PlayChallenge(type, number));
        UiManager.instance.OpenSelectedChallenge();
        label.text = dict.challenges[number].key.ToString();
        description.text = LocalizationManager.instance.GetText(dict.challenges[number].description);
    }

    public void PlayChallenge(ChallengesTypes type, int number)
    {
        UiManager.instance.Play(type);
        Score.instance.ChallengeMode(type, number);
    }

    public void ChallengeComplete(int number)
    {
        Challenges[number].complete = true;
    }
}