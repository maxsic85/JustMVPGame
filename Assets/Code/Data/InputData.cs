
using UnityEngine;

namespace Code.MVC
{
    [CreateAssetMenu(fileName ="InputData", menuName = "Data/Input") ]
   public class InputData:ScriptableObject
    {
        [SerializeField] int _mouseData0 =0;
        [SerializeField] int _mouseData1 = 1;
        [SerializeField] KeyCode _keyDataFire1 = KeyCode.Q;
        [SerializeField] KeyCode _keyDataFire2 = KeyCode.W;

        public int MouseData0 => _mouseData0;
        public int MouseData1 => _mouseData1;
        public KeyCode KeyDataFire1 => _keyDataFire1;
        public KeyCode KeyDataFire2 => _keyDataFire2;



    }
}
