using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;

    [Header("Dictionaries")]
    public ChallengesDict challengeDict;
    public SkinsDict skinDict;

    [Header("Text")]
    public TMP_Text scoreView;
    public TMP_Text skinsView;
    public TMP_Text recordView;
    public TMP_Text finalScore;
    public TMP_Text levelView;
    public TMP_Text lifeView;

    [HideInInspector] public ChallengesTypes typeChallenge;
    [HideInInspector] public int challengeId;

    private int scoreLevel;
    private int tempScoreLevel;
    private int scoreInfinite;
    private int tempScoreInfinite;
    private float time;

    private int RecordLevel
    {
        get { return Data.instance.player.recordLevel; }
        set { Data.instance.player.recordLevel = value; }
    }
    private int RecordInfinite
    {
        get { return Data.instance.player.recordInfinite; }
        set { Data.instance.player.recordInfinite = value; }
    }
    private int Level
    {
        get { return Data.instance.player.completedLevel; }
        set { Data.instance.player.completedLevel = value; }
    }

    public int Life
    {
        get { return Data.instance.player.life; }
        set { Data.instance.player.life = value; }
    }
    public int Coin
    {
        get { return Data.instance.player.coin; }
        set { Data.instance.player.coin = value; }
    }

    private void Awake()
    {
        instance = this;

        if (Life < 1)
            Life = 1;

        levelView.text = Level.ToString();
    }

    public void Update()
    {
        lifeView.text = Life.ToString();
        skinsView.text = Coin.ToString();

        if (GameMode.instance.levels.isOn)
        {
            tempScoreLevel = scoreLevel;

            if (RecordLevel <= tempScoreLevel)
                RecordLevel = tempScoreLevel;

            recordView.text = RecordLevel.ToString();
            finalScore.text = scoreLevel.ToString();
        }
        else
        {
            tempScoreInfinite = scoreInfinite;

            if (RecordInfinite <= tempScoreInfinite)
                RecordInfinite = tempScoreInfinite;

            recordView.text = RecordInfinite.ToString();
            finalScore.text = scoreInfinite.ToString();

        }

        switch (typeChallenge)
        {
            case ChallengesTypes.NoType:
                if (GameMode.instance.levels.isOn)
                    scoreView.text = scoreLevel.ToString();
                else
                    scoreView.text = scoreInfinite.ToString();
                break;

            case ChallengesTypes.SnakeLength:
                scoreView.text = SnakeMovement.instance.SnakeLength.ToString() + "/" + challengeDict.challenges[challengeId].value;
                if (SnakeMovement.instance.SnakeLength >= challengeDict.challenges[challengeId].value)
                    UiManager.instance.CompleteChallenge(challengeId);
                break;

            case ChallengesTypes.Survive:
                time -= Time.deltaTime;
                scoreView.text = Mathf.Round(time).ToString();

                if (time < 0)
                    UiManager.instance.CompleteChallenge(challengeId);
                break;

            case ChallengesTypes.DestroyBlocksCount:
            case ChallengesTypes.CollectBalls:
            case ChallengesTypes.ScorePoints:
            case ChallengesTypes.DestroyBlocksSizeCount:
                scoreView.text = scoreInfinite.ToString() + "/" + challengeDict.challenges[challengeId].value;

                if (scoreInfinite == challengeDict.challenges[challengeId].value)
                    UiManager.instance.CompleteChallenge(challengeId);
                break;
        }
    }

    public void BuySkin(int id)
    {
        Debug.Log(id);
        if (skinDict.skins[id].price <= Coin)
        {
            Coin -= skinDict.skins[id].price;
            SkinsManager.instance.UpdatePurchase(id);
        }
        else
            UiManager.instance.OpenBuySkinPoints();
    }

    public void ChallengeMode(ChallengesTypes type, int id)
    {
        typeChallenge = type;
        challengeId = id;

        if (type == ChallengesTypes.NoType)
            scoreView.text = id.ToString();
        else if (type == ChallengesTypes.Survive)
            time = challengeDict.challenges[id].value;
    }

    public void Counter()
    {
        scoreInfinite++;
    }

    public void SizeCounter(int size)
    {
        if (size >= challengeDict.challenges[challengeId].size)
            scoreInfinite++;
    }

    public void DestructionPoints()
    {
        if (typeChallenge == ChallengesTypes.ScorePoints)
            scoreInfinite++;
        else
        {
            if (GameMode.instance.levels.isOn)
            {
                scoreLevel++;
                scoreView.text = scoreLevel.ToString();
            }
            else
            {
                scoreInfinite++;
                scoreView.text = scoreInfinite.ToString();
            }
        }
    }

    public void UnlockingPoints()
    {
        Coin++;
        skinsView.text = Coin.ToString();
    }

    public void CompletedLevel()
    {
        Level++;
        levelView.text = Level.ToString();
        UnlockingPoints();
    }

    public void Death()
    {
        Life--;
        if (Life < 0)
            Life = 0;

        lifeView.text = Life.ToString();
    }
}