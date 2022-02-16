using System;
using System.Reflection;

namespace ZendeskSell.Utils {
    static class ClassCopier {
        public static void Copy<T>(T source, T target) where T : class {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            foreach (PropertyInfo prop in typeof(T).GetProperties()) {
                prop.SetValue(target, prop.GetValue(source));
            }
        }
    }
}
