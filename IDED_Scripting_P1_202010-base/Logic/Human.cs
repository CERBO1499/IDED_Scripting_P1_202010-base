namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential;
        }





        public virtual bool ChangeClass(EUnitClass newClass)
        {


            if (newClass == UnitClass)
            {
                goto CantChange;
            }

            else if (UnitClass == EUnitClass.Villager)
            {
                goto CantChange;
            }
            else if (UnitClass == EUnitClass.Soldier && newClass == EUnitClass.Squire)
            {
                goto CanChange;
            }
            
            else if (UnitClass == EUnitClass.Squire && newClass == EUnitClass.Soldier)
            {
                goto CanChange;
            }
            else if (UnitClass == EUnitClass.Mage && newClass == EUnitClass.Ranger)
            {
                goto CanChange;
            }

            else if (UnitClass == EUnitClass.Ranger && newClass == EUnitClass.Mage)
            {
                goto CanChange;
            }
            else
            {
                goto CantChange;
            }



        CanChange:
            return true;
        CantChange:
            return false;
        }
    }
}