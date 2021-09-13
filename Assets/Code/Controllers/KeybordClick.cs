using UnityEngine;

namespace Code.MVC
{
    public class KeybordClick : IInput
    {
        public bool GetFire1(InputData inputData)
        {
            return Input.GetKeyDown(inputData.KeyDataFire1);
        }

        public bool GetFire2(InputData inputData)
        {
            return Input.GetKeyDown(inputData.KeyDataFire2);
        }
    }
}
