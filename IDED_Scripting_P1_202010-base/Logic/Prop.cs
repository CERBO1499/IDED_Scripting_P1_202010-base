namespace IDED_Scripting_P1_202010_base.Logic
{
    public struct Prop
    {

        private EPropType propType;

        public EPropType PropType { get=>propType; private set=>propType=value; }

        public Prop(EPropType _propType)
        {
            propType = _propType;
        }
    }
}