namespace OperatorsEvaluator;

public class Clause
{
   public List<Formula> Literals { get; set; }

   public Clause()
   {
      Literals = new List<Formula>();
   }

   /// <summary>
   /// Determines whether this clause contains a given literal
   /// </summary>
   /// <param name="literal"></param>
   /// <returns>True if it contains literal; false otherwise</returns>
   public bool Contains(Formula literal)
   {
      if (!IsLiteral(literal))
         throw new ArgumentException("Specified formula is not a literal");

      foreach (var formula in Literals)
      {
         if (LiteralEquals(formula, literal))
            return true;
      }

      return false;
   }

   /// <summary>
   /// Removes a literal from this clause.
   /// </summary>
   /// <param name="literal"></param>
   /// <returns>Returns a new clause with the given literal removed</returns>
   public Clause RemoveLiteral(Formula literal)
   {
      if (!IsLiteral(literal))
         throw new ArgumentException("Specified formula is not a literal");

      var result = new Clause();

      for (var i = 0; i < Literals.Count; i++)
      {
         if (!LiteralEquals(literal, Literals[i]))
            result.Literals.Add(Literals[i]);
      }

      return result;
   }

   /// <summary>
   /// Determines whether literals p, q are equal
   /// </summary>
   /// <param name="p"></param>
   /// <param name="q"></param>
   /// <returns>True if p and q are equal; false otherwise</returns>
   public bool LiteralEquals(Formula p, Formula q)
   {
      if (p is Variable && q is Variable)
         return (p as Variable).Name == (q as Variable).Name;
      if (p is Not && q is Not)
         return LiteralEquals((p as Not).P, (q as Not).P);

      return false;
   }

   public bool IsLiteral(Formula p)
   {
      return p is Variable || (p is Not && (p as Not).P is Variable);
   }
}
