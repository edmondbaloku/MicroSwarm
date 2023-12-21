using Irony.Ast;
using Irony.Parsing;
using Mss.Ast.Visitor;

namespace Mss.Ast
{
    public class MssServiceNode : MssNode
    {
        public string Identifier { get; set; } = "";
        public MssDatabaseNode Database { get; set; } = null!;
        public MssAggregateNode Aggregate { get; set; } = null!;

        public override void Accept(IMssAstVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            const int EXPECTED_CHILD_COUNT = 3;
            if (Children.Count == EXPECTED_CHILD_COUNT)
            {
                if (Children[0] is MssIdentifierNode identifier)
                {
                    Identifier = identifier.Identifier;
                }
                else
                {
                    throw new InvalidChildTypeException();
                }

                if (Children[1] is MssDatabaseNode db)
                {
                    Database = db;
                }
                else
                {
                    throw new InvalidChildTypeException();
                }

                if (Children[2] is MssAggregateNode agg)
                {
                    Aggregate = agg;
                }
                else
                {
                    throw new InvalidChildTypeException();
                }
            }
            else
            {
                throw new InvalidChildCountException(EXPECTED_CHILD_COUNT, Children.Count);
            }
            AsString = "Service: " + Identifier;
        }
    }
}