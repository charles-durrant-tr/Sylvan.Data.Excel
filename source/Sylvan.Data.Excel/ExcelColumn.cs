﻿#nullable enable
using System.Data.Common;

namespace Sylvan.Data.Excel;

class ExcelColumn : DbColumn
{
	public ExcelColumn(string? name, int ordinal, DbColumn? schema = null)
	{
		// non-overridable
		this.ColumnOrdinal = ordinal;
		this.IsReadOnly = true;

		var colName = schema?.ColumnName;

		this.ColumnName = string.IsNullOrEmpty(colName) ? name ?? "" : colName;
		this.DataType = schema?.DataType ?? typeof(string);
		this.DataTypeName = schema?.DataTypeName ?? this.DataType.Name;

		// by default, we don't consider string types to be nullable,
		// an empty field for a string means "", not null.
		this.AllowDBNull = schema == null ? true : schema?.AllowDBNull;

		this.ColumnSize = schema?.ColumnSize ?? short.MaxValue; // Excel text limit

		this.IsUnique = schema?.IsUnique ?? false;
		this.IsLong = schema?.IsLong ?? false;
		this.IsKey = schema?.IsKey ?? false;
		this.IsIdentity = schema?.IsIdentity ?? false;
		this.IsHidden = schema?.IsHidden ?? false;
		this.IsExpression = schema?.IsExpression ?? false;
		this.IsAutoIncrement = schema?.IsAutoIncrement ?? false;
		this.NumericPrecision = schema?.NumericPrecision;
		this.NumericScale = schema?.NumericScale;
		this.IsAliased = schema?.IsAliased ?? false;
		this.BaseTableName = schema?.BaseTableName;
		this.BaseServerName = schema?.BaseServerName;
		this.BaseSchemaName = schema?.BaseSchemaName;
		this.BaseColumnName = schema?.BaseColumnName ?? name; // default in the orignal header name if they chose to remap it.
		this.BaseCatalogName = schema?.BaseCatalogName;
		this.UdtAssemblyQualifiedName = schema?.UdtAssemblyQualifiedName;
	}
}
