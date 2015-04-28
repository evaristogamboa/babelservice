using System;
using System.Xml;
using System.Collections.Generic;
using System.Reflection;

namespace Nubise.Hc.Utils.I18n.Babel.Dominio.Comunes
{
	public abstract class Entity<T> : IEquatable<T> where T: Entity<T>
	{
		public Guid id { get; protected set; }

		public override bool Equals (object obj)
		{
			if (obj == null)
				return false;
			T other = obj as T;
			return Equals (other);

		}



		public override int GetHashCode ()
		{

			IEnumerable<FieldInfo> fields = GetFields ();

			int startValue = 17;
			int multiplier = 59;
			int hashCode = startValue;

			foreach (FieldInfo field in fields) {

				object value = field.GetValue (this);

				if (value != null)
					hashCode = hashCode * multiplier + value.GetHashCode ();
			}
			return hashCode;
		}



		public virtual bool Equals (T other)
		{

			if (ReferenceEquals (null, other)) {
				return false;
			}
			if (ReferenceEquals (this, other)) {
				return true;
			}
			return Equals (this.id, other.id);

		}

		public static bool operator == (Entity<T> x, Entity<T> y)
		{

			return x.Equals (y);

		}

		public static bool operator != (Entity<T> x, Entity<T> y)
		{

			return !(x == y);

		}

		private IEnumerable<FieldInfo> GetFields ()
		{
			Type t = GetType ();
			List<FieldInfo> fields = new List<FieldInfo> ();
			while (t != typeof(object)) {

				fields.AddRange (t.GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
				t = t.BaseType;
			}
			return fields;
		}
	}
}

