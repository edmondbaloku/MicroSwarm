using Mss.Ast.Visitor;

namespace Mss.Ast
{
    public class MssSpecNode : MssNode
    {
        public string Filename { get; set; }

        public override void Accept(IMssAstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}