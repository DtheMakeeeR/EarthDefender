using EarthDefender;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EarthDefender
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] TMP_Text health;
        [SerializeField] TextMeshProUGUI score;

        void Update()
        {
            health.text = $"Health: {GameManager.Instance.Player.Health}";
            score.text = $"Score: {GameManager.Instance.GetScore()}";
        }
    }
}