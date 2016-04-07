using UnityEngine;
using System.Collections;

namespace Controller
{
    public class Game : MonoBehaviour 
    {
        private static Game instance;

        public SpriteRenderer sprRnd_bg;

        public Transform playerTransf;
        
        public PatternSpawner pattern_spawner;

        public float speedFactor = 0.3f;
        private float timeCounter = 0;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            pattern_spawner.Spawn_New_Pattern ();
        }

        void Update () 
        {
            if (timeCounter < 1) 
            {
                timeCounter += Time.deltaTime * 0.5f;
            } 
            else 
            {
                speedFactor = 1;
            }
        }

        public static Game Instance 
        {
            get { return instance; }
        }
    }
}
