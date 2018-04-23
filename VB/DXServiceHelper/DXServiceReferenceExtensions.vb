Imports Microsoft.VisualBasic
Imports System
Namespace DXService
    Partial Public Class ViewProperty
        Public Sub New(ByVal fName As String, ByVal fProperty As CriteriaOperator, ByVal fSorting As SortDirection, ByVal fGroup As Boolean, ByVal fFetch As Boolean)
            Name = fName
            [Property] = fProperty
            Sorting = fSorting
            Group = fGroup
            Fetch = fFetch
        End Sub

        Public Sub New(ByVal fName As String, ByVal fProperty As CriteriaOperator, ByVal fSorting As SortDirection, ByVal fGroup As Boolean)
            Me.New(fName, fProperty, fSorting, fGroup, True)
        End Sub

        Public Sub New(ByVal fName As String, ByVal fProperty As CriteriaOperator, ByVal fSorting As SortDirection)
            Me.New(fName, fProperty, fSorting, False)
        End Sub

        Public Sub New(ByVal fName As String, ByVal fProperty As CriteriaOperator)
            Me.New(fName, fProperty, SortDirection.None)
        End Sub
    End Class

    Partial Public Class AggregateOperand
        Public Sub New(ByVal fCollectionProperty As OperandProperty, ByVal fCondition As CriteriaOperator, ByVal fAggregatedExpression As CriteriaOperator, ByVal fAggregateType As Aggregate)
            CollectionProperty = fCollectionProperty
            Condition = fCondition
            AggregatedExpression = fAggregatedExpression
            AggregateType = fAggregateType
        End Sub

        Public Sub New(ByVal fCollectionProperty As OperandProperty, ByVal fCondition As CriteriaOperator, ByVal fAggregatedExpression As CriteriaOperator)
            Me.New(fCollectionProperty, fCondition, fAggregatedExpression, Aggregate.Sum)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class BetweenOperator
        Public Sub New(ByVal fBeginExpression As CriteriaOperator, ByVal fEndExpression As CriteriaOperator, ByVal fTestExpression As CriteriaOperator)
            BeginExpression = fBeginExpression
            EndExpression = fEndExpression
            TestExpression = fTestExpression
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class BinaryOperator
        Public Sub New(ByVal fLeftOperand As CriteriaOperator, ByVal fRightOperand As CriteriaOperator, ByVal fOperatorType As BinaryOperatorType)
            LeftOperand = fLeftOperand
            RightOperand = fRightOperand
            OperatorType = fOperatorType
        End Sub

        Public Sub New(ByVal fLeftOperand As CriteriaOperator, ByVal fRightOperand As CriteriaOperator)
            Me.New(fLeftOperand, fRightOperand, BinaryOperatorType.Equal)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class FunctionOperator
        Public Sub New(ByVal fOperands() As CriteriaOperator, ByVal fOperatorType As FunctionOperatorType)
            Operands = fOperands
            OperatorType = fOperatorType
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class GroupOperator
        Public Sub New(ByVal fOperands() As CriteriaOperator, ByVal fOperatorType As GroupOperatorType)
            Operands = fOperands
            OperatorType = fOperatorType
        End Sub

        Public Sub New(ByVal fOperands() As CriteriaOperator)
            Me.New(fOperands, GroupOperatorType.And)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class InOperator
        Public Sub New(ByVal fLeftOperand As CriteriaOperator, ByVal fOperands() As CriteriaOperator)
            LeftOperand = fLeftOperand
            Operands = fOperands
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class JoinNode
        Public Sub New(ByVal fSubNodes() As JoinNode, ByVal fCondition As CriteriaOperator, ByVal fAlias As String, ByVal fType As JoinType, ByVal fTableName As String)
            SubNodes = fSubNodes
            Condition = fCondition
            [Alias] = fAlias
            Type = fType
            TableName = fTableName
        End Sub

        Public Sub New(ByVal fSubNodes() As JoinNode, ByVal fCondition As CriteriaOperator, ByVal fAlias As String, ByVal fTableName As String)
            Me.New(fSubNodes, fCondition, fAlias, JoinType.Inner, fTableName)
        End Sub
    End Class

    Partial Public Class OperandProperty
        Public Sub New(ByVal fPropertyName As String)
            PropertyName = fPropertyName
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class OperandValue
        Public Sub New(ByVal fItem As Object)
            Item = fItem
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class ParameterValue
        Public Sub New(ByVal fItem As Object, ByVal fTag As Integer)
            MyBase.New(fItem)
            Tag = fTag
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class QueryOperand
        Public Sub New(ByVal fColumnName As String, ByVal fColumnType As DBColumnType, ByVal fNodeAlias As String)
            ColumnName = fColumnName
            ColumnType = fColumnType
            NodeAlias = fNodeAlias
        End Sub

        Public Sub New(ByVal fColumnName As String, ByVal fNodeAlias As String)
            Me.New(fColumnName, DBColumnType.String, fNodeAlias)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class QuerySubQueryContainer
        Public Sub New(ByVal fNode As BaseStatement, ByVal fAggregateProperty As CriteriaOperator, ByVal fAggregateType As Aggregate)
            Node = fNode
            AggregateProperty = fAggregateProperty
            AggregateType = fAggregateType
        End Sub

        Public Sub New(ByVal fNode As BaseStatement, ByVal fAggregateProperty As CriteriaOperator)
            Me.New(fNode, fAggregateProperty, Aggregate.Sum)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

    Partial Public Class UnaryOperator
        Public Sub New(ByVal fOperand As CriteriaOperator, ByVal fOperatorType As UnaryOperatorType)
            Operand = fOperand
            OperatorType = fOperatorType
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class
End Namespace