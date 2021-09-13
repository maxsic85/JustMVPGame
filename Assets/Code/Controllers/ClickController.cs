using System;

namespace Code.MVC
{
    public class ClickController : IExecute
    {
        IInput _input;
        InputData _inputData;
        Action action;
        public ClickController(InputType inputType, InputData inputData)
        {       
            _input = GetInput(inputType);
            _inputData = inputData;
            action += Dos;
        }

        private IInput GetInput(InputType inputType)
        {
            return inputType switch
            {
                InputType.MOUSE => new MouseClick(),
                InputType.KEYBORD => new KeybordClick(),
                _ => throw new ArgumentException("")

            };
        }

        public void Execute(float time)
        {
            
            if (_input.GetFire1(_inputData))
            {
                "Fire1".PrintLog();
                action?.Invoke();
            }
            if (_input.GetFire2(_inputData))
            {
                "Fire2".PrintLog();
            }

        }

        private void Dos()
        {
            "debug".PrintLog();
        }

    }
}
