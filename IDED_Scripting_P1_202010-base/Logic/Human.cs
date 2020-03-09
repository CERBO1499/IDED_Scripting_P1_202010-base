namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential;
            switch (_unitClass)
            {
                case EUnitClass.Imp:
                case EUnitClass.Dragon:
                case EUnitClass.Orc:
                    _unitClass = EUnitClass.Villager;
                    UnitTypeCreation(_unitClass);
                    break;
                default:
                    break;
            }
        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            bool ret = false;

            switch (UnitClass)
            {
                case EUnitClass.Villager:
                    switch (newClass)
                    {
                        default:
                            break;
                    }
                    break;
                case EUnitClass.Squire:
                    switch (newClass)
                    {
                        case EUnitClass.Soldier:
                            goto Realizado;
                        default:
                            break;
                       
                    }
                    break;
                case EUnitClass.Soldier:
                    switch (newClass)
                    {
                        case EUnitClass.Squire:
                            goto Realizado;
                        default:
                            break;

                    }
                    break;
                case EUnitClass.Ranger:
                    switch (newClass)
                    {
                        case EUnitClass.Mage:
                            goto Realizado;
                        default:
                            break;

                    }
                    break;
                case EUnitClass.Mage:
                    switch (newClass)
                    {
                        case EUnitClass.Ranger:
                            goto Realizado;
                        default:
                            break;

                    }
                    break;
                case EUnitClass.Imp:
                    switch (newClass)
                    {
                        default:
                            break;
                    }
                    break;
                case EUnitClass.Orc:
                    switch (newClass)
                    {
                        default:
                            break;
                    }
                    break;
                case EUnitClass.Dragon:
                    switch (newClass)
                    {
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }







            Realizado:
            UnitTypeCreation(newClass);
            ret = true;
            
            return ret;



        }

        public override float Attack => base.ClampFloat((float)BaseAtk*(1+BaseAtkAdd+Potential));
        public override float Defense => base.ClampFloat((float)BaseDef* (1 +BaseDefAdd + Potential));
        public override float Speed => base.ClampFloat((float)BaseSpd * (1 + BaseSpdAdd + Potential));


    }
}