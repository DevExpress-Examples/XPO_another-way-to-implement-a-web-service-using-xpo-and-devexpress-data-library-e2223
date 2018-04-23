namespace DXServiceHelper.DXService {
    public partial class ViewProperty {
        public ViewProperty (string fName, CriteriaOperator fProperty, SortDirection fSorting, bool fGroup,
            bool fFetch) {
            Name = fName;
            Property = fProperty;
            Sorting = fSorting;
            Group = fGroup;
            Fetch = fFetch;
        }

        public ViewProperty (string fName, CriteriaOperator fProperty, SortDirection fSorting, bool fGroup)
            : this(fName, fProperty, fSorting, fGroup, true) { }

        public ViewProperty (string fName, CriteriaOperator fProperty, SortDirection fSorting)
            : this(fName, fProperty, fSorting, false) { }

        public ViewProperty (string fName, CriteriaOperator fProperty) : this(fName, fProperty, SortDirection.None) { }
    }

    public partial class AggregateOperand {
        public AggregateOperand (OperandProperty fCollectionProperty, CriteriaOperator fCondition,
            CriteriaOperator fAggregatedExpression, Aggregate fAggregateType) {
            CollectionProperty = fCollectionProperty;
            Condition = fCondition;
            AggregatedExpression = fAggregatedExpression;
            AggregateType = fAggregateType;
        }

        public AggregateOperand (OperandProperty fCollectionProperty, CriteriaOperator fCondition,
            CriteriaOperator fAggregatedExpression)
            : this(fCollectionProperty, fCondition, fAggregatedExpression, Aggregate.Sum) { }

        public AggregateOperand () : base() { }
    }

    public partial class BetweenOperator {
        public BetweenOperator (CriteriaOperator fBeginExpression, CriteriaOperator fEndExpression,
            CriteriaOperator fTestExpression) {
            BeginExpression = fBeginExpression;
            EndExpression = fEndExpression;
            TestExpression = fTestExpression;
        }

        public BetweenOperator () : base() { }
    }

    public partial class BinaryOperator {
        public BinaryOperator (CriteriaOperator fLeftOperand, CriteriaOperator fRightOperand,
            BinaryOperatorType fOperatorType) {
            LeftOperand = fLeftOperand;
            RightOperand = fRightOperand;
            OperatorType = fOperatorType;
        }

        public BinaryOperator (CriteriaOperator fLeftOperand, CriteriaOperator fRightOperand)
            : this(fLeftOperand, fRightOperand, BinaryOperatorType.Equal) { }

        public BinaryOperator () : base() { }
    }

    public partial class FunctionOperator {
        public FunctionOperator (CriteriaOperator[] fOperands, FunctionOperatorType fOperatorType) {
            Operands = fOperands;
            OperatorType = fOperatorType;
        }

        public FunctionOperator () : base() { }
    }

    public partial class GroupOperator {
        public GroupOperator (CriteriaOperator[] fOperands, GroupOperatorType fOperatorType) {
            Operands = fOperands;
            OperatorType = fOperatorType;
        }

        public GroupOperator (CriteriaOperator[] fOperands) : this(fOperands, GroupOperatorType.And) { }

        public GroupOperator () : base() { }
    }

    public partial class InOperator {
        public InOperator (CriteriaOperator fLeftOperand, CriteriaOperator[] fOperands) {
            LeftOperand = fLeftOperand;
            Operands = fOperands;
        }

        public InOperator () : base() { }
    }

    public partial class JoinNode {
        public JoinNode (JoinNode[] fSubNodes, CriteriaOperator fCondition, string fAlias, JoinType fType,
            string fTableName) {
            SubNodes = fSubNodes;
            Condition = fCondition;
            Alias = fAlias;
            Type = fType;
            TableName = fTableName;
        }

        public JoinNode (JoinNode[] fSubNodes, CriteriaOperator fCondition, string fAlias, string fTableName)
            : this(fSubNodes, fCondition, fAlias, JoinType.Inner, fTableName) { }
    }

    public partial class JoinOperand {
        public JoinOperand (CriteriaOperator fCondition, string fJoinTypeName, CriteriaOperator fAggregatedExpression,
            Aggregate fAggregateType) {
            Condition = fCondition;
            JoinTypeName = fJoinTypeName;
            AggregatedExpression = fAggregatedExpression;
            AggregateType = fAggregateType;
        }

        public JoinOperand (CriteriaOperator fCondition, string fJoinTypeName,
            CriteriaOperator fAggregatedExpression)
            : this(fCondition, fJoinTypeName, fAggregatedExpression, Aggregate.Sum) { }

        public JoinOperand () : base() { }
    }

    public partial class OperandProperty {
        public OperandProperty (string fPropertyName) { PropertyName = fPropertyName; }

        public OperandProperty () : base() { }
    }

    public partial class OperandValue {
        public OperandValue (object fItem) { Item = fItem; }

        public OperandValue () : base() { }
    }

    public partial class ParameterValue {
        public ParameterValue (object fItem, int fTag) : base(fItem) { Tag = fTag; }

        public ParameterValue () : base() { }
    }

    public partial class QueryOperand {
        public QueryOperand (string fColumnName, DBColumnType fColumnType, string fNodeAlias) {
            ColumnName = fColumnName;
            ColumnType = fColumnType;
            NodeAlias = fNodeAlias;
        }

        public QueryOperand (string fColumnName, string fNodeAlias)
            : this(fColumnName, DBColumnType.String, fNodeAlias) { }

        public QueryOperand () : base() { }
    }

    public partial class QuerySubQueryContainer {
        public QuerySubQueryContainer (BaseStatement fNode, CriteriaOperator fAggregateProperty,
            Aggregate fAggregateType) {
            Node = fNode;
            AggregateProperty = fAggregateProperty;
            AggregateType = fAggregateType;
        }

        public QuerySubQueryContainer (BaseStatement fNode, CriteriaOperator fAggregateProperty)
            : this(fNode, fAggregateProperty, Aggregate.Sum) { }

        public QuerySubQueryContainer () : base() { }
    }

    public partial class UnaryOperator {
        public UnaryOperator (CriteriaOperator fOperand, UnaryOperatorType fOperatorType) {
            Operand = fOperand;
            OperatorType = fOperatorType;
        }

        public UnaryOperator () : base() { }
    }
}