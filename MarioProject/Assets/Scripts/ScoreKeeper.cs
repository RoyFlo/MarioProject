using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    public static int coins = 0;
    public static int livesLeft = 3;
    public static int timeLeft = 999;
    public static bool isFinished;

    void Start() {
        isFinished = false;
    }

    public static void addPoints(int points) {
        if (score + points <= 999999) {
            score += points;
        } else {
            score = 999999;
        }
    }

    public static void addCoins(int newCoins) {
        if (coins + newCoins <= 99) {
            coins += newCoins;
        } else {
            coins = 99;
        }
    }

    public static void addLives(int newLives) {
        if (livesLeft + newLives <= 99) {
            livesLeft += newLives;
        } else {
            livesLeft = 99;
        }
    }

    public static void removeLife(int lostLives = 1) {
        if (livesLeft - lostLives <= 0) {
            livesLeft = 0;
        } else {
            livesLeft -= lostLives;
        }
    }

    public static void resetLives() {
        livesLeft = 3;
    }

    public static void resetScore() {
        score = 0;
    }

    public static void resetCoins() {
        coins = 0;
    }
}
