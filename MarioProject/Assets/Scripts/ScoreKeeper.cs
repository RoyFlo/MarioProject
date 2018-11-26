using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    public static int coins = 0;
    public static int livesLeft = 3;
    public static int timeLeft;
    public static bool isFinished;
    public static bool isDead;

    private static int previousTime;

    void Start() {
        isFinished = false;
        isDead = false;

        // TODO: Find out why this does not work on SonicBonus level only
        // * Changing name to BonusSonic does not work
        // * Using scene index does not 
        if (SceneManager.GetActiveScene().name.Contains("Bonus")) {
            timeLeft = previousTime;
        }
        else {
            timeLeft = 999;
        }
    }

    void OnDisable() {
        previousTime = timeLeft;
    }

    public static void addPoints(int points) {
        if (score + points <= 999999) {
            score += points;
        }
        else {
            score = 999999;
        }
    }

    public static void addCoins(int newCoins) {

        if (coins + newCoins >= 100) {
            addLives(1);
            coins += newCoins - 100;
            SoundFXScript.OneUp();
        }
        else {
            coins += newCoins;
        }
    }

    public static void addLives(int newLives) {
        if (livesLeft + newLives <= 99) {
            livesLeft += newLives;
        }
        else {
            livesLeft = 99;
        }
    }

    public static void removeCoins(int coinsSpent) {
        if (coins - coinsSpent <= 0) {
            coins = 0;
        }
        else {
            coins -= coinsSpent;
        }
    }

    public static void removeLife(int lostLives = 1) {
        if (livesLeft - lostLives <= 0) {
            livesLeft = 0;
        }
        else {
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
