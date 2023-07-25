using OperatorsEvaluator;

var p = new Variable(true) { Name = "p" };
var q = new Variable(true) { Name = "q" };
var r = new Variable(true) { Name = "r" };

var f1 = new And(new Or(p, q), new Or(p, new Not(q)));
var f2 = new And(new Or(new Not(p), q), new Or(new Not(p), new Not(r)));

var formula = new And(f1, f2);
var nnf = formula.ToNnf();
Console.WriteLine($"NNF: {nnf}");

nnf = nnf.ToCnf();
var cnf = new Cnf(nnf as And);
cnf.SimplifyCnf();
Console.WriteLine($"CNF: {cnf}");
Console.WriteLine($"SAT: {cnf.Dpll()}");


var f11 = new Or(p, new Or(q, new Not(r)));
var f21 = new Or(p, new Or(q, r));
var f31 = new Or(p, new Not(q));

var formula1 = new And(f11, new And(f21, new And(f31, new Not(p))));

var nnf1 = formula1.ToNnf();
Console.WriteLine($"NNF1: {nnf1}");

nnf1 = nnf1.ToCnf();
var cnf1 = new Cnf(nnf1 as And);
cnf1.SimplifyCnf();
Console.WriteLine($"CNF1: {cnf1}");
Console.WriteLine($"SAT1: {cnf1.Dpll()}");


var f111 = new Or(p, new Or(q, r));
var f211 = new Or(p, new Or(q, new Not(r)));
var f311 = new Or(p, new Or(new Not(q), r));
var f411 = new Or(p, new Or(new Not(q), new Not(r)));
var f511 = new Or(new Not(p), new Or (q, r));
var f611 = new Or(new Not(p), new Or(q, new Not(r)));
var f711 = new Or(new Not(p), new Or(new Not(q), r));

var formula2 = new And(f111, new And(f21, new And(f311, new And(f411, new And(f511, new And(f611, f711))))));

var nnf2 = formula2.ToNnf();
Console.WriteLine($"NNF2: {nnf2}");

nnf2 = nnf2.ToCnf();
var cnf2 = new Cnf(nnf2 as And);
cnf2.SimplifyCnf();
Console.WriteLine($"CNF2: {cnf2}");
Console.WriteLine($"SAT2: {cnf2.Dpll()}");
