using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Update()
    {
        Lifetime += Time.deltaTime;
    }

    public bool IsDead { get; private set; }

    public float Lifetime { get; private set; }

    public void Kill()
    {
        if (IsDead)
            return;

        IsDead = true;
    }    
}
