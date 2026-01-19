using UnityEngine;
using System.Collections.Generic;
using MEC;
using Unity.VisualScripting;
using TMPro;
namespace EarthDefender
{
    public class BossFightStart : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField]
        GameObject spawners;
        [SerializeField]
        GameObject boss;
        [SerializeField]
        ParalaxController paralax;
        [SerializeField]
        GameObject bossWarning;

        [Header("Time")]
        [SerializeField]
        float timeToStart;
        [SerializeField]
        float textTime;



        public void Start()
        {
            Timing.RunCoroutine(_StartFightCoroutine());
        }
        IEnumerator<float> _StartFightCoroutine()
        {
            var time = 5f;
            yield return Timing.WaitForSeconds(timeToStart - time);
            spawners.SetActive(false);
            bossWarning.SetActive(true);
            yield return Timing.WaitForSeconds(textTime);
            bossWarning.SetActive(false);
            yield return Timing.WaitForSeconds(time);
            paralax.StopParalax();
            yield return Timing.WaitForSeconds(2f);
            boss.SetActive(true);
        }
    }
}
