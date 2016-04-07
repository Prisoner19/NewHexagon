using UnityEngine;

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
                CameraShake.Instance.Big_Shake ();
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

        public float Speed 
        {
            get { return speed; }
            set { speed = value; }
        }
        
        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
    }
}
