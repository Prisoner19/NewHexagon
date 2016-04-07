using UnityEngine;
using Controller;
using Enums;

namespace Player
{
    public class Model : MonoBehaviour 
    {
        private Shooting obj_shooting;
        private Rendering obj_rendering;
        
        private Direction facing_direction;
        
        // Use this for references
        void Awake()
        {
            Get_Component_References();
        }

        // Use this for initialization
        void Start () 
        {
        
        }
        
        // Update is called once per frame
        void Update () 
        {
        
        }
        
        public void Shoot(Direction dir)
        {
            obj_shooting.Shoot(dir);
        }
        
        private void Get_Component_References()
        {
            obj_shooting = gameObject.GetComponent<Shooting>();
            obj_rendering = gameObject.GetComponent<Rendering>();
            
            obj_shooting.Set_Model(this);
            obj_rendering.Set_Model(this);
        }
    }
}

