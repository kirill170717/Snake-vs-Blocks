using System.Collections.Generic;
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

    private List<Challenges> Challenges
    {
        get { return Data.instance.player.challenges; }
        set { Data.instance.player.challenges = value; }
    }

    private void Start()
    {
        text.text = dict.challenges[id].key.ToString();
    }

    private void Update()
    {
        if (Challenges[id].complete)
            image.color = Color.gray;
    }

    public void OpenChallenge()
    {
        ChallengesManager.instance.OpenSelectedChallenge(type, id);
    }
}