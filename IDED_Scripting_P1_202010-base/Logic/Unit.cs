namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; }
        public float Defense { get; }
        public float Speed { get; }

        protected Position CurrentPosition;

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;
        }
        public void modificarBases()
        {

        }
        public virtual bool Interact(Unit otherUnit)
        {

            if (UnitClass==EUnitClass.Villager)
            {
                goto CantAtackO;
            }

            else if (UnitClass==EUnitClass.Squire && otherUnit.UnitClass!=EUnitClass.Villager)
            {
                goto CanAtackO;
            }
            else if (UnitClass == EUnitClass.Soldier && otherUnit.UnitClass != EUnitClass.Villager)
            {
                goto CanAtackO;
            }
            else if (UnitClass == EUnitClass.Ranger && otherUnit.UnitClass != EUnitClass.Mage || otherUnit.UnitClass != EUnitClass.Dragon )
            {
                goto CanAtackO;
            }
            else if (UnitClass == EUnitClass.Mage && otherUnit.UnitClass != EUnitClass.Mage )
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

        public bool Move(Position targetPosition) => false;

        
            

            
        
    }
}