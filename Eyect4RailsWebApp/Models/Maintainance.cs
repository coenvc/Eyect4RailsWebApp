using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eyect4rails.Classes
{
    public class Task
    {
        #region Properties coming from Task
        public int TaskId { get; set; }
        public string Name { get; private set; }
        public string Function { get; private set; }
        #endregion
        #region Properties coming from TaskExecution 
        public int TaskExecutionId { get; private set; }
        public Tram Tram { get; private set; }
        public Employee Employee { get; private set; }

        public string Comment { get; private set; }
        public DateTime TaskAdded { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime Finish { get; set; }

        public int Severity { get; private set; }
        public int Priority { get; private set; }
        #endregion

        /// <summary>
        /// Task constructor including ID for both Task and TaskExecution, but without a Finish DateTime
        /// </summary>
        public Task(int taskid, int taskexecutionid, string name, string function, Tram tram, Employee employee, string comment, DateTime taskadded, DateTime start, int severity, int priority)
        {
            TaskId = taskid;
            TaskExecutionId = taskexecutionid;
            Name = name;
            Function = function;
            Tram = tram;
            Employee = employee;
            Comment = comment;
            TaskAdded = taskadded;
            Start = start;
            SetSeverity(severity);
            Priority = priority;
        }

        /// <summary>
        /// Task constructor including ID for both Task and TaskExecution and a Finish DateTime
        /// </summary>
        public Task(int taskid, int taskexecutionid, string name, string function, Tram tram, Employee employee, string comment, DateTime taskadded, DateTime start, DateTime finish, int severity, int priority)
        {
            TaskId = taskid;
            TaskExecutionId = taskexecutionid;
            Name = name;
            Function = function;
            Tram = tram;
            Employee = employee;
            Comment = comment;
            TaskAdded = taskadded;
            Start = start;
            SetFinish(finish);
            SetSeverity(severity);
            Priority = priority;
        }

        /// <summary>
        /// Task constructor which doesn't need an ID or a Finish DateTime
        /// </summary>
        public Task(string name, string function, Tram tram, Employee employee, string comment, DateTime taskadded, DateTime start, int severity, int priority)
        {
            Name = name;
            Function = function;
            Tram = tram;
            Employee = employee;
            Comment = comment;
            TaskAdded = taskadded;
            Start = start;
            SetSeverity(severity);
            Priority = priority;
        }

        /// <summary>
        /// Task constructor which doesn't need an ID but needs a Finish DateTime
        /// </summary>
        public Task(string name, string function, Tram tram, Employee employee, string comment, DateTime taskadded, DateTime start, DateTime finish, int severity, int priority)
        {
            Name = name;
            Function = function;
            Tram = tram;
            Employee = employee;
            Comment = comment;
            TaskAdded = taskadded;
            Start = start;
            SetFinish(finish);
            SetSeverity(severity);
            Priority = priority;
        }
        /// <summary>
        /// Construtor so the conductor can insert a new Task
        /// </summary>
        /// <param name="function"></param>
        /// <param name="tram"></param>
        /// <param name="taskAdded"></param>
        public Task(string function, Tram tram, DateTime taskAdded,int taskId)
        {
            Function = function;
            Tram = tram;
            TaskAdded = taskAdded;
            TaskId = taskId;
            Severity = 0;
            Priority = 0;
        }

        public Task(string function, Tram tram, DateTime taskAdded, int taskId,Employee assignedEmployee,DateTime start,int severity, int priority)
        {
            Function = function;
            Tram = tram;
            TaskAdded = taskAdded;
            TaskId = taskId;
            Employee = assignedEmployee;
            Start = start;
            Severity = severity;
            Priority = priority;
        }

        /// <summary>
        /// This method checks if the Finish is later than the Start datetime. If it's not, it's not added to the object.
        /// </summary>
        public bool SetFinish(DateTime finish)
        {
            if (finish > Start)
            {
                Finish = finish;
                return true;
            }
            return false;
        }

        private void SetSeverity(int severity)
        {
            this.Severity = severity;
            if (Severity >= 3)
            {
                Tram.SetTramStatus("Defect");
            }
        }

        public override string ToString()
        {
            return $"{Name}, {Function}";
        }
    }
}
