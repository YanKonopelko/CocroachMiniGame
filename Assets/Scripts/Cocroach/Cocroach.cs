using UnityEngine;

public class Cocroach : MonoBehaviour
{
    private CocroachMovement _cocroachMovement;

    public void Death()
    {
        MiniGameManager.instance.EndGame();
    }
    
}

