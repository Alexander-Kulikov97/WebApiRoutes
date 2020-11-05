﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiRoutes.Data.Repositories.Internals
{
    public interface IReadonlyRepository
    {
        /// <summary>
        ///     Finds an entity in the context by predicate expression.
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="predicate">The predicate expression to match elements</param>
        /// <returns>Matched entity or default value (null)</returns>
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        ///     Finds an entity in the context by Id.
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>Matched entity or default value (null)</returns>
        T Find<T>(int id) where T : class;

        /// <summary>
        ///     Returns all elements in the specified context class
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>List of the entities</returns>
        List<T> ToList<T>() where T : class;

        /// <summary>
        ///     Returns all elements in the specified context class
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>List of the entities</returns>
        IEnumerable<T> AsEnumerable<T>() where T : class;

        /// <summary>
        ///     Returns all elements in the specified context class
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>List of the entities</returns>
        IQueryable<T> AsQueryable<T>() where T : class;

        /// <summary>
        ///     Count all elements in the specified context class
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>Number of elements</returns>
        int Count<T>() where T : class;

        /// <summary>
        ///     Checks if entity exists in the context by predicate expression
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>Number of elements</returns>
        bool Exists<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T FirstOrDefault<T>() where T : class;

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        ///     Asynchronously finds an elements in the context by predicate expression.
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="predicate">The predicate expression to match elements</param>
        /// <returns>Matched entity or default value (null)</returns>
        Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        ///     Asynchronously finds an elements in the context by Id.
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <param name="id">The id of the entity</param>
        /// <returns>Matched entity or default value (null)</returns>
        Task<T> FindAsync<T>(int id) where T : class;

        /// <summary>
        ///     Asynchronous counts all elements in the specified context class
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>Number of elements</returns>
        Task<int> CountAsync<T>() where T : class;

        /// <summary>
        ///     Asynchronous checks if entity exists in the context by predicate expression
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>Number of elements</returns>
        Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        ///     Asynchronously returns all elements in the specified context class as List
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>List of the entities</returns>
        Task<List<T>> ToListAsync<T>() where T : class;

        /// <summary>
        ///     Asynchronously returns all elements in the specified context class as Enumerable
        /// </summary>
        /// <typeparam name="T">The class defined as a DbSet in DbContext</typeparam>
        /// <returns>List of the entities</returns>
        Task<IEnumerable<T>> AsEnumerableAsync<T>() where T : class;

        Task<T> FirstAsync<T>() where T : class;
    }
}
