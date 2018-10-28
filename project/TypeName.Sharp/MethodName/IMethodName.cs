using System.Reflection;
using System.Text;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    public interface IMethodName : IFilterNamespaceElement
    {
        /// <summary>
        /// 该类代表的Method
        /// </summary>
        MethodInfo Method { get; }

        /// <summary>
        /// 返回类型
        /// </summary>
        ITypeName ReturnType { get; }

        /// <summary>
        /// 显式接口实现声明，如果不存在则为null
        /// </summary>
        ITypeName ExplicitInterface { get; }

        /// <summary>
        /// 函数名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 泛型参数
        /// </summary>
        GenericList Generics { get; }

        /// <summary>
        /// 参数列表
        /// </summary>
        ParameterList Parameters { get; }

        void ToString(StringBuilder sb);
    }
}
