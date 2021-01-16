using UnityEngine;
using System.Collections;

namespace GodClass.Refactored {

    /* When you're trying to divide responsibilities among your different
     * C# classes, one common technique is to isolate anything that instantiates
     * stuff and call it a [Whatever]Factory. As you can see, the code
     * for spawning stuff can get quite complicated, and it's a common
     * source of problems - it's best if you know exactly where to look when
     * something goes wrong.
     * 
     * This example is somewhat complicated because it's using coroutines and
     * randomly selecting a direction. Not all factories are this complex. But 
     * you'll often want to set up a Factory class even if your spawning
     * code starts off simple, because you can be pretty sure it will grow over time.
     * 
     * Factory is an example of a _design pattern_, which is an abstract pattern
     * for setting up your code. There are many others that developers have identified
     * over many years; some are specific to games and some (like this one) are more
     * general-purpose. When you feel reasonably comfortable writing code, design
     * patterns are the next big step you can take to become a better engineer. See the
     * resources in this unit for some places to get started, or just look online.
     */

    public class MeteorFactory : MonoBehaviour {

        public GameObject meteorPrefab;
        public float minTimeBetweenMeteors;
        public float maxTimeBetweenMeteors;
        public float meteorMinPush;
        public float meteorMaxPush;


        void Start() {
            StartCoroutine(LaunchMeteor());
        }

        IEnumerator LaunchMeteor() {
            while (true) {
                GameObject newMeteor = Instantiate(meteorPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                Rigidbody2D newMeteorRB = newMeteor.GetComponent<Rigidbody2D>();
                newMeteorRB.AddForce(GetRandomPush() * 10f, ForceMode2D.Impulse);
                float timeUntilNextMeteor = Random.Range(minTimeBetweenMeteors, maxTimeBetweenMeteors);
                yield return new WaitForSeconds(timeUntilNextMeteor);
            }
        }

        Vector3 GetRandomPush() {
            Vector2 newMeteorDirection = new Vector2(
                                            Random.Range(0f, 1f),
                                            Random.Range(0f, -1f));
            float newMeteorPush = 1f + Random.Range(meteorMinPush/100f, meteorMaxPush/100f);
            return newMeteorDirection * newMeteorPush;
        }


    }
}