namespace OperatorsEvaluator;

public class BinaryDecisionTree
{
   private BinaryDecisionTree leftChild;
   private BinaryDecisionTree rightChild;
   private int value;

   public BinaryDecisionTree()
   {

   }

   public BinaryDecisionTree(int value) => this.value = value;

   public BinaryDecisionTree(
      int value,
      BinaryDecisionTree leftChild,
      BinaryDecisionTree rightChild)
      : this(value)
   {
      this.leftChild = leftChild;
      this.rightChild = rightChild;
   }

   public static BinaryDecisionTree FromFormula(Formula formula) =>
      TreeBuilder(formula, formula.Variables(), 0, string.Empty);

   private static BinaryDecisionTree TreeBuilder(
      Formula formula,
      IEnumerable<Variable> variables,
      int index,
      string path)
   {
      if (!string.IsNullOrEmpty(path))
      {
         variables.ElementAt(index - 1).Value = path[path.Length - 1] != '0';
      }

      if (index == variables.Count())
      {
         Console.WriteLine($"Returning: {formula.Evaluate()}");
         return new BinaryDecisionTree(formula.Evaluate() ? 1 : 0);
      }

      return new BinaryDecisionTree(
         index,
         TreeBuilder(formula, variables, index + 1, path + "0"),
         TreeBuilder(formula, variables, index + 1, path + "1"));
   }
}
