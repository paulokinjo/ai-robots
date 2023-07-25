using OperatorsEvaluator;

var p = new Variable(false);
var q = new Variable(false);

var formula = new Or(p, new Not(q));
Console.WriteLine(formula.Evaluate());

BinaryDecisionTree.FromFormula(formula);
