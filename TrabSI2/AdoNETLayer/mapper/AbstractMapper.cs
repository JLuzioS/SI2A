using AdoNETLayer.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace AdoNETLayer.mapper
{
    #region ExtensionMethods
    public static class CollectionExtensions
    {
        public static void AddRange(this IDataParameterCollection collection, IEnumerable<IDataParameter> newItems)
        {
            foreach (IDataParameter item in newItems)
            {
                collection.Add(item);
            }
        }
    }
    #endregion

    abstract class AbstracMapper<T, Tid, TCol> : IMapper<T, Tid, TCol> where T : class, new() where TCol : IList<T>, IEnumerable<T>, new()
    {
        protected IContext context;
        #region Abstract Methods
        protected abstract T Map(IDataRecord record); //How to map entity
        protected abstract T UpdateEntityID(IDbCommand cmd, T e); //Update the generated ID
        protected abstract string SelectAllCommandText { get; }
        protected virtual CommandType SelectAllCommandType { get { return System.Data.CommandType.Text; } }
        protected virtual void SelectAllParameters(IDbCommand command) { }

        protected abstract string SelectCommandText { get; }
        protected virtual CommandType SelectCommandType { get { return System.Data.CommandType.Text; } }
        protected abstract void SelectParameters(IDbCommand command, Tid k);

        protected abstract string UpdateCommandText { get; }
        protected virtual CommandType UpdateCommandType { get { return System.Data.CommandType.Text; } }
        protected abstract void UpdateParameters(IDbCommand command, T e);

        protected abstract string DeleteCommandText { get; }
        protected virtual CommandType DeleteCommandType { get { return System.Data.CommandType.Text; } }
        protected abstract void DeleteParameters(IDbCommand command, T e);

        protected abstract string InsertCommandText { get; }
        protected virtual CommandType InsertCommandType { get { return System.Data.CommandType.Text; } }
        protected abstract void InsertParameters(IDbCommand command, T e);

        #endregion


        protected TCol MapAll(IDataReader reader)
        {
            TCol collection = new TCol();
            while (reader.Read())
            {
                try
                {
                    collection.Add(Map(reader));
                }
                catch
                {
                    throw;
                }

            }
            return collection;
        }

        #region Helper Methods
        protected void EnsureContext()
        {
            if (context == null)
                throw new InvalidOperationException("Data Context not set.");
        }
        protected IDataReader ExecuteReader(String commandText, List<IDataParameter> parameters)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IDbCommand cmd = context.createCommand())
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    cmd.CommandText = commandText;
                    var reader = cmd.ExecuteReader(CommandBehavior.Default);
                    ts.Complete();
                    return reader;
                }
            }
        }
        protected void ExecuteNonQuery(String commandText, List<IDataParameter> parameters)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                using (IDbCommand cmd = context.createCommand())
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    cmd.CommandText = commandText;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    ts.Complete();
                }
            }
        }

        #endregion
        public AbstracMapper(IContext ctx)
        {
            context = ctx;
        }
        #region IMapper implementation
        public virtual T Create(T entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = InsertCommandText;
                    cmd.CommandType = InsertCommandType;
                    InsertParameters(cmd, entity);
                    cmd.ExecuteNonQuery();
                    T ent = UpdateEntityID(cmd, entity);
                    cmd.Parameters.Clear();
                    ts.Complete();
                    return ent;
                }
            }
        }

        public virtual T Delete(T entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                if (entity == null)
                    throw new ArgumentException("The " + typeof(T) + " to delete cannot be null");

                EnsureContext();

                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = DeleteCommandText;
                    cmd.CommandType = DeleteCommandType;
                    DeleteParameters(cmd, entity);
                    int result = cmd.ExecuteNonQuery();
                    ts.Complete();
                    return (result == 0) ? null : entity;
                }
            }
        }

        public virtual T Read(Tid id)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = SelectCommandText;
                    cmd.CommandType = SelectCommandType;
                    SelectParameters(cmd, id);
                    using (IDataReader reader = cmd.ExecuteReader()) { 
                        var res = reader.Read() ? Map(reader) : null;
                        ts.Complete();
                        return res;
                    }
                }
            }
        }

        public virtual TCol ReadAll()
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                EnsureContext();
                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = SelectAllCommandText;
                    cmd.CommandType = SelectAllCommandType;
                    SelectAllParameters(cmd);
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        var res = MapAll(reader);
                        ts.Complete();
                        return res;
                    }
                }
            }
        }

        public virtual T Update(T entity)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                if (entity == null)
                    throw new ArgumentException("The " + typeof(T) + " to update cannot be null");

                EnsureContext();

                using (IDbCommand cmd = context.createCommand())
                {
                    cmd.CommandText = UpdateCommandText;
                    cmd.CommandType = UpdateCommandType;
                    UpdateParameters(cmd, entity);
                    int result = cmd.ExecuteNonQuery();
                    var res = (result == 0) ? null : entity;
                    ts.Complete();
                    return res;
                }
            }
        }
        #endregion
    }
}
