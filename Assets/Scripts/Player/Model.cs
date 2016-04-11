using UnityEngine;
using Enums;

namespace Player
{
    public class Model : MonoBehaviour 
    {
        private Shooting obj_shooting;
        private Rendering obj_rendering;
        private CollisionChecking obj_collision;
        
        private Direction facing_direction;
        
        private int score;
        
        // Use this for references
        void Awake()
        {
            Get_Component_References();
        }

        // Use this for initialization
        void Start () 
        {
            score = 0;
            Controller.GUI_C.Instance.Set_Score();
        }
        
        // Update is called once per frame
        void Update () 
        {
        
        }
        
        public void Shoot(Direction dir)
        {
            obj_shooting.Shoot(dir);
        }
        
        public void Decrease_Score()
        {
            score = (score > 0) ? score - 1 : 0;
        }
        
        public void Increase_Score()
        {
            score = (score < 9) ? score + 1 : 9;
        }
        
        public int Ask_For_Score()
        {
            return score;
        }
        
        private void Get_Component_References()
        {
            obj_shooting = gameObject.GetComponent<Shooting>();
            obj_rendering = gameObject.GetComponent<Rendering>();
            obj_collision = gameObject.GetComponent<CollisionChecking>();
            
            obj_shooting.Set_Model(this);
            obj_rendering.Set_Model(this);
            obj_collision.Set_Model(this);
        }
    }
}

