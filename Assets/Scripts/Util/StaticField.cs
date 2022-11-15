using System;
using System.Reflection;
using Unity.VisualScripting;

namespace Util {
    public class StaticField<T> {
        public FieldInfo FieldInfo { get; private set; }
        public T Value {
            get => Getter();
            set => Setter(value);
        }
        
        private readonly Func<T> Getter;
        private readonly Action<T> Setter;

        public StaticField(FieldInfo field) {
            FieldInfo = field;

            if (field.IsLiteral) {
                var constant = (T) FieldInfo.GetValue(null);
                Getter = () => constant;
            } else {
                Getter = () => (T) FieldInfo.GetValue(null);
                if (FieldInfo.CanWrite()) Setter = value => FieldInfo.SetValue(null, value);
            }
        }
    }
}