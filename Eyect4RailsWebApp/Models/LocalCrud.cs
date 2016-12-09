using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eyect4rails.IRepository;
using Eyect4RailsWebApp.Interfaces;

namespace Eyect4RailsWebApp.Models
{
    public class LocalCrud<T>  where T: class,ICruddable
    {
        // TODO: Coen moet deze lijst Static zijn?
        public List<T> All = new List<T>();
        public int Counter = 0;

        /// <summary>
        /// Constructor used to Initialize a new CRUD class without containing a list of object with automatically added ID's
        /// </summary>
        /// <param name="all"></param>
        /// <param name="objectType"></param>
        public LocalCrud(List<T> all)
        {
            Init(all);
        }

        public LocalCrud()
        {

        }

        /// <summary>
        /// initialize the class by adding the given list of ICruddable to the Property 
        /// use the Insert method so the Id's are consistent
        /// </summary>
        private void Init(List<T> startItems)
        {
            foreach (T cruddable in startItems)
            {
                Insert(cruddable);
            }

        }
        /// <summary>
        /// Inserts object into a list and gives it an ID 
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(T item)
        {
            Counter++;
            item.Id = Counter;
            All.Add(item);
            return true;
        }
        /// <summary>
        /// Removes object from a list
        /// </summary>
        /// <param name="item">The item to be removed</param>
        public bool Delete(int id)
        {
            var toBeDeleted = All.Where(x => x.Id == id).FirstOrDefault();

            if (toBeDeleted != null)
            {
                All.Remove(toBeDeleted);
                return true;
            }
            return false;
        } 
        /// <summary>
        /// Updates an item in the list 
        /// </summary>
        /// <param name="id">id of the item that needs to be removed</param>
        /// <param name="item">object that needs to be replacing the old obejct</param>
        public bool Update(int id, T item)
        {
            All.RemoveAll(x => x.Id == id);
            item.Id = id;
            All.Add(item);

            return true;
        }

        /// <summary>
        /// Returns every object in the list 
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            List<T> returnObjects = new List<T>();
            foreach (T crudItem in All)
            {
                returnObjects.Add(crudItem);
            }

            return returnObjects;

        }
        /// <summary>
        /// Returns an object of any type by the id
        /// </summary>
        /// <param name="id">ID of the object that you want to retrieve</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            T returnValue = All.First(x => x.Id == id);

            return returnValue;
        }

    }
}