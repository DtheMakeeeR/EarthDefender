using EarthDefender;
using Eflatun.SceneReference;
using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace EarthDefender
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] Player player;
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUI;

        public static GameManager Instance { get; private set; }
        public Player Player => player;

        int score;
        float restartTimer = 3f;
        
        void Awake()
        {
            Instance = this;
            player.OnDeath += GameOver;
        }

        void GameOver()
        {
            if (gameOverUI.activeSelf == false)
            {
                gameOverUI.SetActive(true);
            }
            Timing.RunCoroutine(_GameOverCoroutine().CancelWith(gameObject));
        }
        IEnumerator<float> _GameOverCoroutine()
        {
            yield return Timing.WaitForSeconds(restartTimer);
            Loader.Load(mainMenuScene);
        }
        public void AddScore(int amount) => score += amount;
        public int GetScore() => score;
    }
}