namespace RecurlyNET.Infrastructure
{
    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// Nullable DateTime serilizable.
    /// </summary>
    public struct NullableDateTime : IXmlSerializable
    {
        #region Private Fields

        private bool _hasValue;
        private DateTime _value;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the current object has a value.
        /// </summary>
        public bool HasValue
        {
            get { return _hasValue; }
        }

        /// <summary>
        /// Gets the value of the current value.
        /// </summary>
        public DateTime Value
        {
            get
            {
                if (!HasValue) { throw new InvalidOperationException(); }

                return _value;
            }
        }

        #endregion Public Properties

        #region IXmlSerializable Implementation

        /// <summary>
        /// Gets XML schema.
        /// </summary>
        /// <returns>XML schema.</returns>
        public XmlSchema GetSchema()
        {
            var rootElement = new XmlSchemaElement
            {
                Name = "NullableDateTime",
                SchemaTypeName = new XmlQualifiedName("datetime"),
                IsNillable = true
            };

            // Create XML schema

            var xsd = new XmlSchema
            {
                Id = "NullableDateTime",
                ElementFormDefault = XmlSchemaForm.Qualified
            };

            xsd.Items.Add(rootElement);

            return xsd;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">XML Reader.</param>
        public void ReadXml(XmlReader reader)
        {
            string nilValue = reader["nil"];
            string elementValue = reader.IsEmptyElement ? null : reader.ReadElementString();

            if (nilValue == null || nilValue == "false" || nilValue == "0")
            {
                if (elementValue != null && elementValue != "0001-01-01T00:00:00.000Z")
                {
                    DateTime date = XmlConvert.ToDateTime(elementValue, XmlDateTimeSerializationMode.Local);

                    _value = date;
                    _hasValue = true;
                }
            }
            else
            {
                _hasValue = false;
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            if (_hasValue)
            {
                DateTime date = _value; date = date.ToUniversalTime();

                writer.WriteString(XmlConvert.ToString(date, "yyyy-MM-ddTHH:mms.fffffffZ"));
            }
            else
            {
                writer.WriteAttributeString(String.Empty, "nil", String.Empty, "true");
            }
        }

        #endregion IXmlSerializable Implementation

        #region Public Methods

        /// <summary>
        /// Creates a new object initialized to a specified value.
        /// </summary>
        public static implicit operator NullableDateTime(DateTime value)
        {
            return new NullableDateTime(value);
        }

        /// <summary>
        /// Returns the value of a specified value.
        /// </summary>
        public static explicit operator DateTime(NullableDateTime value)
        {
            return value.Value;
        }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        public override bool Equals(object other)
        {
            if (!HasValue) { return other == null; }

            return other != null && _value.Equals(other);
        }

        /// <summary>
        /// Retrieves the hash code of the object returned by the value property.
        /// </summary>
        public override int GetHashCode()
        {
            return !HasValue ? 0 : _value.GetHashCode();
        }

        /// <summary>
        /// Returns the text representation of the value of the current object.
        /// </summary>
        public override string ToString()
        {
            return !HasValue ? String.Empty : _value.ToString();
        }

        #endregion Public Methods

        #region Constructor

        private NullableDateTime(DateTime value)
        {
            _value = value;
            _hasValue = true;
        }

        #endregion Constructor
    }
}