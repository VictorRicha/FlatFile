namespace FlatFile.FixedLength.Implementation
{
    using System;
    using System.Linq.Expressions;
    using FlatFile.Core;
    using FlatFile.Core.Base;

    public class FixedLayout<TTarget> :
        LayoutBase<TTarget, FixedFieldSettings, IFixedFieldSettingsConstructor, FixedLayout<TTarget>>,
        IFixedLayout<TTarget, FixedLayout<TTarget>>,
        IFixedLayout<TTarget>
    {
        public FixedLayout()
            : this(
                new FixedFieldSettingsFactory(), new FixedFieldSettingsBuilder(),
                new FieldsContainer<FixedFieldSettings>())
        {
        }

        public FixedLayout(
            IFieldSettingsFactory<FixedFieldSettings, IFixedFieldSettingsConstructor> fieldSettingsFactory,
            IFieldSettingsBuilder<FixedFieldSettings, IFixedFieldSettingsConstructor> builder,
            IFieldsContainer<FixedFieldSettings> fieldsContainer)
            : base(fieldSettingsFactory, builder, fieldsContainer)
        {
        }

        public override FixedLayout<TTarget> WithMember<TProperty>(
            Expression<Func<TTarget, TProperty>> expression,
            Action<IFixedFieldSettingsConstructor> settings)
        {
            ProcessProperty(expression, settings);

            return this;
        }

        protected virtual void MapLayout()
        {
        }

        IFixedLayout<TTarget>
            ILayout<TTarget, FixedFieldSettings, IFixedFieldSettingsConstructor, IFixedLayout<TTarget>>.WithMember
            <TProperty>(Expression<Func<TTarget, TProperty>> expression, Action<IFixedFieldSettingsConstructor> settings)
        {
            return WithMember(expression, settings);
        }
    }
}