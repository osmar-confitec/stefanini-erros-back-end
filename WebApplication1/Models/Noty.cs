using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public enum Priority
    {
        Hight = 1,
        Average = 2,
        Low = 3
    }

    public enum Layer
    {
        App = 1,
        Domain = 2,
        Repository = 3,
        Others = 4
    }
    public enum NotyType
    {
        Alert = 1,
        Error = 2,
        Success = 3,
        Information = 4
    }

    public enum NotyIntention
    {





    }

    public class Noty
    {

        public Priority Priority { get; set; }

        public Layer? Layer { get; set; }

        public NotyType NotyType { get; set; }

        public string Message { get; set; }

        public NotyIntention? NotyIntention { get; set; }

        public List<string> ErrorProperties { get; set; }

        public Noty()
        {
            Priority = Priority.Average;
            NotyType = NotyType.Error;
            ErrorProperties = new List<string>();
        }

    }


    public class LNoty : List<Noty>
    {

        new void  Add(Noty not)
        {
            ///colocar regras aqui

            base.Add(not);
        }

        new void AddRange(IEnumerable<Noty> nots)
        {
            foreach (var item in nots)
            {
                Add(item);
            }
        
        }

        public bool HaveErros { get { return this.Any(x => x.NotyType == NotyType.Error); } }

        public bool HaveAlerts { get { return this.Any(x => x.NotyType == NotyType.Alert); } }

        public bool HaveSucess { get { return this.Any(x => x.NotyType == NotyType.Success); } }

        public bool HaveInformations { get { return this.Any(x => x.NotyType == NotyType.Information); } }

        public bool HaveNotifications { get { return this.Any(); } }

    }
}
