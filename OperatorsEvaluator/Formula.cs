namespace OperatorsEvaluator;

public abstract class Formula
{
   /// <summary>
   /// Evaluates the formula assuming all variables have values true, false defined
   /// </summary>
   /// <returns>Returns the result of the formula after such assignment</returns>
   public abstract bool Evaluate();
   /// <summary>
   /// Finds every variable in a formula
   /// </summary>
   /// <returns>Returns an IEnumerable of variables</returns>
   public abstract IEnumerable<Variable> Variables();
   /// <summary>
   /// Finds every literal in a formula
   /// </summary>
   /// <returns>Returns an IEnumerable of literals</returns>
   public abstract IEnumerable<Formula> Literals();
   /// <summary>
   /// Transforms a formula into Negation Normal Form (NNF)
   /// </summary>
   /// <returns>Returns a new formuna in NNF</returns>
   public abstract Formula ToNnf();
   /// <summary>
   /// Transforms a formula into Conjunctive Normal Form (CNF)
   /// </summary>
   /// <returns>Returns a new formuna in CNF</returns>
   public abstract Formula ToCnf();

   /// <summary>
   /// Distributes a formula using Morgan's laws of propositional logic
   /// </summary>
   /// <param name="p"></param>
   /// <param name="q"></param>
   /// <returns>The formula distribuited</returns>
   public Formula DistributeCnf(Formula p, Formula q)
   {
      if (p is And)
         return new And(DistributeCnf((p as And).P, q), DistributeCnf((p as And).Q, q));
      if (q is And)
         return new And(DistributeCnf(p, (q as And).P), DistributeCnf(p, (q as And).Q));

      return new Or(p, q);
   }

}
