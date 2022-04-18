using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Challenge : MonoBehaviour
{
    public ChallengesDict dict;

    public Image image;
    public TMP_Text text;

    public ChallengesTypes type;
    public int id;

    private void Start()
    {
        text.text = dict.challenges[id].key.ToString();
    }

    public void UpdateUI(Challenges challenges)
    {
        if (challenges.complete == true)
            image.color = Color.gray;
    }

    public void OpenChallenge()
    {
        ChallengesManager.instance.OpenSelectedChallenge(type, id);
    }
}