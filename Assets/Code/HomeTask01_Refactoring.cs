using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public sealed class HomeTask01_Refactoring : MonoBehaviour
{
    [SerializeField] Data _data;
    [SerializeField] OperationType operationType = OperationType.Factorial;
    void OnEnable()
    {
        //  /* origin test*/  CalcFactorialOrigin(inputData);
        IMathCalculation<OperationType, Data> mathCalcilation = new Factorial();
        mathCalcilation.GetResult(operationType, _data);
    }
}

[Serializable]
public struct Data
{
    [SerializeField] string inpytData;
    [SerializeField] string keyForExit;

    public Data(string inpytData, string keyData)
    {
        this.inpytData = inpytData;
        this.keyForExit = keyData;
    }

    public string InputData => inpytData;
    public string KeyForExit => keyForExit;

}
public sealed class Factorial : IMathCalculation<OperationType, Data>
{
    private int _inputValue = 0;
    bool exit = false;
    Dictionary<OperationType, Action> dict;
    public void GetResult(OperationType type, Data value)
    {
        CalcFactorialRefactoring(type, value);
    }
    public static void CalcFactorialOrigin(string S)
    {
        if (S == "q")
        {
            Debug.Log("Exit");
            return;
        }

        int M = Int32.Parse(S);
        int c1 = 1; int c2 = 0;
        int c3 = 0;
        for (int i = 1; i <= M; i++)
        {
            c1 = c1 * i;
            c2 = c2 + i;
            if (i % 2 == 0)
            {
                c3 = i;
            }
        }
        Debug.Log("Факториал равет " + c1);
        Debug.Log("Сума от 1 до N равна " + c2);
        Debug.Log("максимальное четное число меньше N равно" + c3);

    }
    public void CalcFactorialRefactoring(OperationType opearation, Data value)
    {
        _inputValue = CheckInput(value,out exit);
        if (exit) return;
       dict = new Dictionary<OperationType, Action>
        {
            [OperationType.Factorial] = GetFactorial,
            [OperationType.SummFactorial] = GetSumFactorial,
            [OperationType.MaxFactorial] = GetMaxFactorial,
        };

        dict[opearation]?.Invoke();
    }
    private static int CheckInput(Data value,out bool exit)
    {
        int _inputValue;
        exit = false;
        var checkDigit = Int32.TryParse(value.InputData, out _inputValue);
        if (value.InputData == value.KeyForExit)
        {
            Debug.Log($"Exit");
            exit = true;
            Application.Quit();
        }
        if (!checkDigit && !exit)
        {
            throw new Exception("НЕ ВЕРНЫЙ ФОРМАТ ВВЕДЕННЫХ ДАННЫХ");
        }
        return _inputValue;
    }
    private void GetFactorial()
    {
        double _result = 1;
        for (int i = 1; i <= _inputValue; i++)
        {
            _result = _result * i;
        }
        Debug.Log($" Факториал равен {_result}");
    }
    private void GetSumFactorial()
    {
        double _result = 0;
        for (int i = 1; i <= _inputValue; i++)
        {
            _result = _result + i;
        }
        Debug.Log($"Сума от 1 до N равна {_result}");
    }
    private void GetMaxFactorial()
    {
        int _result = 0;
        for (int i = 1; i <= _inputValue; i++)
        {
            if (i % 2 == 0)
            {
                _result = i;
            }
        }
        Debug.Log($"максимальное четное число меньше N равно { _result}");
    }
    public void RemoveAction()
    {
        foreach (var item in dict)
        {
            dict[item.Key] -= item.Value;
        }
    }
    ~Factorial()
    {
        RemoveAction();
    }
}

public interface IMathCalculation<T, Y> where Y : struct
{
    void GetResult(T type, Y value);
}

public enum OperationType
{
    Factorial = 0,
    SummFactorial = 1,
    MaxFactorial = 2
}
