using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health;
    public UnityEvent OnDeathEvent;
    public void GetDamadge(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            OnDeathEvent?.Invoke();
        }
    }
}
