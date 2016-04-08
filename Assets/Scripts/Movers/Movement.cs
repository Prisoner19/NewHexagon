using UnityEngine;
using Enums;

namespace Mover
{
    public class Movement : MonoBehaviour 
    {
        private Model obj_model;
        
        private float speed;
        private float object_width, object_height;
        private float player_width, player_height;

        // Use this for initialization
        void Start () 
        {
            object_width = this.gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
            object_height = this.gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

            player_width = Controller.Game_C.Instance.playerTransf.gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
            player_height = Controller.Game_C.Instance.playerTransf.gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
        }
        
        // Update is called once per frame
        void Update () 
        {
            Move ();
        }
        
        void FixedUpdate()
        {
            bool isColliding = Check_For_Collision ();

            if (isColliding) 
            {
                if(obj_model.Ask_For_MoverType() == MoverType.Enemy)
                {
                    CameraShake.Instance.Big_Shake ();
                }
                
                obj_model.Get_Killed();
            }
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards (transform.position, Vector3.zero, speed * Controller.Game_C.Instance.speedFactor * Time.deltaTime);
        }

        private bool Check_For_Collision()
        {
            Vector3 playerPos = Controller.Game_C.Instance.playerTransf.position;

            float horDis = Mathf.Abs (playerPos.x - gameObject.transform.position.x);
            float verDis = Mathf.Abs (playerPos.y - gameObject.transform.position.y);

            if(horDis < (object_width/2 + player_width/2))
            {
                if (verDis < (object_height / 2 + player_height / 2)) 
                {
                    return true;
                }
            }

            return false;
        }
        
        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
        
        internal void Set_Initial_Position(Enums.Direction dir)
        {
            switch (dir)
            {
                case Enums.Direction.Left:  transform.SetPositionXY(-36,0); break;
                case Enums.Direction.Up:    transform.SetPositionXY(0,36); break;
                case Enums.Direction.Right: transform.SetPositionXY(36,0); break;
                case Enums.Direction.Down:  transform.SetPositionXY(0,-36); break;
                default: break;
            }
        }
        
        internal void Set_Speed(float speed)
        {
            this.speed = speed;
        }
    }
}
