namespace Canducci.Simply.SqlBuilder
{
    //internal class CreateParameters
    //{
    //    private static CreateParameters _instance;
    //    internal static CreateParameters Instance
    //    {
    //       get
    //        {
    //            if (_instance == null)
    //                _instance = new CreateParameters();
    //            return _instance;
    //        }
    //    }

    //    internal object TypeWithValues(IDictionary<string, object> parameters)
    //    {
    //        object p = Activator.CreateInstance(CreateType(parameters));
    //        foreach (FieldInfo info in p.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetField | BindingFlags.GetField))
    //        {
    //            info.SetValue(p, parameters[$"@{info.Name}"]);
    //        }
    //        return p;
    //    }
    //    private Type CreateType(IDictionary<string, object> parameters)
    //    {           
    //        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("ConsoleApp33.Builder"), AssemblyBuilderAccess.RunAndCollect);
    //        ModuleBuilder ModuleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
    //        TypeAttributes config = TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout;
    //        TypeBuilder typeBuilder = ModuleBuilder.DefineType(Guid.NewGuid().ToString(), config, null);
    //        typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
    //        foreach (KeyValuePair<string, object> parameter in parameters)
    //        {
    //            FieldBuilder fieldBuilder = typeBuilder.DefineField(parameter.Key.Replace("@", ""), parameter.Value == null ? typeof(DateTime?) : parameter.Value.GetType(), FieldAttributes.Public);
    //            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(parameter.Key.Replace("@", ""), PropertyAttributes.HasDefault, parameter.Value == null ? typeof(DateTime?) : parameter.Value.GetType(), null);
    //            propertyBuilder.SetSetMethod(DefineSet(typeBuilder, fieldBuilder, propertyBuilder));
    //            propertyBuilder.SetGetMethod(DefineGet(typeBuilder, fieldBuilder, propertyBuilder));
    //        }
    //        return typeBuilder.CreateTypeInfo().AsType();
    //    }
    //    private MethodBuilder DefineSet(TypeBuilder typeBuilder, FieldBuilder fieldBuilder, PropertyBuilder propBuilder)
    //        => DefineMethod(typeBuilder, $"set_{propBuilder.Name}", null, new[] { propBuilder.PropertyType }, il =>
    //        {
    //            il.Emit(OpCodes.Ldarg_0);
    //            il.Emit(OpCodes.Ldarg_1);
    //            il.Emit(OpCodes.Stfld, fieldBuilder);
    //            il.Emit(OpCodes.Ret);
    //        });

    //    private MethodBuilder DefineGet(TypeBuilder typeBuilder, FieldBuilder fieldBuilder, PropertyBuilder propBuilder)
    //        => DefineMethod(typeBuilder, $"get_{propBuilder.Name}", propBuilder.PropertyType, Type.EmptyTypes, il =>
    //        {
    //            il.Emit(OpCodes.Ldarg_0);
    //            il.Emit(OpCodes.Ldfld, fieldBuilder);
    //            il.Emit(OpCodes.Ret);
    //        });

    //    private MethodBuilder DefineMethod(TypeBuilder typeBuilder, string methodName, Type propertyType, Type[] parameterTypes, Action<ILGenerator> bodyWriter)
    //    {
    //        var config = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
    //        var methodBuilder = typeBuilder.DefineMethod(methodName, config, propertyType, parameterTypes);
    //        bodyWriter(methodBuilder.GetILGenerator());
    //        return methodBuilder;
    //    }
    //}
}
