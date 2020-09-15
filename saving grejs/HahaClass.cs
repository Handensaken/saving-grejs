using System;


namespace saving_grejs
{
    public class HahaClass
    {

        private float[] position = {0.0f,0.0f};
        private string name;

        private bool alive;
        public HahaClass(float[] newPos, string newName, bool lifeStatus){
            position = newPos;
            name = newName;
            alive = lifeStatus;
        }

        public class HahaSubClass
        {

        }
    }
}
