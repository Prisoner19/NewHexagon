using UnityEngine;

namespace Controller
{
    public class Event_C : MonoBehaviour 
    {
        private static Event_C instance;
        
        void Awake()
        {
            instance = this;
        }
        
        public static Event_C Instance
        {
            get { return instance; }
        }
    }

}
