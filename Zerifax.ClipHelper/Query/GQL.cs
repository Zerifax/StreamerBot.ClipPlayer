using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Zerifax.ClipHelper.Query
{
    [Flags]
    public enum FormatFlags
    {
        None = 0,
        Name = 1,
        Value = 2,
        Split = 3
    }
    
    public class QueryGraph
    {
        public QueryEntity RootEntity { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            
            SerialiseEntity(sb, RootEntity, 1);
            
            sb.Append("}");
            return sb.ToString();
        }

        private void SerialiseEntity(StringBuilder sb, QueryEntity entity, int level)
        {
            sb.Append(string.Empty.PadLeft(level * 2, ' '));
                
            var format = string.IsNullOrWhiteSpace(entity.Name) ? FormatFlags.None : FormatFlags.Name;
            format |= string.IsNullOrWhiteSpace(entity.Value) ? FormatFlags.None : FormatFlags.Value;

            if (format.HasFlag(FormatFlags.Name))
            {
                sb.Append(entity.Name);
            }
            
            if (format.HasFlag(FormatFlags.Split))
            {
                sb.Append(": ");
            }
            
            if (format.HasFlag(FormatFlags.Value))
            {
                sb.Append(entity.Value);
            }

            if (entity.Attributes?.Count > 0)
            {
                sb.Append("(");
                sb.Append(string.Join(", ", entity.Attributes.Select(attr => $"{attr.Name}: {attr.GetValueString()}")));
                sb.Append(")");
            }

            if (entity.Entities?.Count > 0)
            {
                sb.AppendLine(" {");
                
                foreach (var child in entity.Entities)
                {
                    SerialiseEntity(sb, child, level + 1);
                }
                
                sb.Append("}".PadLeft(level * 2, ' '));
            }

            sb.AppendLine();
        }
    }

    public class QueryEntity
    {
        public string Name { get; set; }
        
        public string Value { get; set; }

        public List<QueryEntity> Entities { get; set; } = new List<QueryEntity>();

        public List<QueryAttribute> Attributes { get; set; } = new List<QueryAttribute>();

        public QueryEntity AddChild(string name, string value = null)
        {
            var entity = new QueryEntity() { Name = name, Value = value};
            Entities.Add(entity);
            return entity;
        }

        public void AddChildren(params string[] names)
        {
            foreach (var name in names)
            {
                var entity = new QueryEntity() {Name = name};
                Entities.Add(entity);
            }
        }

        public StringQueryAttribute AddAttribute(string name, string value)
        {
            var attribute = new StringQueryAttribute() {Name = name, Value = value};
            Attributes.Add(attribute);
            return attribute;
        }
        
        public NumericQueryAttribute AddAttribute(string name, int value)
        {
            var attribute = new NumericQueryAttribute() {Name = name, Value = value};
            Attributes.Add(attribute);
            return attribute;
        }
    }

    public abstract class QueryAttribute
    {
        public string Name { get; set; }

        public abstract string GetValueString();
    }

    public class StringQueryAttribute : QueryAttribute
    {
        public string Value { get; set; }
        
        public override string GetValueString()
        {
            return $"\"{Value}\"";
        }
    }
    
    public class NumericQueryAttribute : QueryAttribute
    {
        public int Value { get; set; }
        
        public override string GetValueString()
        {
            return Value.ToString();
        }
    }
}