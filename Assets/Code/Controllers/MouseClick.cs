using UnityEngine;

namespace Code.MVC
{
    public class MouseClick : IInput
    {
        public bool GetFire1(InputData inputData)
        {
            return  Input.GetMouseButtonDown(inputData.MouseData0);
        }

        public bool GetFire2(InputData inputData)
        {
            return Input.GetMouseButtonDown(inputData.MouseData1);
        }
    }
}
