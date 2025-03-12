using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RayShooter : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip hitWallSound;
    [SerializeField] AudioClip hitEnemySound;
    [SerializeField] AudioClip gunShotSound;

    // Private field; stores a reference to the camera
    private Camera cam;

    //Counts how many enemy player has killed.
    //int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        //Hide the cursor 
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;


    }

    //OnGUI method; for drawing a crosshair
    private void OnGUI()
    {
        int size = 24;

        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(posX, posY, size, size), "+");

        if (GUI.Button(new Rect(10, 10, 180, 20), "Mission: Take all you can")) 
        {
            Debug.Log("Button has been clicked");
        }
    }

    // Coroutine
    // Please down a sphere at a location, which then disappears after one second
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        // Create a new sphere game object
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.localScale = Vector3.one * 0.05f;

        // Place sphere at pos passed in 
        sphere.transform.position = pos;

        // Wait one second
        yield return new WaitForSeconds(1);

        // Destroy the sphere
        Destroy(sphere);

    }

    // Update is called once per frame
    void Update()
    {
        // When the player left-clicks, perform a raycast
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {

            // Calculate the center of the screen
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

            // Create a ray whose starting point is the middle of the screen
            Ray ray = cam.ScreenPointToRay(point);

            soundSource.PlayOneShot(gunShotSound);

            // Create a raycast object to figure out whar was hit
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Print out the coords of where the ray hit
                Debug.Log("Hit:" + hit.point);
                GameObject hitObject = hit.transform.gameObject;

                // If the object hit was a reactive target, say that it was hit
                // Otherwise, place down a sphere

                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                
                // EnemyHealth enemyHealth = hitObject.GetComponent<EnemyHealth>();
                if (target != null)
                {
                    target.ReactToHit();
                    soundSource.PlayOneShot(hitEnemySound);
                    //if (target.deathAnim != null) Messenger.Broadcast(GameEvent.ENEMY_HIT);

                    // enemyHealth.TakeDamage(); // Reduce health by q
                    Debug.Log("Enemy hit!");
                }

                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                    soundSource.PlayOneShot(hitWallSound);
                }

            }
        }
    }
}

