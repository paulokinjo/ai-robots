namespace OperatorsEvaluator;

public class And : BinaryGate
{

   public And(Formula p, Formula q) : base(p, q)
   { }

   public override bool Evaluate()
   {
      return P.Evaluate() && Q.Evaluate();
   }

   public override Formula ToNnf()
   {
      return new And(P.ToNnf(), Q.ToNnf());
   }

   public override Formula ToCnf()
   {
      return new And(P.ToCnf(), Q.ToCnf());
   }

   public override string ToString()
   {
      return "(" + P + " & " + Q + ")";
   }

}
