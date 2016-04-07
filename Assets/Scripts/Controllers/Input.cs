using UnityEngine;
using System.Collections;
using System;

namespace Controller
{
    public class Input : MonoBehaviour 
    {
        private static Input instance;
        
        void Awake()
        {
            instance = this;
        }

        void Start () 
        {
        
        }
        
        void Update () 
        {
            Check_For_Input();
        }

        private void Check_For_Input()
        {
            throw new NotImplementedException();
        }

        public static Input Instance
        {
            get { return instance; }
        }
    }
}