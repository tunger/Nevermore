namespace Nevermore
{
    public class NullaryWhereParameter
    {
        public NullaryWhereParameter(string fieldName, NullarySqlOperand operand)
        {
            FieldName = fieldName;
            Operand = operand;
        }
        
        public string FieldName { get; }
        public NullarySqlOperand Operand { get; }
    }
}