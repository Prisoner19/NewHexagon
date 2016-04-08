using UnityEngine;
using System.Collections;

namespace Controller
{
    public class Player_C : MonoBehaviour 
    {
        private static Player_C instance;
        
        void Awake()
        {
            instance = this;
        }

        // Use this for initialization
        void Start () 
        {
        
        }
        
        // Update is called once per frame
        void Update () 
        {
        
        }
        
        public static Player_C Instance
        {
            get { return instance; }
        }
    }
}

