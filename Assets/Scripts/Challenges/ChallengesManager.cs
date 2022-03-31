using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChallengesManager : MonoBehaviour
{
    public static ChallengesManager instance;

    public ChallengesDict dict;

    [Header("Button")]
    public Button buttonChallenge;
    public Transform container;

    [HideInInspector] public List<Challenge> buttons;

    [Header("Selected challenge")]
    public Button buttonPlay;
    public TMP_Text label;
    public TMP_Text description;

    private List<Challenges> Challenges
    {
        get { return Data.instance.player.challenges; }
        set { Data.instance.player.challenges = value; }
    }

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < dict.challenges.Count; i++)
        {
            var obj = Instantiate(buttonChallenge, container);
            obj.name = dict.challenges[i].key.ToString();

            buttons.Add(obj.GetComponent<Challenge>());
            buttons[i].type = dict.challenges[i].type;
            buttons[i].id = i;

            if (i + 1 > Challenges.Count)
                Challenges.Add(new Challenges() { key = dict.challenges[i].key });
        }
    }

    public void OpenSelectedChallenge(ChallengesTypes type, int id)
    {
        buttonPlay.onClick.RemoveAllListeners();
        buttonPlay.onClick.AddListener(() => PlayChallenge(type, id));
        UiManager.instance.OpenChallengeMenu();
        label.text = dict.challenges[id].key.ToString();
        description.text = LocalizationManager.instance.GetText(dict.challenges[id].description);
    }

    public void PlayChallenge(ChallengesTypes type, int id)
    {
        UiManager.instance.Play(type);
        Score.instance.ChallengeMode(type, id);
    }

    public void ChallengeComplete(int id)
    {
        Challenges[id].complete = true;
    }
}