using System;

namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        protected int baseAtk=0;
        protected int baseDef=0;
        protected int baseSpeed=0;

        protected int moveRange = 1;
        protected int atkRange = 0;

        protected float baseAtkAdd = 0;
        protected float baseDefAdd = 0;
        protected float baseSpdAdd = 0;

        protected float attack = 0;
        protected float defense = 0;
        protected float speed = 0;

        protected EUnitClass eUnitClass = EUnitClass.Villager;



        public int BaseAtk { get=>baseAtk; protected set=>baseAtk=Clamp(value); }
        public int BaseDef { get => baseDef; protected set => baseDef = Clamp(value); }
        public int BaseSpd { get => baseSpeed; protected set => baseSpeed = Clamp(value); }

        public int MoveRange { get => moveRange; protected set => moveRange = Clamp(value,1,10); }
        public int AtkRange { get => atkRange; protected set => atkRange = Clamp(value, 0, 5); }

        public float BaseAtkAdd { get => baseAtkAdd; protected set => BaseAtkAdd = value; }
        public float BaseDefAdd { get => baseDefAdd; protected set => baseDefAdd = value; }
        public float BaseSpdAdd { get => baseSpdAdd; protected set => baseSpdAdd = value; }

        public virtual float Attack { get => ClampFloat((float)BaseAtk*(1+BaseAtkAdd));}  //Lo castee a float para que no redondeara.(problema de c#)
        public virtual float Defense { get => ClampFloat((float)BaseDef * (1 + BaseDefAdd)); }
        public virtual float Speed { get => ClampFloat((float)BaseSpd * (1 + BaseSpdAdd)); }

        protected Position CurrentPosition = new Position(0, 0);

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;

            Random rnd = new Random((int)DateTime.Now.Ticks);
            CurrentPosition = new Position(rnd.Next(0,100),rnd.Next(0,100));
        }

        public virtual bool Interact(Unit otherUnit)
        {
            if (UnitClass == EUnitClass.Villager)
            {
                goto CantAtackO;
            }

            else if (UnitClass == EUnitClass.Squire && otherUnit.UnitClass != EUnitClass.Villager)
            {
                goto CanAtackO;
            }
            else if (UnitClass == EUnitClass.Soldier && otherUnit.UnitClass != EUnitClass.Villager)
            {
                goto CanAtackO;
            }
            else if (UnitClass == EUnitClass.Ranger && otherUnit.UnitClass != EUnitClass.Mage || otherUnit.UnitClass != EUnitClass.Dragon)
            {
                goto CanAtackO;
            }
            else if (UnitClass == EUnitClass.Mage && otherUnit.UnitClass != EUnitClass.Mage)
            {
                goto CanAtackO;
            }
            else if (UnitClass == EUnitClass.Imp && otherUnit.UnitClass != EUnitClass.Dragon)
            {
                goto CanAtackO;
            }
            else if (UnitClass == EUnitClass.Orc && otherUnit.UnitClass != EUnitClass.Dragon)
            {
                goto CanAtackO;

            }

            else if (UnitClass == EUnitClass.Dragon)
            {
                goto CanAtackO;
            }

            else
            {
                goto CantAtackO;
            }
            CanAtackO:
            return true;
            CantAtackO:
            return false;
        }

        public virtual bool Interact(Prop prop)
        {
            if (UnitClass == EUnitClass.Villager)
            {
                goto CanInteract;
            }
            else
            {
                goto CantInteract;

            }

            CanInteract:
            return true;
            CantInteract:
            return false;
        }


        public bool Move(Position targetPosition)
        {
            int range = MoveRange;
            range -= targetPosition.x;
            range -= targetPosition.y;
            if (range<=0)
            {
                CurrentPosition = targetPosition;
                return true;
            }
            return false;
        }


        public int Clamp( int value,int min = 0, int max = 255)
        {
            if (value<min)
            {
                value = min;
            }
            if (value > max)
            {
                value = max;
            }
            return value;
        }

        public float ClampFloat(float  value, float min = 0, float max = 255)
        {
            if (value < min)
            {
                value = min;
            }
            if (value > max)
            {
                value = max;
            }
            return value;
        }


        protected void UnitTypeCreation(EUnitClass target)
        {
            switch (target)
            {
                case EUnitClass.Villager:
                    BaseAtkAdd = 0;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    break;
                case EUnitClass.Squire:
                    BaseAtkAdd = 2;
                    BaseDefAdd = 1;
                    BaseSpdAdd = 0;
                    break;
                case EUnitClass.Soldier:
                    BaseAtkAdd = 3;
                    BaseDefAdd = 2;
                    BaseSpdAdd = 1;
                    break;
                case EUnitClass.Ranger:
                    BaseAtkAdd = 1;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 3;
                    break;
                case EUnitClass.Mage:
                    BaseAtkAdd = 3;
                    BaseDefAdd = 1;
                    BaseSpdAdd = -1;
                    break;
                case EUnitClass.Imp:
                    BaseAtkAdd = 1;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    break;
                case EUnitClass.Orc:
                    BaseAtkAdd = 4;
                    BaseDefAdd = 2;
                    BaseSpdAdd = -2;
                    break;
                case EUnitClass.Dragon:
                    BaseAtkAdd = 5;
                    BaseDefAdd = 3;
                    BaseSpdAdd = 2;
                    break;
                default:
                    break;
            }

        }


    }
}