using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Code.Max.ContainerDelegate;

namespace Code.Max
{
    public class ContainerDelegate
    {
        public delegate void JustVoid();
        public delegate void Clearer(int key);
        public delegate int JustInt();

    }

    public interface IFight
    {
        void Kick();
    }
    public interface IFabric<T>
    {
        T Create(T t);
        List<T> currents();
        void Clear();
    }
    public interface Iclerable
    {
        delegate void Clear(int key);
    }

    public class Bot : IFight
    {
        int Power = 100;
        string name = "bot";
        public Bot[] bots;
        public Bot()
        {
            Power = 120;
            name = "new";
        }
        public Bot(int power, string name)
        {
            Power = power;
            this.name = name;
        }
        void IFight.Kick()
        {
            Debug.Log("BotKick");
        }
        public Bot this[int index]
        {
            get
            {
                return bots[index];
            }
            set
            {
                bots[index] = value;
            }
        }
    }
    public class Heal : IFight
    {
        int PowerHeal = 100;
        string name = "bot";
        public Heal[] heals;
        public Heal(int power, string name)
        {
            PowerHeal = power;
            this.name = name;
        }
        public Heal()
        {
            PowerHeal = 34;
            this.name = "gfgf";
        }
        void IFight.Kick()
        {
            Debug.Log("Heal");
        }
        public Heal this[int index]
        {
            get
            {
                return heals[index];
            }
            set
            {
                heals[index] = value;
            }
        }
    }

    [ExecuteInEditMode]
    public class Fabrik<T> : IFabric<T> where T : IFight
    {
        private List<T> current = new List<T>();
        public T Create(T t)
        {
            current.Add(t);
            return t;
        }

        public List<T> currents()
        {
            return current;
        }

        public void Clear()
        {
            for (int i = 0; i < current.Count; i++)
            {
                current.RemoveAt(i);
            }
        }
    }

    public enum KeyBtn
    {
        left = 0,
        right = 1
    }
    public class Interfaces01 : MonoBehaviour, Iclerable, IDisposable
    {
        [SerializeField] private bool update = false;
        JustVoid _justvoid;
        IFabric<Heal> fabrikHeal;
        IFabric<Bot> fabricBot;
        [SerializeField] KeyBtn keyBtn;


        void Start()
        {
            _justvoid = Spare;
            GetBot();
            GetHeal();

            Clear(GetKey(keyBtn), out _justvoid);
        }

        private int GetKey(KeyBtn keyBtn)
        {
            return keyBtn switch
            {
                KeyBtn.left => 0,
                KeyBtn.right => 1,
                _ => throw new ArgumentException("")

            };
        }

        private void Spare()
        { }

        private void GetHeal()
        {
            fabrikHeal = new Fabrik<Heal>();
            fabrikHeal.Create(new Heal(10, "heal1"));
            fabrikHeal.Create(new Heal(100, "heal2"));
            fabrikHeal.Create(new Heal(79, "heal3"));
        }

        private void GetBot()
        {
            fabricBot = new Fabrik<Bot>();
            fabricBot.Create(new Bot(10, "fdfdsf"));
            fabricBot.Create(new Bot(100, "der"));
        }

        private void Clear(int k, out JustVoid clearer)
        {
            clearer = _justvoid;
            if (k == 0) clearer += fabricBot.Clear;
            if (k == 1) clearer += fabrikHeal.Clear;

        }

        private void Update()
        {
            if (update)
            {
                var a = (GetKey(keyBtn) == 0) ? Input.GetMouseButtonDown(0) : Input.GetMouseButtonDown(1);

                if (a)
                {
                    Clear(GetKey(keyBtn), out _justvoid);
                    _justvoid?.Invoke();
                    Debug.Log("heal " + fabrikHeal.currents().Count);
                    Debug.Log("bot " + fabricBot.currents().Count);
                }
            }
            else
            {
                _justvoid = null;
                Dispose();
            }
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
