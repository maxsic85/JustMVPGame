using System;

namespace Code.MVC
{
    public interface IBonus:IEventable
    {
         string BonusType { get; set; }
        event Action ExecuteBonus;
    }
}
