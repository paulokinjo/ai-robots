namespace OperatorsEvaluator;

public class Not : Formula
{
   public Formula P { get; set; }

   public Not(Formula p)
   {
      P = p;
   }

   public override bool Evaluate()
   {
      return !P.Evaluate();
   }

   public override IEnumerable<Variable> Variables()
   {
      return new List<Variable>(P.Variables());
   }

   public override Formula ToNnf()
   {
      if (P is And)
         return new Or(new Not((P as And).P).ToNnf(), new Not((P as And).Q).ToNnf());
      if (P is Or)
         return new And(new Not((P as Or).P).ToNnf(), new Not((P as Or).Q).ToNnf());
      if (P is Not)
         return (P as Not).P.ToNnf();

      return this;
   }

   public override Formula ToCnf()
   {
      return this;
   }

   public override IEnumerable<Formula> Literals()
   {
      return P is Variable ? new List<Formula>() { this } : P.Literals();
   }

   public override string ToString()
   {
      return "!" + P;
   }
}
