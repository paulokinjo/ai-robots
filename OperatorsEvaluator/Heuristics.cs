namespace OperatorsEvaluator;

public class Heuristics
{
   public static Formula ChooseLiteral(Cnf cnf)
   {
      return cnf.Clauses.First().Literals.First();
   }
}
