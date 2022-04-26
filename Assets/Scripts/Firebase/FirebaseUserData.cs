using System.Collections.Generic;

public class FirebaseUserData
{
    public string username;
    public string email;
    public int life;
    public int recordLevel;
    public int completedLevel;
    public int recordInfinite;
    public int coin;
    public List<bool> purchaseSkin;
    public List<Challenges> challenges;
    public int brokenBlocks;
    public int circlesCollected;
    public int totalSnakeLength;

    public FirebaseUserData(string username, string email, int life, int recordLevel,
        int completedLevel, int recordInfinite, int coin, List<bool> purchaseSkin, 
        List<Challenges> challenges, int brokenBlocks, int circlesCollected, int totalSnakeLength)
    {
        this.username = username;
        this.email = email;
        this.life = life;
        this.recordLevel = recordLevel;
        this.completedLevel = completedLevel;
        this.recordInfinite = recordInfinite;
        this.coin = coin;
        this.purchaseSkin = purchaseSkin;
        this.challenges = challenges;
        this.brokenBlocks = brokenBlocks;
        this.circlesCollected = circlesCollected;
        this.totalSnakeLength = totalSnakeLength;
    }
}