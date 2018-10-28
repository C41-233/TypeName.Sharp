using System;
using System.Text;
using TypeName.Container;
using TypeName.Filter;

namespace TypeName
{
    public interface ITypeName : IFilterNamespaceElement
    {

        /// <summary>
        /// 此类所表示的Type
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// 命名空间
        /// </summary>
        Namespace Namespace { get; }

        /// <summary>
        /// 父类声明
        /// </summary>
        EnclosingNameList EnclosingNames { get; }

        /// <summary>
        /// 类型名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 泛型部分
        /// </summary>
        GenericList Generics { get; }

        /// <summary>
        /// 符号后缀（*、&、?），如果不存在该部分，则为null
        /// </summary>
        string Sign { get; }

        /// <summary>
        /// 数组后缀
        /// </summary>
        ArrayRankList ArrayRanks { get; }

        void ToString(StringBuilder sb);

    }
}
