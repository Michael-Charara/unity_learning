using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodClass.Refactored {

    /* This is just about the simplest possible movement code,
     * but notice that it checks player input in Update and 
     * actually moves the ship in FixedUpdate. This is an 
     * important Unity pattern that prevents a lot of bugs. See
     * 
     * https://stackoverflow.com/questions/34447682/what-is-the-difference-between-update-fixedupdate-in-unity
     * 
     * and
     * https://docs.unity3d.com/Manual/ExecutionOrder.html
     * 
     */

    public class ShipMovement : MonoBehaviour {

        [SerializeField]
        float shipSpeed;

        Rigidbody2D rb2d;
        float xSpeed;
        float ySpeed;

        void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update() {
            xSpeed = Input.GetAxis("Horizontal") * shipSpeed;
            ySpeed = Input.GetAxis("Vertical") * shipSpeed;
        }

        void FixedUpdate() {
            rb2d.velocity = new Vector2(xSpeed, ySpeed);
        }
    }
}
 
 