namespace OperatorsEvaluator;

public abstract class BinaryGate : Formula
{
   public Formula P { get; set; }
   public Formula Q { get; set; }

   protected BinaryGate(Formula p, Formula q)
   {
      P = p;
      Q = q;
   }

   public override IEnumerable<Variable> Variables()
   {
      return P.Variables().Concat(Q.Variables());
   }

   public override IEnumerable<Formula> Literals()
   {
      return P.Literals().Concat(Q.Literals());
   }
}
