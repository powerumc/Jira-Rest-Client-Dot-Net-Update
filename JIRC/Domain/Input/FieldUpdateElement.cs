// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldUpdateElement.cs" company="David Bevin">
//   Copyright (c) 2013 David Bevin.
// </copyright>
// // <summary>
//   https://bitbucket.org/dpbevin/jira-rest-client-dot-net
//   Licensed under the BSD 2-Clause License.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace JIRC.Domain.Input
{
	public class FieldUpdateElement
	{
		public FieldUpdateElement(StandardOperation operation, object value)
		{
			this.Operation = operation;
			this.Value = value;
		}

		public StandardOperation Operation { get; private set; }

		public object Value { get; private set; }
	}
}
