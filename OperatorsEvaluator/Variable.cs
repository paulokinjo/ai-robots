namespace OperatorsEvaluator;

using System.Collections.Generic;

public class Variable : Formula
{
   public bool Value { get; set; }
   public string Name { get; set; }

   public Variable(bool value)
   {
      Value = value;
   }

   public override bool Evaluate()
   {
      return Value;
   }

   public override IEnumerable<Variable> Variables()
   {
      return new List<Variable> { this };
   }

   public override Formula ToNnf()
   {
      return this;
   }

   public override Formula ToCnf()
   {
      return this;
   }

   public override IEnumerable<Formula> Literals()
   {
      return new List<Formula> { this };
   }

   public override string ToString()
   {
      return Name;
   }
}
