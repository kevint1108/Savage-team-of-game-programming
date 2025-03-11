using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

    //[SerializeField] private ParticleSystem _particles;
    //public Coroutine deathAnim { private set; get; }
    private bool _alreadyHit;
    public static int totalHitCount = 0;
    public static int totalEnemies = 10;

    // Start is called before the first frame update
    void Start()
    {
        //_particles.enableEmission = false;
        _alreadyHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Death animation coroutine
    public IEnumerator Die()
    {
        // Rotate the game object as if it fell over
        this.transform.Rotate(-75, 0, 0);

        // Turn on Particles
        //_particles.enableEmission = true;

        // Wait for a few seconds
        yield return new WaitForSeconds(1.5f);

        // Destroy game object
        Destroy(gameObject);
    }
    public void ReactToHit()
    {
        if (_alreadyHit) return;

        _alreadyHit = true;
        Messenger.Broadcast(GameEvent.ENEMY_HIT);
        //Adds one to the kill counter when an enemy is hit.
        totalHitCount++;

        //Exits the game when the player kills all the enemies.
        if (totalHitCount >= totalEnemies){
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        // Get reference to wandering AI script
        // Pass in FALSE if such as script is attached
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }

        //
        SmartMovement smart = GetComponent<SmartMovement>();
        if (smart != null) smart.ChangeMovementState(SmartMovement.MovementState.PAUSED);

        //
        FireballShooter shooter = GetComponent<FireballShooter>();
        if (shooter != null) shooter.ChangeFiringState(FireballShooter.FiringState.PAUSED);
    
        // Die
        //if (deathAnim == null) deathAnim = StartCoroutine(Die());
        StartCoroutine(Die());
    }
}
