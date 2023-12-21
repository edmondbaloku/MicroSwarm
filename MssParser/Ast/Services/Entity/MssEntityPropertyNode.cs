using Irony.Ast;
using Irony.Parsing;
using Mss.Ast.Visitor;

namespace Mss.Ast
{
    public class MssEntityPropertyNode : MssNode
    {
        public string Identifier { get; set; } = "";
        public string Type { get; set; } = "";

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            const int EXPECTED_CHILD_COUNT = 2;
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

                if (Children[1] is MssEntityPropertyTypeNode type)
                {
                    Type = type.Type;
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
            AsString = "EntityPropertyNode: " + Identifier;
        }

        public override void Accept(IMssAstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}