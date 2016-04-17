using UnityEngine;
using System.Collections;

namespace Controller
{
    public class Game_C : MonoBehaviour 
    {
        private static Game_C instance;

        public Player.Model obj_player;
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
            GUI_C.Instance.Hide_Indication();
            StartCoroutine(Wait_For_Spawning());
        }
        
        private IEnumerator Wait_For_Spawning()
        { 
            yield return new WaitForSeconds(2);
            pattern_spawner.Spawn_New_Pattern();
        }
        
        void Update () 
        {
            if(speedFactor < 1.25f)
            {
                speedFactor += Time.deltaTime * 0.05f;
            }
        }

        public static Game_C Instance 
        {
            get { return instance; }
        }
        
        public Player.Model Get_Player_Object()
        {
            return obj_player;
        }
    }
}
